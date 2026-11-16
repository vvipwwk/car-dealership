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
    public partial class BuyCar : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DELL-LATITUDE-5\SQLEXPRESS;Initial Catalog=CarDealer;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            //fetch customer user id

            int uid = 0;
            string sqlquery2 = "select [uid] from [dbo].[Customer]";
            SqlCommand sqlcomm2 = new SqlCommand(sqlquery2, con);
            con.Open();
            SqlDataReader reader = sqlcomm2.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    uid = (int)reader.GetValue(0);
                }
            }
            con.Close();

            //vehicle lists table display

            if (!Page.IsPostBack)
            {
                string sqlquery = "select [cid],[brand],[model],[type],[engine],[country] from [dbo].[CarLists]";
                SqlCommand sqlconn = new SqlCommand(sqlquery, con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(sqlconn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                StringBuilder sb = new StringBuilder();
                sb.Append("<center>");
                sb.Append("<h1>Vehicle Line-Up</h1>");
                sb.Append("<hr/>");
                sb.Append("<table border = 1>");
                sb.Append("<tr>");
                foreach (DataColumn dc in dt.Columns)
                {
                    sb.Append("<th>");
                    sb.Append(dc.ColumnName.ToUpper());
                    sb.Append("</th>");
                }
                sb.Append("</tr>");

                foreach (DataRow dr in dt.Rows)
                {
                    sb.Append("<tr>");
                    string carID = null;
                    foreach (DataColumn dc in dt.Columns)
                    {
                        sb.Append("<th>");
                        carID = dr.Field<string>(0);
                        sb.Append(dr[dc.ColumnName].ToString());
                        sb.Append("</th>");
                    }
                    sb.Append("<th>");
                    sb.Append("<a href = 'BookCar.aspx?cid=" + carID + "'><button type = 'button'>Book</button></a>");
                    sb.Append("</th>");
                    sb.Append("</tr>");
                }

                sb.Append("</table>");
                sb.Append("</center>");
                saledb.Controls.Add(new Label { Text = sb.ToString() });
                con.Close();
            }
        }
    }
}