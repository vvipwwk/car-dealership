using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace CarDealership
{
    public partial class StaffLogin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.Cookies["staffid"] != null)
                txtSID.Text = Request.Cookies["staffid"].Value;

            ExpireCookie("password"); // Remove cookies created by the old plain-text remember-me flow.
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            try
            {
                string staffId = txtSID.Text.Trim();
                string storedPassword = null;
                using (SqlConnection connection = new SqlConnection(DatabaseConnection.GetConnectionString()))
                using (SqlCommand command = new SqlCommand("SELECT [password] FROM [dbo].[Staff] WHERE [StaffID] = @staffId", connection))
                {
                    command.Parameters.Add("@staffId", SqlDbType.NVarChar, 50).Value = staffId;
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
                        using (SqlCommand upgrade = new SqlCommand("UPDATE [dbo].[Staff] SET [password] = @password WHERE [StaffID] = @staffId", connection))
                        {
                            upgrade.Parameters.Add("@password", SqlDbType.NVarChar, 200).Value = PasswordHasher.Hash(txtPass.Text);
                            upgrade.Parameters.Add("@staffId", SqlDbType.NVarChar, 50).Value = staffId;
                            upgrade.ExecuteNonQuery();
                        }
                    }
                }

                Session["staffid"] = staffId;
                SaveStaffIdCookie(staffId);
                Response.Redirect("StaffHome.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch
            {
                ShowMessage("We could not sign you in right now. Please try again later.");
            }
        }

        private void SaveStaffIdCookie(string staffId)
        {
            if (CBRmbr.Checked)
            {
                HttpCookie cookie = new HttpCookie("staffid", staffId);
                cookie.Expires = DateTime.UtcNow.AddDays(30);
                cookie.HttpOnly = true;
                cookie.Secure = Request.IsSecureConnection;
                cookie.Path = "/";
                cookie.SameSite = SameSiteMode.Lax;
                Response.Cookies.Add(cookie);
            }
            else
            {
                ExpireCookie("staffid");
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
    }
}
