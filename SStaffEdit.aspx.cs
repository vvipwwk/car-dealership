using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web;
using System.Web.UI;

namespace CarDealership
{
    public partial class SStaffEdit : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            string staffId = Request.QueryString["staffid"];
            if (String.IsNullOrWhiteSpace(staffId))
            {
                Response.Redirect("SStaff.aspx");
                return;
            }

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.GetConnectionString()))
            using (SqlCommand command = new SqlCommand("SELECT [StaffID], [staffname], [fullname], [DOB], [sex], [position], [contactno], [email] FROM [dbo].[Staff] WHERE [StaffID] = @staffId", connection))
            {
                command.Parameters.Add("@staffId", SqlDbType.NVarChar, 50).Value = staffId;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        Response.Redirect("SStaff.aspx");
                        return;
                    }

                    lblStaffID.Text = HttpUtility.HtmlEncode(Convert.ToString(reader["StaffID"]));
                    txtStaffName.Text = Convert.ToString(reader["staffname"]);
                    txtPassword.Text = String.Empty;
                    txtPassword.Attributes["placeholder"] = "Leave blank to keep current password";
                    txtFullName.Text = Convert.ToString(reader["fullname"]);
                    txtDateofBirth.Text = Convert.ToDateTime(reader["DOB"]).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    RBMale.Checked = String.Equals(Convert.ToString(reader["sex"]), "Male", StringComparison.OrdinalIgnoreCase);
                    RBFemale.Checked = !RBMale.Checked;
                    DDLPosition.SelectedValue = Convert.ToString(reader["position"]);
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

            DateTime dateOfBirth;
            if (!DateTime.TryParseExact(txtDateofBirth.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOfBirth))
            {
                Response.Write("<script>alert('Please enter valid staff details.');</script>");
                return;
            }

            string sql = "UPDATE [dbo].[Staff] SET [staffname] = @staffName, [fullname] = @fullname, [DOB] = @dob, [sex] = @sex, [position] = @position, [contactno] = @contactno, [email] = @email";
            if (!String.IsNullOrWhiteSpace(txtPassword.Text))
                sql += ", [password] = @password";
            sql += " WHERE [StaffID] = @staffId";

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.GetConnectionString()))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@staffName", SqlDbType.NVarChar, 100).Value = txtStaffName.Text.Trim();
                command.Parameters.Add("@fullname", SqlDbType.NVarChar, 150).Value = txtFullName.Text.Trim();
                command.Parameters.Add("@dob", SqlDbType.Date).Value = dateOfBirth;
                command.Parameters.Add("@sex", SqlDbType.NVarChar, 20).Value = RBMale.Checked ? "Male" : "Female";
                command.Parameters.Add("@position", SqlDbType.NVarChar, 100).Value = DDLPosition.SelectedValue;
                command.Parameters.Add("@contactno", SqlDbType.NVarChar, 40).Value = txtContactNo.Text.Trim();
                command.Parameters.Add("@email", SqlDbType.NVarChar, 254).Value = txtEmail.Text.Trim();
                command.Parameters.Add("@staffId", SqlDbType.NVarChar, 50).Value = HttpUtility.HtmlDecode(lblStaffID.Text);
                if (!String.IsNullOrWhiteSpace(txtPassword.Text))
                    command.Parameters.Add("@password", SqlDbType.NVarChar, 200).Value = PasswordHasher.Hash(txtPassword.Text);

                connection.Open();
                command.ExecuteNonQuery();
            }

            Response.Write("<script>alert('Record updated successfully.');</script>");
        }
    }
}
