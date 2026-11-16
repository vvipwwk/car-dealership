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
    public partial class SVehicleRemove : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DELL-LATITUDE-5\SQLEXPRESS;Initial Catalog=CarDealer;Integrated Security=True");

        protected void btnYes_Click(object sender, EventArgs e)
        {
                var carID = Request.QueryString["cid"];
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from [dbo].[CarDetail] where [cid] = '" + carID + "'";
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "delete from [dbo].[CarLists] where [cid] = '" + carID + "'";
                cmd1.ExecuteNonQuery();
                con.Close();

            status.Text = "Record remove successfully!";
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            Response.Redirect("SVehicles.aspx");
        }
    }
}