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
    public partial class SCustomerRemove : System.Web.UI.Page
    {
        protected void btnYes_Click(object sender, EventArgs e)
        {
            int userId;
            if (!Int32.TryParse(Request.QueryString["uid"], out userId))
            {
                status.Text = "Invalid customer selection.";
                return;
            }

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.GetConnectionString()))
            using (SqlCommand command = new SqlCommand("DELETE FROM [dbo].[Customer] WHERE [uid] = @uid", connection))
            {
                command.Parameters.Add("@uid", SqlDbType.Int).Value = userId;
                connection.Open();
                command.ExecuteNonQuery();
            }

            status.Text = "Customer record removed successfully.";
        }
        protected void btnNo_Click(object sender, EventArgs e)
        {
            Response.Redirect("SCustomer.aspx");
        }

    }
}
