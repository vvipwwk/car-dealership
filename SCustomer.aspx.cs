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
    public partial class SCustomer : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDealerConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            //reg customer table display

            if (!Page.IsPostBack)
            {
                string sqlquery = "select * from [dbo].[Customer]";
                SqlCommand sqlconn = new SqlCommand(sqlquery, con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(sqlconn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                StringBuilder sb = new StringBuilder();
                sb.Append("<center>");
                sb.Append("<h1>Registered customer lists</h1>");
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
                    int uID = 0;
                    foreach (DataColumn dc in dt.Columns)
                    {
                        sb.Append("<th>");
                        uID = dr.Field<int>(0);
                        sb.Append(dr[dc.ColumnName].ToString());
                        sb.Append("</th>");
                    }
                    sb.Append("<th>");
                    sb.Append("<a href = 'SCustomerEdit.aspx?uid=" + uID + "'><button type = 'button'>Edit</button></a>");
                    sb.Append("<a href = 'SCustomerRemove.aspx?uid=" + uID + "'><button type = 'button'>Remove</button></a>");
                    sb.Append("</th>");
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                sb.Append("</center>");
                customerdb.Controls.Add(new Label { Text = sb.ToString() });
                con.Close();
            }
        }
    }
}