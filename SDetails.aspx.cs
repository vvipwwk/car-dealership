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
using System.IO;

namespace CarDealership
{
    public partial class SDetails : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDealerConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var carID = Request.QueryString["cid"];
                string sqlquery = "select [cid],[brand],[model] from [dbo].[CarLists] where cid ='" + carID + "'";
                SqlCommand sqlcomm = new SqlCommand(sqlquery, con);

                con.Open();

                SqlDataReader reader = sqlcomm.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        lblCID.Text = reader.GetString(0);
                        lblCBrand.Text = reader.GetString(1);
                        lblCModel.Text = reader.GetString(2);
                    }
                }
                con.Close();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("img/");

            if (imgUpload.HasFile)
            {
                string ext = Path.GetExtension(imgUpload.FileName);
                if (ext == ".jpg" || ext == ".png")
                {
                    imgUpload.SaveAs(path + imgUpload.FileName);
                    string name = "img/" + imgUpload.FileName;

                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into [dbo].[CarDetail] values ('" + txtCDID.Text + "','" + lblCID.Text + "','" + lblCBrand.Text + "','" + lblCModel.Text + "','" + txtCDesc.Text + "','" + name + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    status.Text = "Successful!";
                }
                else
                {
                    status.Text = "Only .jpg and .png files is allowed!";
                }
            }
            else
            {
                status.Text = "Please enter all information!";
            }
        }
    }
}