# SKILL: modify-aspx-ui

## Cuándo usar este skill

Cuando la SPEC pida añadir, modificar o eliminar elementos de UI en páginas ASPX o controles ASCX de una aplicación WebForms legacy.

Ejemplos: añadir un mensaje, cambiar un texto, añadir un botón, mostrar/ocultar un control.

---

## Proceso estándar (seguir en este orden)

### Paso 1 — Leer el archivo .aspx completo

Antes de hacer cualquier cambio, leer el archivo .aspx completo para entender:
- Qué `ContentPlaceHolderID` usa (normalmente `MainContent`)
- La estructura HTML existente (hgroup, divs, sections)
- Los IDs de controles existentes para no duplicar
- El master page que usa (`MasterPageFile="~/Site.Master"`)

### Paso 2 — Determinar el tipo de elemento a añadir

| Necesidad | Elemento a usar |
|-----------|----------------|
| Texto estático sin lógica | `<p>texto</p>` o `<h2>texto</h2>` |
| Texto que cambia desde code-behind | `<asp:Label runat="server" ID="MiLabel" />` |
| Texto de solo lectura sin eventos | `<asp:Literal runat="server" ID="MiLiteral" />` |
| Mensaje de error/éxito | `ErrorSuccessNotifier.AddErrorMessage("msg")` desde code-behind |
| Contenedor condicional (visible/hidden) | `<asp:PlaceHolder runat="server" ID="MiPlaceHolder" Visible="false">` |

### Paso 3 — Ubicar el punto de inserción

Reglas de posicionamiento en Login.aspx:
```
<asp:Content ContentPlaceHolderID="MainContent">
  <hgroup class="title">        ← ANTES del form: para títulos/cabeceras
    <h1>...</h1>
  </hgroup>
  
  <div class="row-fluid">       ← DENTRO: para contenido relacionado con el form
    <div class="span7">
      <section id="loginForm">  ← Aquí está el formulario de login
        <fieldset>
          ...                   ← DENTRO del fieldset: para elementos del form
        </fieldset>
        <p>...</p>              ← DESPUÉS del fieldset: para links/info secundaria
      </section>
    </div>
  </div>
  
  [DESPUÉS del row-fluid]       ← Para contenido independiente del form
</asp:Content>
```

### Paso 4 — Aplicar el cambio mínimo

**Principio: cambiar solo lo estrictamente necesario.**

Para texto estático (como "Hello World"):
```aspx
<%-- Añadir dentro de <hgroup> o antes del <div class="row-fluid"> --%>
<p class="text-info">Hello World</p>
```

Para texto dinámico desde code-behind:
```aspx
<%-- En el .aspx: --%>
<asp:Label runat="server" ID="HelloWorldLabel" CssClass="text-info" />

<%-- En el .aspx.cs, dentro de Page_Load: --%>
HelloWorldLabel.Text = "Hello World";
```

### Paso 5 — Verificar que el markup es válido

Checklist antes de guardar:
- [ ] Todo tag abierto tiene su cierre (`<div>...</div>`)
- [ ] Los controles ASP.NET tienen `runat="server"`
- [ ] Los IDs no duplican IDs existentes en la página
- [ ] El `ContentPlaceHolderID` es correcto
- [ ] No se ha modificado la directiva `<%@ Page ... %>` salvo necesidad
- [ ] El archivo sigue siendo UTF-8 sin BOM (o con BOM si el original lo tenía)

### Paso 6 — Determinar si el code-behind necesita cambios

Solo modificar `.aspx.cs` si:
- El elemento añadido tiene un ID de servidor y necesita configurarse en `Page_Load`
- La visibilidad del elemento depende de lógica de negocio
- El texto a mostrar viene de la base de datos o del contexto del usuario

Si el texto es estático → NO tocar el code-behind.

---

## Output esperado

Producir el archivo `.aspx` completo con el cambio aplicado, no solo el diff.
Formato:

```
// ===== SocialNetwork/Account/Login.aspx =====
[contenido completo del archivo con el cambio]
```

Si también se modificó el code-behind:
```
// ===== SocialNetwork/Account/Login.aspx.cs =====
[contenido completo del archivo con el cambio]
```

---

## Errores comunes a evitar

| Error | Corrección |
|-------|-----------|
| Usar `@` syntax de Razor (`@Model.Prop`) | Usar `<%: Property %>` o `<asp:Literal>` |
| Usar `class="col-md-6"` (Bootstrap 4/5) | Usar `class="span6"` (Bootstrap 2) |
| Modificar el `<form runat="server">` principal | Nunca tocar el form tag del master page |
| Añadir `using` de .NET 5+ | Solo namespaces de .NET Framework 4.x |
| Usar `nameof()` u otras features de C# 6+ sin verificar | El proyecto puede compilar con C# 5 o inferior |

---

## Criterios de aceptación automáticos para cambios de UI

- [ ] `msbuild SocialNetwork.sln /p:Configuration=Debug` sale con código 0
- [ ] El elemento añadido aparece en el HTML renderizado de la página
- [ ] No se han modificado archivos fuera de los indicados en la SPEC
- [ ] El número de errores de compilación es 0
