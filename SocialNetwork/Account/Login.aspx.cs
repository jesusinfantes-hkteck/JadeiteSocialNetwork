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
        private const int MaxFailedAttempts = 5;

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

                if (IsLockedOut(UserName.Text))
                {
                    FailureText.Text = "Account locked.";
                    ErrorMessage.Visible = true;
                    return;
                }

                // Validate the user password
                IAuthenticationManager manager = new AuthenticationIdentityManager(new IdentityStore()).Authentication;
                IdentityResult result = manager.CheckPasswordAndSignIn(Context.GetOwinContext().Authentication, UserName.Text, Password.Text, RememberMe.Checked);
                if (result.Success)
                {
                    ResetFailedAttempts(UserName.Text);
                    OpenAuthProviders.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else
                {
                    IncrementFailedAttempts(UserName.Text);
                    FailureText.Text = result.Errors.FirstOrDefault();
                    ErrorMessage.Visible = true;
                }
            }
        }

        private bool IsLockedOut(string email)
        {
            return Session["AccountLocked_" + email] != null && (bool)Session["AccountLocked_" + email];
        }

        private void IncrementFailedAttempts(string email)
        {
            string key = "FailedAttempts_" + email;
            int attempts = Session[key] != null ? (int)Session[key] : 0;
            attempts++;
            Session[key] = attempts;
            if (attempts >= MaxFailedAttempts)
            {
                Session["AccountLocked_" + email] = true;
            }
        }

        private void ResetFailedAttempts(string email)
        {
            Session.Remove("FailedAttempts_" + email);
            Session.Remove("AccountLocked_" + email);
        }

        private bool IsValidEmail(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(email,
                @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }
    }
}
