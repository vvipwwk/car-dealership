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
    public partial class HR : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(DatabaseConnection.GetConnectionString());
        protected void Page_Load(object sender, EventArgs e)
        {
            //reg customer table display

            if (!Page.IsPostBack)
            {
                string sqlquery = "select [uid], [username], [fullname], [DOB], [sex], [contactno], [email] from [dbo].[Customer]";
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
                    foreach (DataColumn dc in dt.Columns)
                    {
                        sb.Append("<th>");
                        sb.Append(HttpUtility.HtmlEncode(dr[dc.ColumnName].ToString()));
                        sb.Append("</th>");
                    }
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                sb.Append("</center>");
                hrdb.Controls.Add(new Label { Text = sb.ToString() });
                con.Close();

                //staff table display

                string sqlquery2 = "select [StaffID], [staffname], [fullname], [DOB], [sex], [position], [contactno], [email] from [dbo].[Staff]";
                SqlCommand sqlconn2 = new SqlCommand(sqlquery2, con);
                con.Open();
                SqlDataAdapter sda2 = new SqlDataAdapter(sqlconn2);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                StringBuilder sb2 = new StringBuilder();
                sb2.Append("<center>");
                sb2.Append("<h1>Staff lists</h1>");
                sb2.Append("<hr/>");
                sb2.Append("<table border = 1>");
                sb2.Append("<tr>");
                foreach (DataColumn dc in dt2.Columns)
                {
                    sb2.Append("<th>");
                    sb2.Append(dc.ColumnName.ToUpper());
                    sb2.Append("</th>");
                }
                sb2.Append("</tr>");

                foreach (DataRow dr in dt2.Rows)
                {
                    sb2.Append("<tr>");
                    foreach (DataColumn dc in dt2.Columns)
                    {
                        sb2.Append("<th>");
                        sb2.Append(HttpUtility.HtmlEncode(dr[dc.ColumnName].ToString()));
                        sb2.Append("</th>");
                    }
                    sb2.Append("</tr>");
                }
                sb2.Append("</table>");
                sb2.Append("</center>");
                hrdb.Controls.Add(new Label { Text = sb2.ToString() });
                con.Close();
            }
        }
    }
}
