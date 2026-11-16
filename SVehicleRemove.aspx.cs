using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace CarDealership
{
    public partial class SVehicleRemove : Page
    {
        protected void btnYes_Click(object sender, EventArgs e)
        {
            string carId = Request.QueryString["cid"];
            if (String.IsNullOrWhiteSpace(carId))
            {
                status.Text = "Invalid vehicle selection.";
                return;
            }

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.GetConnectionString()))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand detail = new SqlCommand("DELETE FROM [dbo].[CarDetail] WHERE [cid] = @cid", connection, transaction))
                        {
                            detail.Parameters.Add("@cid", SqlDbType.NVarChar, 50).Value = carId;
                            detail.ExecuteNonQuery();
                        }

                        using (SqlCommand vehicle = new SqlCommand("DELETE FROM [dbo].[CarLists] WHERE [cid] = @cid", connection, transaction))
                        {
                            vehicle.Parameters.Add("@cid", SqlDbType.NVarChar, 50).Value = carId;
                            vehicle.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }

            status.Text = "Vehicle record removed successfully.";
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            Response.Redirect("SVehicles.aspx");
        }
    }
}
