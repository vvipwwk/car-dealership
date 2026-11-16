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
    public partial class StaffReg : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDealerConnectionString"].ConnectionString);

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into [dbo].[Staff] values (@StaffID, @staffname, @password, @fullname, @DOB, @sex, @position, @contactno, @email)";
                cmd.Parameters.AddWithValue("@StaffID", txtID.Text);
                cmd.Parameters.AddWithValue("@staffname", txtSName.Text);
                cmd.Parameters.AddWithValue("@password", txtPass.Text);
                cmd.Parameters.AddWithValue("@fullname", txtFName.Text);
                cmd.Parameters.AddWithValue("@DOB", txtDOB.Text);

                if (RBMale.Checked)
                {
                    cmd.Parameters.AddWithValue("@sex", "Male");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@sex", "Female");
                }

                cmd.Parameters.AddWithValue("@position", DDLPosition.Text);
                cmd.Parameters.AddWithValue("@contactno", txtContact.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Register Successfully!')</script>");
            }
            else
            {
                status.Text = "Please enter all necessary information.";
            }
        }

        protected void btnBackL_Click(object sender, EventArgs e)
        {
            Response.Redirect("SStaff.aspx");
        }
    }
}