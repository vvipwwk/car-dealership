using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace CarDealership
{
    public partial class CustLogin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.Cookies["username"] != null)
                txtUName.Text = Request.Cookies["username"].Value;

            ExpireCookie("password"); // Remove cookies created by the old plain-text remember-me flow.
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            try
            {
                string storedPassword = null;
                using (SqlConnection connection = new SqlConnection(DatabaseConnection.GetConnectionString()))
                using (SqlCommand command = new SqlCommand("SELECT [password] FROM [dbo].[Customer] WHERE [username] = @username", connection))
                {
                    command.Parameters.Add("@username", SqlDbType.NVarChar, 100).Value = txtUName.Text.Trim();
                    connection.Open();
                    object value = command.ExecuteScalar();
                    if (value != null && value != DBNull.Value)
                        storedPassword = Convert.ToString(value);

                    bool needsUpgrade;
                    if (!PasswordHasher.Verify(storedPassword, txtPass.Text, out needsUpgrade))
                    {
                        ShowMessage("Login details are incorrect. Please try again.");
                        return;
                    }

                    if (needsUpgrade)
                    {
                        using (SqlCommand upgrade = new SqlCommand("UPDATE [dbo].[Customer] SET [password] = @password WHERE [username] = @username", connection))
                        {
                            upgrade.Parameters.Add("@password", SqlDbType.NVarChar, 200).Value = PasswordHasher.Hash(txtPass.Text);
                            upgrade.Parameters.Add("@username", SqlDbType.NVarChar, 100).Value = txtUName.Text.Trim();
                            upgrade.ExecuteNonQuery();
                        }
                    }
                }

                Session["username"] = txtUName.Text.Trim();
                SaveUsernameCookie(txtUName.Text.Trim());
                Response.Redirect("CustHome.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch
            {
                ShowMessage("We could not sign you in right now. Please try again later.");
            }
        }

        private void SaveUsernameCookie(string username)
        {
            if (CBRmbr.Checked)
            {
                HttpCookie cookie = new HttpCookie("username", username);
                cookie.Expires = DateTime.UtcNow.AddDays(30);
                cookie.HttpOnly = true;
                cookie.Secure = Request.IsSecureConnection;
                cookie.Path = "/";
                cookie.SameSite = SameSiteMode.Lax;
                Response.Cookies.Add(cookie);
            }
            else
            {
                ExpireCookie("username");
            }
        }

        private void ExpireCookie(string name)
        {
            HttpCookie cookie = new HttpCookie(name, String.Empty);
            cookie.Expires = DateTime.UtcNow.AddDays(-1);
            cookie.HttpOnly = true;
            cookie.Secure = Request.IsSecureConnection;
            cookie.Path = "/";
            cookie.SameSite = SameSiteMode.Lax;
            Response.Cookies.Add(cookie);
        }

        private void ShowMessage(string message)
        {
            string encoded = HttpUtility.JavaScriptStringEncode(message);
            ClientScript.RegisterStartupScript(GetType(), "loginMessage", "alert('" + encoded + "');", true);
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void LBreg_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustReg.aspx");
        }
    }
}
