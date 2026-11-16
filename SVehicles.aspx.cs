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
    public partial class SVehicles : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(DatabaseConnection.GetConnectionString());
        protected void Page_Load(object sender, EventArgs e)
        {
            //vehicle lists table display

            if (!Page.IsPostBack)
            {
                string sqlquery = "select * from [dbo].[CarLists]";
                SqlCommand sqlconn = new SqlCommand(sqlquery, con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(sqlconn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                StringBuilder sb = new StringBuilder();
                sb.Append("<center>");
                sb.Append("<h1>Vehicle Lists</h1>");
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
                        sb.Append(HttpUtility.HtmlEncode(dr[dc.ColumnName].ToString()));
                        sb.Append("</th>");
                    }
                    sb.Append("<th>");
                    string encodedCarId = HttpUtility.UrlEncode(carID);
                    sb.Append("<a href = 'SDetails.aspx?cid=" + encodedCarId + "'><button type = 'button'>Add Details</button></a>");
                    sb.Append("<a href = 'SVehicleDetailEdit.aspx?cid=" + encodedCarId + "'><button type = 'button'>Edit Details</button></a>");
                    sb.Append("<a href = 'SVehicleRemove.aspx?cid=" + encodedCarId + "'><button type = 'button'>Remove</button></a>");
                    sb.Append("</th>");
                    sb.Append("</tr>");
                }

                sb.Append("</table>");
                sb.Append("</center>");
                vehicledb.Controls.Add(new Label { Text = sb.ToString() });
                con.Close();
            }
        }
    }
}
