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
    public partial class SCustomerEdit : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DELL-LATITUDE-5\SQLEXPRESS;Initial Catalog=CarDealer;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var uID = Request.QueryString["uid"];
                string sqlquery = "select * from [dbo].[Customer] where uid='" + uID + "'";
                SqlCommand sqlcomm = new SqlCommand(sqlquery, con);

                con.Open();

                SqlDataReader reader = sqlcomm.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {

                        lblUID.Text = reader.GetValue(0).ToString();
                        txtUserName.Text = reader.GetString(1);
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

                        txtContactNo.Text = reader.GetString(6);
                        txtEmail.Text = reader.GetString(7);
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
            cmd.CommandText = "update [dbo].[Customer] set [username] = '" + txtUserName.Text + "',[password] = '" + txtPassword.Text + "',[fullname] = '" + txtFullName.Text + "',[DOB] = '" + txtDateofBirth.Text + "',[sex] = @sex,[contactno] = '" + txtContactNo.Text + "',[email] = '" + txtEmail.Text + "' where [uid] = '" + lblUID.Text + "'";
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