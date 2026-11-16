using System;
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
    public partial class StaffLogin : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DELL-LATITUDE-5\SQLEXPRESS;Initial Catalog=CarDealer;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["staffid"] != null && Request.Cookies["password"] != null)
                {
                    txtSID.Text = Request.Cookies["staffid"].Value;
                    txtPass.Attributes["value"] = Request.Cookies["password"].Value;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string username = txtSID.Text;
                    string password = txtPass.Text;
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select [StaffID], [password] from [dbo].[Staff] where [StaffID] = '" + txtSID.Text + "' and [password] = '" + txtPass.Text + "'";
                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.Read())
                    {
                        if (CBRmbr.Checked)
                        {
                            Response.Cookies["staffid"].Value = txtSID.Text;
                            Response.Cookies["password"].Value = txtPass.Text;
                            Response.Cookies["staffid"].Expires = DateTime.Now.AddMinutes(1);
                            Response.Cookies["password"].Expires = DateTime.Now.AddMinutes(1);
                        }
                        else
                        {
                            Response.Cookies["staffid"].Expires = DateTime.Now.AddMinutes(-1);
                            Response.Cookies["password"].Expires = DateTime.Now.AddMinutes(-1);
                        }

                        Session["staffid"] = txtSID.Text;
                        Response.Redirect("StaffHome.aspx");
                        txtSID.Text = "";
                        txtPass.Text = "";
                    }
                    else
                    {
                        Response.Write("<script>alert('Error login information, Please try again!')</script>");
                        txtSID.Text = "";
                        txtPass.Text = "";
                    }
                    con.Close();
                }
                catch
                {
                    Response.Write("SQL Error");
                }
            }
            else
            {
                Response.Write("<script>alert('Please enter all necessary information!')</script>");
            }         
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}