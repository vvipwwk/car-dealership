using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace CarDealership
{
    public partial class CustReg : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDealerConnectionString"].ConnectionString);
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into [dbo].[Customer] ([username], [password], [fullname], [DOB], [sex], [contactno], [email]) values (@username, @password, @fullname, @dateofbirth, @sex, @contactno, @email)";
            cmd.Parameters.AddWithValue("@username", txtUsername.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@fullname", txtFName.Text);
            cmd.Parameters.AddWithValue("@dateofbirth", txtDate.Text);

            if(RBMale.Checked)
            {
                cmd.Parameters.AddWithValue("@sex", "Male");
            }
            else
            {
                cmd.Parameters.AddWithValue("@sex", "Female");
            }
            cmd.Parameters.AddWithValue("@contactno", txtContact.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            Response.Write("<script>alert('Register Successfully!')</script>");
            
        }

        protected void btnBackL_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustLogin.aspx");
        }
    }
}
