using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;

namespace CarDealership
{
    public partial class CustReg : Page
    {
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid || String.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text.Length < 12)
            {
                ClientScript.RegisterStartupScript(GetType(), "registrationValidation", "alert('Complete the required fields and use a password of at least 12 characters.');", true);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConnection.GetConnectionString()))
                using (SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Customer] ([username], [password], [fullname], [DOB], [sex], [contactno], [email]) VALUES (@username, @password, @fullname, @dob, @sex, @contactno, @email)", connection))
                {
                    command.Parameters.Add("@username", SqlDbType.NVarChar, 100).Value = txtUsername.Text.Trim();
                    command.Parameters.Add("@password", SqlDbType.NVarChar, 200).Value = PasswordHasher.Hash(txtPassword.Text);
                    command.Parameters.Add("@fullname", SqlDbType.NVarChar, 150).Value = txtFName.Text.Trim();
                    command.Parameters.Add("@dob", SqlDbType.Date).Value = DateTime.ParseExact(txtDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    command.Parameters.Add("@sex", SqlDbType.NVarChar, 20).Value = RBMale.Checked ? "Male" : "Female";
                    command.Parameters.Add("@contactno", SqlDbType.NVarChar, 40).Value = txtContact.Text.Trim();
                    command.Parameters.Add("@email", SqlDbType.NVarChar, 254).Value = txtEmail.Text.Trim();
                    connection.Open();
                    command.ExecuteNonQuery();
                }

                ClientScript.RegisterStartupScript(GetType(), "registrationSuccess", "alert('Registration successful. You can now sign in.'); window.location='CustLogin.aspx';", true);
            }
            catch (SqlException)
            {
                ClientScript.RegisterStartupScript(GetType(), "registrationError", "alert('Registration could not be completed. Check the details or try a different username.');", true);
            }
            catch (FormatException)
            {
                ClientScript.RegisterStartupScript(GetType(), "registrationDateError", "alert('Please enter a valid date of birth.');", true);
            }
        }

        protected void btnBackL_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustLogin.aspx");
        }
    }
}
