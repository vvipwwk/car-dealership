using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;

namespace CarDealership
{
    public partial class StaffReg : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string staffId = Convert.ToString(Session["staffid"]);
            if (String.IsNullOrWhiteSpace(staffId))
            {
                Response.Redirect("StaffLogin.aspx");
                return;
            }

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.GetConnectionString()))
            using (SqlCommand command = new SqlCommand("SELECT [position] FROM [dbo].[Staff] WHERE [StaffID] = @staffId", connection))
            {
                command.Parameters.Add("@staffId", SqlDbType.NVarChar, 50).Value = staffId;
                connection.Open();
                string position = Convert.ToString(command.ExecuteScalar());
                if (!String.Equals(position, "Manager", StringComparison.OrdinalIgnoreCase))
                {
                    Response.Redirect("StaffHome.aspx");
                    return;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid || String.IsNullOrWhiteSpace(txtPass.Text) || txtPass.Text.Length < 12)
            {
                status.Text = "Please complete all required fields and use a password of at least 12 characters.";
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConnection.GetConnectionString()))
                using (SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Staff] ([StaffID], [staffname], [password], [fullname], [DOB], [sex], [position], [contactno], [email]) VALUES (@staffId, @staffName, @password, @fullname, @dob, @sex, @position, @contactNo, @email)", connection))
                {
                    command.Parameters.Add("@staffId", SqlDbType.NVarChar, 50).Value = txtID.Text.Trim();
                    command.Parameters.Add("@staffName", SqlDbType.NVarChar, 100).Value = txtSName.Text.Trim();
                    command.Parameters.Add("@password", SqlDbType.NVarChar, 200).Value = PasswordHasher.Hash(txtPass.Text);
                    command.Parameters.Add("@fullname", SqlDbType.NVarChar, 150).Value = txtFName.Text.Trim();
                    command.Parameters.Add("@dob", SqlDbType.Date).Value = DateTime.ParseExact(txtDOB.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    command.Parameters.Add("@sex", SqlDbType.NVarChar, 20).Value = RBMale.Checked ? "Male" : "Female";
                    command.Parameters.Add("@position", SqlDbType.NVarChar, 100).Value = DDLPosition.SelectedValue;
                    command.Parameters.Add("@contactNo", SqlDbType.NVarChar, 40).Value = txtContact.Text.Trim();
                    command.Parameters.Add("@email", SqlDbType.NVarChar, 254).Value = txtEmail.Text.Trim();
                    connection.Open();
                    command.ExecuteNonQuery();
                }

                status.Text = "Staff account created successfully.";
            }
            catch (SqlException)
            {
                status.Text = "The staff account could not be created. Check the details and try again.";
            }
            catch (FormatException)
            {
                status.Text = "Please enter a valid date of birth.";
            }
        }

        protected void btnBackL_Click(object sender, EventArgs e)
        {
            Response.Redirect("SStaff.aspx");
        }
    }
}
