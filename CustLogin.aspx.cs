using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;

namespace CarDealership
{
    public partial class CustLogin : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDealerConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["username"] != null && Request.Cookies["password"] != null)
                {
                    txtUName.Text = Request.Cookies["username"].Value;
                    txtPass.Attributes["value"] = Request.Cookies["password"].Value;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try 
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select [username], [password] from [dbo].[Customer] where [username] = '"+txtUName.Text+"' and [password] = '"+txtPass.Text+"'";
                SqlDataReader sdr = cmd.ExecuteReader(); 
                
                if(sdr.Read())
                {
                    if (CBRmbr.Checked)
                    {
                        Response.Cookies["username"].Value = txtUName.Text;
                        Response.Cookies["password"].Value = txtPass.Text;
                        Response.Cookies["username"].Expires = DateTime.Now.AddMinutes(1);
                        Response.Cookies["password"].Expires = DateTime.Now.AddMinutes(1);
                    }
                    else
                    {
                        Response.Cookies["username"].Expires = DateTime.Now.AddMinutes(-1);
                        Response.Cookies["password"].Expires = DateTime.Now.AddMinutes(-1);
                    }
                    
                    Session["username"] = txtUName.Text;
                    Response.Redirect("CustHome.aspx");
                    txtUName.Text = "";
                    txtPass.Text = "";
                }
                else
                {
                    Response.Write("<script>alert('Error login information, Please try again!')</script>");
                    txtUName.Text = "";
                    txtPass.Text = "";
                }
                con.Close();
            }
            catch 
            {
                Response.Write("SQL Error");
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void LBreg_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustReg.aspx");
        }
    }
}