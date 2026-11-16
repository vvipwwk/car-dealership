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
using System.IO;

namespace CarDealership
{
    public partial class SVehicleAdd : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DELL-LATITUDE-5\SQLEXPRESS;Initial Catalog=CarDealer;Integrated Security=True");
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into [dbo].[CarLists] values ('" + txtCID.Text + "','" + txtCBrand.Text + "','" + txtCModel.Text + "','" + DDLCType.Text + "','" + txtCEngine.Text + "','" + txtCCountry.Text + "','" + txtCPrice.Text + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    status.Text = "Record added Successfully!"; 
        }
    }
}