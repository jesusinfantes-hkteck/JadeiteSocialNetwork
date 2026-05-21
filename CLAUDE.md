# CLAUDE.md — JadeiteSocialNetwork

## Identidad del proyecto

Aplicación de red social construida con ASP.NET WebForms (.NET Framework 4.x).
Es una aplicación legacy — NO es .NET 8, NO usa Minimal APIs, NO usa EF Core.

## Stack tecnológico real

```
Framework:      ASP.NET WebForms (.NET Framework 4.5 / 4.8)
UI:             ASPX pages + ASCX user controls + Bootstrap 2.x
Autenticación:  ASP.NET Identity (versión 1.x, no Core)
ORM:            Entity Framework 6 (DbContext, LINQ to Entities)
Base de datos:  SQL Server (connection string en Web.config)
Session:        System.Web.SessionState
Test framework: Ninguno en este proyecto
Nullable refs:  Deshabilitado (proyecto legacy)
Async pattern:  Síncrono por defecto; async solo en métodos marcados con Async="true" en @Page
```

## Estructura de carpetas

```
SocialNetwork/
  Account/          ← Login, Register, Manage (autenticación)
  Controls/         ← User controls reutilizables (.ascx)
  Models/           ← EF6 DbContext y entidades
  Users/            ← Páginas de perfil y posts de usuarios
  img/              ← Imágenes estáticas
  Scripts/          ← jQuery 1.x y scripts propios
  Styles/           ← CSS propio
  Site.Master       ← Master page principal
  Web.config        ← Configuración de la aplicación
  Default.aspx      ← Home pública (PublicWelcomeScreen)
```

## Convenciones de código

- Namespace raíz: `SocialNetwork`
- Namespace de cuenta: `SocialNetwork.Account`
- Code-behind: cada `.aspx` tiene su `.aspx.cs` en la misma carpeta
- Controles de servidor: prefijo `asp:` en markup ASPX
- CSS clases: Bootstrap 2.x (`span7`, `row-fluid`, `control-group`, `btn`)
- Mensajes de error/éxito: usar `ErrorSuccessNotifier.AddErrorMessage()` o `AddSuccessMessage()`
- No usar `Console.WriteLine` ni `Debug.Print`

## Reglas absolutas para el agente

1. NUNCA cambiar `Web.config` sin instrucción explícita
2. NUNCA modificar el esquema de base de datos (añadir/quitar columnas, tablas)
3. NUNCA cambiar firmas de métodos públicos o interfaces existentes
4. NUNCA introducir paquetes NuGet sin instrucción explícita
5. NUNCA usar sintaxis de .NET 5+ (record types, primary constructors, nullable refs, etc.)
6. SIEMPRE respetar el patrón WebForms: lógica en code-behind (.aspx.cs), UI en markup (.aspx)
7. Para añadir texto/UI en una página: editar el archivo .aspx, no el .aspx.cs salvo que sea necesario
8. Para añadir un Label estático: usar HTML plano (`<p>`, `<h2>`, etc.) o `<asp:Label>` si necesita ser referenciado desde code-behind
9. La aplicación usa Bootstrap 2.x — usar clases de esa versión (`span*`, `row-fluid`), NO Bootstrap 4/5

## Patrón para modificaciones de UI en Login.aspx

El contenido va dentro de `<asp:Content ContentPlaceHolderID="MainContent">`.
La estructura existente tiene un `<hgroup>` de título seguido de un `<div class="row-fluid">`.
Para añadir contenido visible: insertar antes o después del `<div class="row-fluid">`, o dentro de la columna `<div class="span7">`.

## Cómo verificar que el cambio funciona

1. Compilar: `msbuild SocialNetwork.sln` debe salir sin errores
2. Ejecutar localmente con IIS Express desde Visual Studio
3. Navegar a `/Account/Login` y verificar visualmente el cambio
4. No hay suite de tests automatizados — la verificación es manual

## Archivos que NUNCA se deben modificar

- `SocialNetwork/Models/SocialNetworkDbEntities.cs` (generado por EF)
- `SocialNetwork/Models/*.edmx` (modelo de EF Designer)
- `SocialNetwork/Scripts/jquery-*.js` (librería externa)
- `packages.config` (gestión de NuGet)
