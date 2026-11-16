using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace CarDealership
{
    public partial class SStaffRemove : System.Web.UI.Page
    {
        protected void btnYes_Click(object sender, EventArgs e)
        {
            string staffId = Request.QueryString["staffid"];
            if (String.IsNullOrWhiteSpace(staffId))
            {
                status.Text = "Invalid staff selection.";
                return;
            }

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.GetConnectionString()))
            using (SqlCommand command = new SqlCommand("DELETE FROM [dbo].[Staff] WHERE [StaffID] = @staffId", connection))
            {
                command.Parameters.Add("@staffId", SqlDbType.NVarChar, 50).Value = staffId;
                connection.Open();
                command.ExecuteNonQuery();
            }

            status.Text = "Staff record removed successfully.";
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            Response.Redirect("SStaff.aspx");
        }
    }
}
