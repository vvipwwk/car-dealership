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
    public partial class BookCar : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DELL-LATITUDE-5\SQLEXPRESS;Initial Catalog=CarDealer;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            int length = 6;
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();
            char sale;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                sale = Convert.ToChar(shift + 65);
                str_build.Append(sale);
            }
            lblSalesID.Text = str_build.ToString();


            if (!Page.IsPostBack)
            {
                var carID = Request.QueryString["cid"];

                string sqlquery = "select [brand],[model],[price] from [dbo].[CarLists] where cid='" + carID + "'";
                SqlCommand sqlcomm = new SqlCommand(sqlquery, con);

                con.Open();

                SqlDataReader reader = sqlcomm.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lblCarBrand.Text = reader.GetString(0);
                        lblCarModel.Text = reader.GetString(1);
                        lblCarPrice.Text = reader.GetValue(2).ToString();
                    }
                }
                con.Close();

                lblBuyer.Text = Session["username"].ToString();
            }

        }
        protected void btnYes_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Sale values ('"+ lblSalesID.Text+ "','" + lblCarBrand.Text + "','" + lblCarModel.Text + "','" + lblCarPrice.Text + "','" + lblBuyer.Text+ "')";
            cmd.ExecuteNonQuery();
            con.Close();

            status.Text = "Car is booked! Refer to our salesperson for more information";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuyCar.aspx");
        }
    }
}