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
    public partial class SStaffEdit : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DELL-LATITUDE-5\SQLEXPRESS;Initial Catalog=CarDealer;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var staffID = Request.QueryString["staffid"];
                string sqlquery = "select * from [dbo].[Staff] where StaffID='" + staffID + "'";
                SqlCommand sqlcomm = new SqlCommand(sqlquery, con);

                con.Open();

                SqlDataReader reader = sqlcomm.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {

                        lblStaffID.Text = reader.GetString(0);
                        txtStaffName.Text = reader.GetString(1);
                        txtPassword.Text = reader.GetString(2);
                        txtFullName.Text = reader.GetString(3);
                        txtDateofBirth.Text = reader.GetDateTime(4).ToString("yyyy-MM-dd");
                        string sex = reader.GetString(5);
                        if (sex == "Male")
                        {
                            RBMale.Checked = true;

                        }
                        else
                        {
                            RBFemale.Checked = true;
                        }

                        DDLPosition.Text = reader.GetString(6);
                        txtContactNo.Text = reader.GetString(7);
                        txtEmail.Text = reader.GetString(8);
                    }
                }
                con.Close();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update [dbo].[Staff] set [staffname] = '" + txtStaffName.Text + "',[password] = '" + txtPassword.Text + "',[fullname] = '" + txtFullName.Text + "',[DOB] = '" + txtDateofBirth.Text + "',[sex] = @sex,[position] = '" +DDLPosition.Text +"',[contactno] = '" + txtContactNo.Text + "',[email] = '" + txtEmail.Text + "' where [StaffID] = '" + lblStaffID.Text + "'";
            string gender = null;
            if (RBMale.Checked == true)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }

            cmd.Parameters.AddWithValue("@sex", gender);
            cmd.ExecuteNonQuery();
            con.Close();

            Response.Write("<script>alert('Record updated successfully!')</script>");
        }
    }
}