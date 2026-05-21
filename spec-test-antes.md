# ARIADNA TASK SPEC
# Version: 1.0.0
# Generated: 2026-05-20T10:55:11.0497302+00:00
# SpecBuilder: AriadnaKnowledgeStore v0.1.0-mvp
# RepoId: jesusinfantes-hkteck/JadeiteSocialNetwork@main
# VersionId: 7711594e-3163-4da7-864a-ea119908e91d

---

## SECTION 0 — PROBLEMA (entrada del usuario)

### 0.1 Descripción del problema

> Quiero poner el mensaje HOLA JESUS en la p�gina de login

### 0.2 Comportamiento actual

```
The login page does not display the message 'HOLA JESUS'
```

### 0.3 Comportamiento esperado

```
The login page displays the message 'HOLA JESUS' when loaded
```

### 0.4 Contexto adicional

- Entorno: ASP.NET Web Forms application - Login page
- Impacto: Low - minimal UI change affecting only the login page with a static message addition

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
| `aspx:SocialNetwork/Account/Login.aspx` | aspx_page | `SocialNetwork/Account/Login.aspx` | 0,70 |
| `control:aspx:SocialNetwork/Account/Login.aspx#ErrorMessage` | aspx_control | `SocialNetwork/Account/Login.aspx` | 0,69 |
| `control:aspx:SocialNetwork/Site.Master#loginLink` | aspx_control | `SocialNetwork/Site.Master` | 0,68 |
| `method:SocialNetwork.Account.Login.Page_Load` | method | `SocialNetwork/Account/Login.aspx.cs` | 0,68 |
| `method:Error_Handler_Control.ErrorSuccessNotifier.Page_Load` | method | `SocialNetwork/Controls/ErrorSuccessNotifier/ErrorSuccessNotifier.ascx.cs` | 0,68 |
| `method:SocialNetwork.PublicWelcomeScreen.Page_Load` | method | `SocialNetwork/Default.aspx.cs` | 0,68 |
| `aspx:SocialNetwork/Default.aspx` | aspx_page | `SocialNetwork/Default.aspx` | 0,68 |
| `method:SocialNetwork.PublicWelcomeScreen.OnSelectedIndexChanged` | method | `SocialNetwork/Default.aspx.cs` | 0,68 |
| `class:SocialNetwork.PublicWelcomeScreen` | class | `SocialNetwork/Default.aspx.cs` | 0,67 |
| `control:aspx:SocialNetwork/Account/Manage.aspx#successMessage` | aspx_control | `SocialNetwork/Account/Manage.aspx` | 0,67 |


### Expansión de grafo (dependencias directas — 1-2 hops)

```
Class: PublicWelcomeScreen
    └─[HAS_METHOD]──→ BindListView
    └─[HAS_METHOD]──→ SearchPeople
    └─[CALLS]──→ SearchPeople
    └─[HAS_METHOD]──→ SearchPeopleButton_Click
    └─[CALLS]──→ SearchPeopleButton_Click

Method: Page_Load
    └─[HAS_METHOD]──→ Login
    └─[HAS_METHOD]──→ LogIn
    └─[HAS_METHOD]──→ Login.aspx
    └─[CODEBEHIND]──→ Login.aspx

Method: Page_Load
    └─[HAS_METHOD]──→ ErrorSuccessNotifier
    └─[HAS_METHOD]──→ IncludeTheCssAndJavaScript
    └─[HAS_METHOD]──→ ShowWaitingNotificationMessages
    └─[HAS_METHOD]──→ Page_PreRender
    └─[HAS_METHOD]──→ AddErrorMessage

Method: Page_Load
    └─[HAS_METHOD]──→ PublicWelcomeScreen
    └─[HAS_METHOD]──→ BindListView
    └─[HAS_METHOD]──→ ListViewSearchPeople_PagePropertiesChanging
    └─[HAS_METHOD]──→ GetImageUrl
    └─[HAS_METHOD]──→ SearchPeopleButton_Click

Method: OnSelectedIndexChanged
    └─[HAS_METHOD]──→ PublicWelcomeScreen
    └─[HAS_METHOD]──→ BindListView
    └─[HAS_METHOD]──→ ListViewSearchPeople_PagePropertiesChanging
    └─[HAS_METHOD]──→ GetImageUrl
    └─[HAS_METHOD]──→ SearchPeopleButton_Click

AspxPage: Login.aspx
    └─[CODEBEHIND]──→ Login
    └─[CODEBEHIND]──→ LogIn
    └─[HAS_METHOD]──→ LogIn
    └─[CODEBEHIND]──→ Page_Load
    └─[HAS_METHOD]──→ Page_Load

AspxPage: Default.aspx
    └─[CODEBEHIND]──→ PublicWelcomeScreen
    └─[CODEBEHIND]──→ BindListView
    └─[HAS_METHOD]──→ BindListView
    └─[CODEBEHIND]──→ ListViewSearchPeople_PagePropertiesChanging
    └─[HAS_METHOD]──→ ListViewSearchPeople_PagePropertiesChanging


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

### Reglas de validación que aplican a los archivos en scope

| Regla | Nombre | Severidad | Categoría | Infracciones | Métodos |
|-------|--------|-----------|-----------|-------------|---------|
| `VAL-CS-003` | Unvalidated Request Input | **Medium** | Security | 2 | `LogIn, Page_Load` |
| `VAL-CS-004` | Static HttpContext Access | **Low** | Architecture | 2 | `ClearMessages, AddMessage` |

**No introduzcas ni perpetúes estos patrones:**
- `VAL-CS-003` — Validate and sanitize all user-supplied input; use typed model binding where possible
- `VAL-CS-004` — Pass HttpContext via constructor injection or method parameters in service classes

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

### Login.aspx (`SocialNetwork/Account/Login.aspx`)

```csharp
<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SocialNetwork.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>

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

### Site.Master (`SocialNetwork/Site.Master`)

```csharp
<%@ Master Language="C#" AutoEventWireup="true" CodeBehind="Site.master.cs" Inherits="SocialNetwork.SiteMaster" %>

<%@ Register Src="~/Controls/ErrorSuccessNotifier/ErrorSuccessNotifier.ascx"
    TagPrefix="nakov" TagName="ErrorSuccessNotifier" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %> - My ASP.NET Application</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

</head>
<body>
    <form runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see http://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>

        <header>
            <div class="navbar navbar-inverse navbar-fixed-top">
                <div class="navbar-inner">
                    <div class="container">

                        <button type="button" class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse">
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>

                        <a class="brand" runat="server" href="~/">Jadeite</a>

                        <div class="nav-collapse collapse">
                            <asp:Menu
                                ID="NavigationMenu"
                                runat="server"
                                CssClass="menu-wrapper dropdown"
                                SkipLinkText=""
                                EnableViewState="False"
                                IncludeStyleBlock="False"
                                Orientation="Horizontal"
                                DataSourceID="SiteMapDataSource"
                                StaticDisplayLevels="2">
                            </asp:Menu>

                            <%--<ul class="nav nav-pills nav-stacked">
                                <li><a runat="server" href="~/About">About</a></li>
                                <li><a runat="server" href="~/Contact">Contact</a></li>
                            </ul>--%>
                            <asp:LoginView runat="server" ViewStateMode="Disabled">
                                <AnonymousTemplate>
                                    <ul class="nav nav-pills nav-stacked pull-right">
                                        <li class="navbar-text"><a id="registerLink" runat="server" href="~/Account/Register">Register</a></li>
                                        <li class="navbar-text"><a id="loginLink" runat="server" href="~/Account/Login">Log in</a></li>
                                    </ul>
                                </AnonymousTemplate>
                                <LoggedInTemplate>
                                    <ul class="nav nav-pills nav-stacked pull-right">
                                        <li class="navbar-text"><a runat="server" href="~/Account/UserDetails" title="Manage your account">Hello, <%: Context.User.Identity.GetUserName()  %> !</a></li>
                                        <li><a runat="server" href="~/Users/UserPost">Add Post</a></li>
                                        <li><a runat="server" href="~/Users/Profile">Profile</a></li>
                                        <li class="navbar-text">
                                            <asp:LoginStatus runat="server" LogoutAction="Redirect" LogoutText="Log off" LogoutPageUrl="~/" OnLoggingOut="Unnamed_LoggingOut" />
                                        </li>
                                    </ul>
                                </LoggedInTemplate>
                            </asp:LoginView>
                        </div>
                    </div>
                </div>
            </div>
        </header>
        <div class="container">

            <asp:SiteMapPath ID="SiteMapPathBreadcrump" runat="server" CssClass="sitemap" />
            <nakov:ErrorSuccessNotifier runat="server" ID="ErrorSuccessNotifier" />
            <div class="MainContent">
                <asp:ContentPlaceHolder ID="MainContent" runat="server">
                </asp:ContentPlaceHolder>
            </div>
            <hr />
            <footer>
                <p>&copy; <%: DateTime.Now.Year %> - Jadeite social network</p>
            </footer>
        </div>
        <asp:SiteMapDataSource ID="SiteMapDataSource" runat="server" />
    </form>
    <script>
        $(".menu-wrapper ul").addClass("nav nav-pills nav-stacked");
        $(".menu-wrapper + div").remove();
    </script>
</body>
</html>

```

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
    }
}
```

### ErrorSuccessNotifier.ascx.cs (`SocialNetwork/Controls/ErrorSuccessNotifier/ErrorSuccessNotifier.ascx.cs`)

```csharp
using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data.Entity.Validation;
using System.Text;

namespace Error_Handler_Control
{
	public enum MessageType
	{
		Success,
		Info,
		Warning,
		Error
	}

	public class NotificationMessage
	{
		public string Text { get; set; }
		public MessageType Type { get; set; }
		public bool AutoHide { get; set; }
	}

	public partial class ErrorSuccessNotifier : System.Web.UI.UserControl
	{
        private const string KEY_NOTIFICATION_MESSAGES = "NotificationMessages";
        private const string KEY_SHOW_AFTER_REDIRECT = 
            "NotificationMessagesShowAfterRedirect";

		public static void AddMessage(NotificationMessage msg)
        {
			List<NotificationMessage> messages = NotificationMessages;
            if (messages == null)
            {
				messages = new List<NotificationMessage>();
            }
            messages.Add(msg);
			HttpContext.Current.Session[KEY_NOTIFICATION_MESSAGES] = messages;
        }

        public static bool ShowAfterRedirect
        {
            get
            {
                object showAfterRedirect = 
                    HttpContext.Current.Session[KEY_SHOW_AFTER_REDIRECT];
                return (showAfterRedirect != null);
            }
            set
            {
                if (value)
                {
                    HttpContext.Current.Session[KEY_SHOW_AFTER_REDIRECT] = true;
                }
                else
                {
                    HttpContext.Current.Session.Remove(KEY_SHOW_AFTER_REDIRECT);
                }
            }
        }

		private static void ClearMessages()
		{
			HttpContext.Current.Session[KEY_NOTIFICATION_MESSAGES] = null;
		}

		private static List<NotificationMessage> NotificationMessages
		{
			get
			{
				List<NotificationMessage> messages = (List<NotificationMessage>)
					HttpContext.Current.Session[KEY_NOTIFICATION_MESSAGES];
				return messages;
			}
		}

		public static void AddInfoMessage(string msg)
		{
			AddMessage(new NotificationMessage()
			{
				Text = msg,
				Type = MessageType.Info,
				AutoHide = true
			});
		}

		public static void AddSuccessMessage(string msg)
		{
			AddMessage(new NotificationMessage()
			{
				Text = msg,
				Type = MessageType.Success,
				AutoHide = true
			});
		}

		public static void AddWarningMessage(string msg)
		{
			AddMessage(new NotificationMessage()
			{
				Text = msg,
				Type = MessageType.Warning,
				AutoHide = false
			});
		}

        public static void AddErrorMessage(string msg)
        {
            AddMessage(new NotificationMessage()
            {
                Text = msg,
                Type = MessageType.Error,
                AutoHide = false
            });
        }

        public static void AddErrorMessage(Exception ex)
        {
            if (ex is DbEntityValidationException)
            {
                DbEntityValidationException validationEx = 
                    (DbEntityValidationException) ex;
                var errorMessages = 
                    validationEx.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);
                AddErrorMessage(String.Join("<br/>", errorMessages));
            }
            else
            {
                AddErrorMessage(ex.Message);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowWaitingNotificationMessages();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!ShowAfterRedirect)
            {
                ShowWaitingNotificationMessages();
            }
        }

        private void ShowWaitingNotificationMessages()
        {
            if (NotificationMessages != null)
            {
                int index = 1;
                foreach (var msg in NotificationMessages)
                {
                    Panel msgPanel = new Panel();
                    msgPanel.CssClass = "PanelNotificationBox Panel" + msg.Type;
                    if (msg.AutoHide)
                    {
                        msgPanel.CssClass += " AutoHide";
                    }
                    msgPanel.ID = msg.Type + "Msg" + index;
                    Literal msgLiteral = new Literal();
                    msgLiteral.Mode = LiteralMode.Encode;
                    msgLiteral.Text = msg.Text;
                    msgPanel.Controls.Add(msgLiteral);
                    this.Controls.Add(msgPanel);
                    index++;
                }
                ClearMessages();

                IncludeTheCssAndJavaScript();
            }

            ShowAfterRedirect = false;
        }

		private void IncludeTheCssAndJavaScript()
		{
			ClientScriptManager cs = Page.ClientScript;

			// Include the jQuery library (if not already included)
			string jqueryURL = this.TemplateSourceDirectory +
				"/Scripts/jquery-1.3.2.js";
			if (!cs.IsStartupScriptRegistered(jqueryURL))
			{
				cs.RegisterClientScriptInclude(jqueryURL, jqueryURL);
			}

			// Include the ErrorSuccessNotifier.js library (if not already included)
			string notifierScriptURL = this.TemplateSourceDirectory +
				"/Scripts/ErrorSuccessNotifier.js";
			if (!cs.IsStartupScriptRegistered(notifierScriptURL))
			{
				cs.RegisterClientScriptInclude(notifierScriptURL, notifierScriptURL);
			}

			// Include the ErrorSuccessNotifier.css stylesheet (if not already included)
			string cssRelativeURL = this.TemplateSourceDirectory +
				"/Styles/ErrorSuccessNotifier.css";
			if (!cs.IsClientScriptBlockRegistered(cssRelativeURL))
			{
				string cssLinkCode = string.Format(
					@"<link href='{0}' rel='stylesheet' type='text/css' />",
                    cssRelativeURL);
				cs.RegisterClientScriptBlock(this.GetType(), cssRelativeURL, cssLinkCode);
			}
		}
	}
}
```

### Default.aspx.cs (`SocialNetwork/Default.aspx.cs`)

```csharp
using SocialNetwork.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Error_Handler_Control;

namespace SocialNetwork
{
    public partial class PublicWelcomeScreen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Load statistics data
            SocialNetworkDbEntities context = new SocialNetworkDbEntities();

            this.LabelTotalUsers.Text = context.AspNetUsers.Count().ToString();
            this.LabelTotalPosts.Text = context.Posts.Count().ToString();
            this.LabelTotalComments.Text = context.Comments.Count().ToString();

            //Grid filtering for logged users
            if (User.Identity.IsAuthenticated)
            {
                this.ButtonShowAllUsers.Visible = true;
                this.ButtonShowFriends.Visible = true;
                this.SearchPeopleButton.Visible = true;
            }
        }

        //Style changes on mouse over in main Grid
        protected void GridViewUsers_RowDataBound(object sender,
            GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] =
                    "this.style.background='#EEEEEE';this.style.cursor='hand'";
                e.Row.Attributes["onmouseout"] =
                    "this.style.background='white'";
                e.Row.Attributes["style"] = "cursor:pointer";
                e.Row.Attributes["onclick"] =
                    ClientScript.GetPostBackClientHyperlink(
                    this.GridViewUsers, "Select$" + e.Row.RowIndex);
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string username = GridViewUsers.SelectedRow.Cells[1].Text;

            Response.Redirect("/Users/Profile?userID=" + GetUserId(username));
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
        }

        //Extracting userId from username
        public string GetUserId(string username)
        {
            SocialNetworkDbEntities context = new SocialNetworkDbEntities();

            var user = context.AspNetUsers.FirstOrDefault(x => x.UserName == username);
            if (user != null)
            {
                return user.Id;
            }
            else
            {
                return "";
            }
        }

        //Populating main Grid with all users data
        public IQueryable<object> GetAllUsersGridData(string userID = null)
        {
            SocialNetworkDbEntities context = new SocialNetworkDbEntities();

            var result = from users in context.AspNetUsers.Include("Posts").Include("UserDetails")
                         where users.Posts.Count > 0
                         select new
                         {
                             ID = users.Id,
                             Username = users.UserName,
                             LatestPost =
                             users.Posts.OrderByDescending(x => x.DateCreated).FirstOrDefault(),
                             AvatarImage = users.UserDetail.AvatarImage
                         };

            return result;

        }

        //Populating main Grid with friends data
        public IQueryable<object> GetFriends()
        {
            SocialNetworkDbEntities context = new SocialNetworkDbEntities();

            string userId = User.Identity.GetUserId();

            var curUser = context.AspNetUsers.Where(x => x.Id == userId).FirstOrDefault();

            var result = from users in context.AspNetUsers.Include("Posts").Include("UserDetail")
                         where
                         users.Friends.Select(x => x.Id).Contains(userId)
                         && users.BefriendedBy.Select(x => x.Id).Contains(userId)
                         && users.Posts.Count > 0
                         select new
                         {
                             ID = users.Id,
                             Username = users.UserName,
                             LatestPost = users.Posts.OrderByDescending(x => x.DateCreated).FirstOrDefault(),
                             AvatarImage = users.UserDetail.AvatarImage
                         };

            return result.OrderBy(x => x.LatestPost.DateCreated);
        }

        //Switching for between grif filtering
        protected void ShowAllUsers_Click(object sender, EventArgs e)
        {
            //!!!! Necessary Hack
            this.GridViewUsers.SelectMethod = "alabala";
            //!!!!
            this.GridViewUsers.SelectMethod = "GetAllUsersGridData";
        }

        protected void ShowFriends_Click(object sender, EventArgs e)
        {
            this.GridViewUsers.SelectMethod = "GetFriends";
        }

        //Search by users by name or city
        public IQueryable<object> SearchPeople(string query)
        {
            SocialNetworkDbEntities context = new SocialNetworkDbEntities();

            var result = from users in context.AspNetUsers.Include("UserDetails")
                         where users.UserName.StartsWith(query) || users.UserDetail.City.StartsWith(query)
                         select new UserLink
                         {
                             ID = users.Id,
                             Username = users.UserName,
                             City = users.UserDetail.City
                         };

            return result;

        }

        //Validating search query
        protected void SearchPeopleButton_Click(object sender, EventArgs e)
        {
            string query = this.QuerySearchPeople.Text;

            if (query.Length <= 2)
            {
                ErrorSuccessNotifier.AddErrorMessage("Query string too short.");
                return;
            }
            else if (query.Length > 200)
            {
                ErrorSuccessNotifier.AddErrorMessage("Query string too long.");
                return;
            }
            else
            {
                BindListView(query);
            }

        }

        //Getting image url from database stream
        protected string GetImageUrl(object imageStream)
        {
            string result;

            if (imageStream != null)
            {
                result = "data:image/jpg;base64," + Convert.ToBase64String((byte[])imageStream);
            }
            else
            {
                result = "~/img/profile-photo.jpg";
            }

            return result;
        }

        protected void ListViewSearchPeople_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            

            //set current page startindex, max rows and rebind to false
            this.DataPagerSearchResults.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            //rebind List View
            BindListView(ViewState["latestquery"].ToString());
        }

        void BindListView(string query)
        {
            this.ListViewSearchPeople.DataSource = SearchPeople(query).ToList();
            this.DataBind();

            ViewState["latestquery"] = query;
        }
    }

    //ItemType used in Listview
    public class UserLink
    {
        public string Username { get; set; }

        public string City { get; set; }

        public string ID { get; set; }
    }
}
```



---

## SECTION 4 — ANÁLISIS Y RECOMENDACIONES

### 4.1 Análisis del contexto

This is a simple UI enhancement to add a custom message to the login page. The relevant files are Login.aspx (markup), Login.aspx.cs (code-behind), and potentially the ErrorSuccessNotifier control if the message should use existing notification infrastructure. The change requires adding a Label or Literal control to display the text, or modifying the Page_Load method to set the message programmatically.

### 4.2 Archivos a considerar

- SocialNetwork/Account/Login.aspx - Main login page markup where the message should be displayed
- SocialNetwork/Account/Login.aspx.cs - Code-behind if message needs to be set programmatically in Page_Load
- SocialNetwork/Controls/ErrorSuccessNotifier/ErrorSuccessNotifier.ascx - If using existing notification control for the message

### 4.3 Dependencias afectadas

- No external dependencies affected
- Master page (Site.Master) may need CSS updates if custom styling is required
- No database or service layer changes needed

---

## SECTION 5 — CRITERIOS DE ACEPTACIÓN

### AC-00: No-regresión (OBLIGATORIO)

- **Dado** que el repositorio compila correctamente en el estado actual
- **Cuando** se aplican los cambios descritos en esta SPEC
- **Entonces** la aplicación sigue compilando sin errores y las páginas existentes funcionan
- **Verificar con**: `msbuild /p:Configuration=Debug` — código de salida 0, cero errores nuevos

### AC-01: Message displays on load

- **Dado** User navigates to the login page
- **Cuando** The login page loads
- **Entonces** The text 'HOLA JESUS' is visible on the page
- **Verificar con**: Navigate to /Account/Login.aspx and visually confirm the message appears

### AC-02: Message persists after postback

- **Dado** User is on the login page with the message displayed
- **Cuando** User submits invalid login credentials
- **Entonces** The message 'HOLA JESUS' remains visible after the error is shown
- **Verificar con**: Submit invalid credentials and verify message still displays along with error

### AC-03: Message position correct

- **Dado** User views the login page on desktop browser
- **Cuando** The page is fully rendered
- **Entonces** The message 'HOLA JESUS' appears in a visible location without breaking the layout
- **Verificar con**: Visual inspection in Chrome/Firefox at 1920x1080 resolution

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
// ===== SocialNetwork/Account/Login.aspx =====
[contenido completo del archivo con el cambio aplicado]
```

```
// ===== SocialNetwork/Account/Login.aspx.cs =====
[contenido completo del archivo con el cambio aplicado]
```

```
// ===== SocialNetwork/Controls/ErrorSuccessNotifier/ErrorSuccessNotifier.ascx =====
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
   git add SocialNetwork/Account/Login.aspx SocialNetwork/Account/Login.aspx.cs SocialNetwork/Controls/ErrorSuccessNotifier/ErrorSuccessNotifier.ascx
   git commit -m "feat: quiero-poner-el-mensaje-hola-jesus-en-la-p�gina-de-login"
   ```
3. **Crear Pull Request** hacia `main` con:
   - Título: `[Ariadna] Quiero poner el mensaje HOLA JESUS en la p�gina de login`
   - Descripción: enlace a esta SPEC + resumen del cambio
4. **NO hacer merge directo** — el PR debe ser revisado por un humano
5. **Tras aprobación del PR**, GitHub enviará automáticamente el webhook
   a Ariadna (`POST /api/webhook/github`) que actualizará Neo4j

### En caso de error

Si la compilación falla o el cambio produce comportamiento inesperado:
```bash
git checkout -- SocialNetwork/Account/Login.aspx SocialNetwork/Account/Login.aspx.cs SocialNetwork/Controls/ErrorSuccessNotifier/ErrorSuccessNotifier.ascx
```
Esto revierte los archivos modificados al estado anterior sin afectar el resto.

---

## SECTION 7 — METADATA DE TRAZABILIDAD

```json
{
  "specVersion":      "1.0.0",
  "generatedAt":      "2026-05-20T10:55:11.0497302+00:00",
  "ariadnaVersion":   "0.1.0-mvp",
  "repoId":           "jesusinfantes-hkteck/JadeiteSocialNetwork@main",
  "neo4jVersionId":   "7711594e-3163-4da7-864a-ea119908e91d",
  "userQuery":        "Quiero poner el mensaje HOLA JESUS en la p�gina de login",
  "vectorSearchTopK": 10,
  "graphHops":        2,
  "sourceNodes":      10,
  "relatedPrs":       0
}
```

---

<!-- End of SPEC -->

