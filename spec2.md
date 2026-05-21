# ARIADNA TASK SPEC
# Version: 1.0.0
# Generated: 2026-05-21T14:28:35.2422954+00:00
# SpecBuilder: AriadnaKnowledgeStore v0.1.0-mvp
# RepoId: jesusinfantes-hkteck/JadeiteSocialNetwork@main
# VersionId: 8106bfe9-6541-4575-9f67-a15c103d1be7

---

## SECTION 0 — PROBLEMA (entrada del usuario)

### 0.1 Descripción del problema

> Add account lockout in Login.aspx.cs after 5 consecutive failed login attempts. Reset counter on successful login. If email format is invalid do not increment the failed attempt counter.

### 0.2 Comportamiento actual

```
Comportamiento actual según los nodos recuperados del grafo (ver Section 2 y Section 3).
```

### 0.3 Comportamiento esperado

```
Add account lockout in Login.aspx.cs after 5 consecutive failed login attempts. Reset counter on successful login. If email format is invalid do not increment the failed attempt counter.
```

### 0.4 Contexto adicional

- Entorno: .NET Framework 4.5 WebForms · Entity Framework 6
- Impacto: Bajo — cambio localizado en un único fichero

### 0.5 Pull Requests relacionados (recuperados de Neo4j)

<!-- Generado automáticamente por GraphRAG — PRs semánticamente próximos -->
No related pull requests found.

---

## SECTION 1 — CONTEXTO DEL AGENTE

Eres un agente de modificación de código. Tu trabajo es:

- Localizar las áreas relevantes para implementar el cambio descrito en Section 0
- Modificar **únicamente** los archivos necesarios
- Respetar todas las convenciones del código existente
- Producir únicamente código compilable

**Convenciones de este repositorio (jesusinfantes-hkteck/JadeiteSocialNetwork@main):**

```
Namespace raíz:   SocialNetwork
Target framework: .NET Framework 4.5 WebForms
Nullable refs:    False
Async pattern:    sync
ORM:              Entity Framework 6
Test framework:   none
```

**Restricciones:**

- No cambiar esquema de base de datos sin instrucción explícita
- No alterar contratos de API pública sin necesidad
- Seguir las convenciones de código existentes

---

## SECTION 2 — GRAFO DE ENTIDADES RELEVANTES (Neo4j GraphRAG)

<!-- Generado automáticamente. Contiene solo los nodos recuperados para este cambio. -->

### Nodos de código (vector similarity search)

| Nodo | Tipo | Archivo | Score |
|------|------|---------|-------|
| `method:SocialNetwork.Account.Login.LogIn` | method | `SocialNetwork/Account/Login.aspx.cs` | 0,78 |
| `method:SocialNetwork.Account.Login.IsValidEmail` | method | `SocialNetwork/Account/Login.aspx.cs` | 0,76 |
| `class:SocialNetwork.Account.Login` | class | `SocialNetwork/Account/Login.aspx.cs` | 0,74 |


### Expansión de grafo (dependencias directas — 1-2 hops)

```
Class: Login
    └─[HAS_METHOD]──→ IsValidEmail
    └─[HAS_METHOD]──→ LogIn
    └─[HAS_METHOD]──→ Page_Load

Method: LogIn
    └─[HAS_METHOD]──→ Login
    └─[HAS_METHOD]──→ IsValidEmail
    └─[HAS_METHOD]──→ Page_Load

Method: IsValidEmail
    └─[HAS_METHOD]──→ Login
    └─[HAS_METHOD]──→ LogIn
    └─[HAS_METHOD]──→ Page_Load


```

---

## SECTION 2.5 — GUARDRAILS (no negociable)

> **El agente DEBE leer esta sección antes de escribir cualquier línea de código.**
> Las reglas siguientes son obligatorias y su incumplimiento invalida el resultado.

### Vulnerabilidades de seguridad detectadas en la configuración

| Regla | Nombre | Severidad | Entorno | Descripción |
|-------|--------|-----------|---------|-------------|
| `SEC-WF-005` | Information Disclosure via Errors | **Medium** | Debug | Debug mode is enabled or custom errors are off, exposing sensitive error information |
| `SEC-WF-012` | ViewState Encryption Not Enforced | **Medium** | Debug | ViewState encryption is not set to 'Always', potentially exposing sensitive data |
| `SEC-WF-012` | ViewState Encryption Not Enforced | **Medium** | Release | ViewState encryption is not set to 'Always', potentially exposing sensitive data |
| `SEC-WF-007` | Insecure Cookie Configuration | **High** | Debug | Cookies lack HttpOnly or requireSSL flags, enabling session hijacking and man-in-the-middle attacks |
| `SEC-WF-007` | Insecure Cookie Configuration | **High** | Release | Cookies lack HttpOnly or requireSSL flags, enabling session hijacking and man-in-the-middle attacks |
| `SEC-WF-003` | Request Validation Disabled | **Critical** | Debug | Request validation is disabled, allowing Cross-Site Scripting (XSS) attacks |
| `SEC-WF-003` | Request Validation Disabled | **Critical** | Release | Request validation is disabled, allowing Cross-Site Scripting (XSS) attacks |

**Vulnerabilidades preexistentes — no las corrijas en este cambio; no introduzcas variantes similares:**
- `SEC-WF-005`: Set <compilation debug="false" /> and <customErrors mode="RemoteOnly" /> or mode="On"
- `SEC-WF-012`: Set <pages viewStateEncryptionMode="Always" /> for sensitive applications
- `SEC-WF-012`: Set <pages viewStateEncryptionMode="Always" /> for sensitive applications
- `SEC-WF-007`: Set <httpCookies httpOnlyCookies="true" requireSSL="true" /> and <forms requireSSL="true" />
- `SEC-WF-007`: Set <httpCookies httpOnlyCookies="true" requireSSL="true" /> and <forms requireSSL="true" />
- `SEC-WF-003`: Set <pages validateRequest="true" /> in system.web section
- `SEC-WF-003`: Set <pages validateRequest="true" /> in system.web section

### Reglas de validación en scope

_No se detectaron infracciones de reglas de validación en los archivos en scope._

### Restricciones arquitectónicas de este repositorio

- **Framework**: ASP.NET WebForms. NO introducir MVC controllers, Razor Pages ni endpoints REST.
- **UI pattern**: code-behind (`.aspx` + `.aspx.cs`). NO crear clases que hereden de `Controller`.
- **Errores al usuario**: usar el mecanismo de errores existente en el proyecto. NO añadir `<asp:Label>` inline para errores sin seguir el patrón actual.
- **ORM**: Entity Framework 6. NO usar SQL raw ni Dapper. Usa el DbContext existente.
- **Migraciones**: si necesitas cambios de esquema, crea una migración EF6 explícita. NO modificar la base de datos directamente.
- **Tests**: no se detectó framework de tests. NO generar tests; indicar en el PR que la cobertura queda pendiente.
### Lista de verificación obligatoria antes de entregar el código

- [ ] El cambio compila sin errores (`msbuild` / `dotnet build` sale 0)
- [ ] No he introducido ningún patrón ausente en los archivos circundantes
- [ ] No he usado `Response.Write`, `eval`, ni concatenación de SQL sin parámetros
- [ ] Todos los archivos que modifico están listados en Section 6
- [ ] He respetado el mecanismo de manejo de errores existente en el proyecto


---

## SECTION 3 — CÓDIGO FUENTE RELEVANTE (recuperado de Neo4j)

<!-- El código siguiente es el output directo del chunker de Ariadna. -->

### Login.aspx.cs (`SocialNetwork/Account/Login.aspx.cs`)

```csharp
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace SocialNetwork.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (!IsValidEmail(UserName.Text))
                {
                    FailureText.Text = "Invalid email format.";
                    ErrorMessage.Visible = true;
                    return;
                }

                // Validate the user password
                IAuthenticationManager manager = new AuthenticationIdentityManager(new IdentityStore()).Authentication;
                IdentityResult result = manager.CheckPasswordAndSignIn(Context.GetOwinContext().Authentication, UserName.Text, Password.Text, RememberMe.Checked);
                if (result.Success)
                {
                    OpenAuthProviders.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else
                {
                    FailureText.Text = result.Errors.FirstOrDefault();
                    ErrorMessage.Visible = true;
                }
            }
        }

        private bool IsValidEmail(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(email,
                @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }
    }
}
```

### Login.aspx (`SocialNetwork/Account/Login.aspx`)

```csharp
<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SocialNetwork.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>

    <p>Hello World</p>

    <p>HOLA JESUS</p>

    <div class="row-fluid">
        <div class="span7">
            <section id="loginForm">
                
                <fieldset class="form-horizontal">
                    <legend>Use a local account to log in.</legend>
                      <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-error">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="control-group">
                        <asp:Label runat="server" AssociatedControlID="UserName" CssClass="control-label">User name</asp:Label>
                        <div class="controls">
                            <asp:TextBox runat="server" ID="UserName" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                CssClass="text-error" ErrorMessage="The user name field is required." />
                        </div>
                    </div>
                    <div class="control-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="control-label">Password</asp:Label>
                        <div class="controls">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-error" ErrorMessage="The password field is required." />
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <label class="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                            </label>
                        </div>
                    </div>
                    <div class="form-actions no-color">
                        <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="btn" />
                    </div>
                </fieldset>
                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register</asp:HyperLink>
                    if you don't have a local account.
                </p>
            </section>
        </div>

        <div class="span5">
            <section id="socialLoginForm">
                <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
            </section>
        </div>
    </div>
</asp:Content>

```



---

## SECTION 4 — ANÁLISIS Y RECOMENDACIONES

### 4.1 Análisis del contexto

Se recuperaron 3 nodos de código relevantes en 2 fichero(s) mediante búsqueda vectorial. El grafo muestra 9 relación/relaciones entre componentes. Fichero(s) más relevante(s): `Login.aspx.cs`.

### 4.2 Archivos a considerar

- `SocialNetwork/Account/Login.aspx.cs`

### 4.3 Dependencias afectadas

- Componentes relacionados detectados en el grafo:
  - Relación `HAS_METHOD` entre nodos del scope

---

## SECTION 5 — CRITERIOS DE ACEPTACIÓN

### AC-00: No-regresión (OBLIGATORIO)

- **Dado** que el repositorio compila correctamente en el estado actual
- **Cuando** se aplican los cambios descritos en esta SPEC
- **Entonces** la aplicación sigue compilando sin errores y las páginas existentes funcionan
- **Verificar con**: `msbuild /p:Configuration=Debug` — código de salida 0, cero errores nuevos

### AC-01: Account lockout after 5 failures

- **Dado** a valid email format user account exists in the system
- **Cuando** 5 consecutive failed login attempts are made with incorrect passwords in Login.aspx.cs LogIn method
- **Entonces** the 6th login attempt displays 'Account locked' message and FailureText.Text contains lockout error, even with correct password
- **Verificar con**: Attempt login 5 times with wrong password, then verify 6th attempt with correct password fails and ErrorMessage.Visible is true

### AC-02: Counter reset on successful login

- **Dado** a user has 3 failed login attempts tracked
- **Cuando** the user successfully authenticates via CheckPasswordAndSignIn with correct credentials
- **Entonces** the failed attempt counter resets to 0 and subsequent failed attempts restart from 1
- **Verificar con**: Make 3 failed attempts, login successfully, then verify 5 more failed attempts are required before lockout occurs

### AC-03: Invalid email skips counter increment

- **Dado** a user account exists with 0 failed attempts
- **Cuando** IsValidEmail returns false and FailureText.Text shows 'Invalid email format.'
- **Entonces** the failed login attempt counter remains unchanged and does not increment toward the 5-attempt lockout threshold
- **Verificar con**: Submit 10 logins with invalid email format 'baduser@', then login with valid email and wrong password 5 times to verify lockout triggers on attempt 5, not 15

### AC-04: Alcance mínimo (OBLIGATORIO)

- **Dado** el conjunto de archivos identificados en Section 6
- **Cuando** el agente entrega el cambio
- **Entonces** únicamente esos archivos han sido modificados, sin nuevas dependencias NuGet
  y sin cambios en el esquema de base de datos salvo instrucción explícita
- **Verificar con**: `git diff --name-only` — solo los archivos listados en Section 6


---

## SECTION 6 — OUTPUT ESPERADO

El agente debe producir exactamente los siguientes archivos modificados:

```
// ===== SocialNetwork/Account/Login.aspx.cs =====
[contenido completo del archivo con el cambio aplicado]
```

**Formato de entrega:**
- Un bloque de código por archivo
- Encabezado `// ===== ruta/archivo =====` antes de cada bloque
- Código completo del archivo — no solo el diff
- Sin texto adicional entre bloques


---

## SECTION 6.5 — INSTRUCCIONES DE ENTREGA

### Flujo esperado tras aplicar el cambio

1. **Verificar compilación** — ejecutar `msbuild` antes de continuar
2. **Crear commit** con mensaje descriptivo:
   ```bash
   git add SocialNetwork/Account/Login.aspx.cs
   git commit -m "feat: add-account-lockout-in-login.aspx.cs-after-5-consecutive-failed-login-at"
   ```
3. **Crear Pull Request** hacia `main` con:
   - Título: `[Ariadna] Add account lockout in Login.aspx.cs after 5 consecutive failed login attempts. Reset counter on successful login. If email format is invalid do not increment the failed attempt counter.`
   - Descripción: enlace a esta SPEC + resumen del cambio
4. **NO hacer merge directo** — el PR debe ser revisado por un humano
5. **Tras aprobación del PR**, GitHub enviará automáticamente el webhook
   a Ariadna (`POST /api/webhook/github`) que actualizará Neo4j

### En caso de error

Si la compilación falla o el cambio produce comportamiento inesperado:
```bash
git checkout -- SocialNetwork/Account/Login.aspx.cs
```
Esto revierte los archivos modificados al estado anterior sin afectar el resto.

---

## SECTION 7 — METADATA DE TRAZABILIDAD

```json
{
  "specVersion":      "1.0.0",
  "generatedAt":      "2026-05-21T14:28:35.2422954+00:00",
  "ariadnaVersion":   "0.1.0-mvp",
  "repoId":           "jesusinfantes-hkteck/JadeiteSocialNetwork@main",
  "neo4jVersionId":   "8106bfe9-6541-4575-9f67-a15c103d1be7",
  "userQuery":        "Add account lockout in Login.aspx.cs after 5 consecutive failed login attempts. Reset counter on successful login. If email format is invalid do not increment the failed attempt counter.",
  "vectorSearchTopK": 3,
  "graphHops":        2,
  "sourceNodes":      3,
  "relatedPrs":       0
}
```

---

<!-- End of SPEC -->

