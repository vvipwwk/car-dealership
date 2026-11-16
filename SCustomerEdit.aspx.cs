using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;

namespace CarDealership
{
    public partial class SCustomerEdit : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            int userId;
            if (!Int32.TryParse(Request.QueryString["uid"], out userId))
            {
                Response.Redirect("SCustomer.aspx");
                return;
            }

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.GetConnectionString()))
            using (SqlCommand command = new SqlCommand("SELECT [uid], [username], [fullname], [DOB], [sex], [contactno], [email] FROM [dbo].[Customer] WHERE [uid] = @uid", connection))
            {
                command.Parameters.Add("@uid", SqlDbType.Int).Value = userId;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        Response.Redirect("SCustomer.aspx");
                        return;
                    }

                    lblUID.Text = reader["uid"].ToString();
                    txtUserName.Text = Convert.ToString(reader["username"]);
                    txtPassword.Text = String.Empty;
                    txtPassword.Attributes["placeholder"] = "Leave blank to keep current password";
                    txtFullName.Text = Convert.ToString(reader["fullname"]);
                    txtDateofBirth.Text = Convert.ToDateTime(reader["DOB"]).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    RBMale.Checked = String.Equals(Convert.ToString(reader["sex"]), "Male", StringComparison.OrdinalIgnoreCase);
                    RBFemale.Checked = !RBMale.Checked;
                    txtContactNo.Text = Convert.ToString(reader["contactno"]);
                    txtEmail.Text = Convert.ToString(reader["email"]);
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            if (!String.IsNullOrWhiteSpace(txtPassword.Text) && txtPassword.Text.Length < 12)
            {
                Response.Write("<script>alert('A new password must be at least 12 characters.');</script>");
                return;
            }

            int userId;
            DateTime dateOfBirth;
            if (!Int32.TryParse(lblUID.Text, out userId) ||
                !DateTime.TryParseExact(txtDateofBirth.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOfBirth))
            {
                Response.Write("<script>alert('Please enter valid customer details.');</script>");
                return;
            }

            string sql = "UPDATE [dbo].[Customer] SET [username] = @username, [fullname] = @fullname, [DOB] = @dob, [sex] = @sex, [contactno] = @contactno, [email] = @email";
            if (!String.IsNullOrWhiteSpace(txtPassword.Text))
                sql += ", [password] = @password";
            sql += " WHERE [uid] = @uid";

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.GetConnectionString()))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@username", SqlDbType.NVarChar, 100).Value = txtUserName.Text.Trim();
                command.Parameters.Add("@fullname", SqlDbType.NVarChar, 150).Value = txtFullName.Text.Trim();
                command.Parameters.Add("@dob", SqlDbType.Date).Value = dateOfBirth;
                command.Parameters.Add("@sex", SqlDbType.NVarChar, 20).Value = RBMale.Checked ? "Male" : "Female";
                command.Parameters.Add("@contactno", SqlDbType.NVarChar, 40).Value = txtContactNo.Text.Trim();
                command.Parameters.Add("@email", SqlDbType.NVarChar, 254).Value = txtEmail.Text.Trim();
                command.Parameters.Add("@uid", SqlDbType.Int).Value = userId;
                if (!String.IsNullOrWhiteSpace(txtPassword.Text))
                    command.Parameters.Add("@password", SqlDbType.NVarChar, 200).Value = PasswordHasher.Hash(txtPassword.Text);

                connection.Open();
                command.ExecuteNonQuery();
            }

            Response.Write("<script>alert('Record updated successfully.');</script>");
        }
    }
}
