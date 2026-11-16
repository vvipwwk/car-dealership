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
    public partial class SVehicleDetailEdit : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DELL-LATITUDE-5\SQLEXPRESS;Initial Catalog=CarDealer;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var carID = Request.QueryString["cid"];
                string sqlquery = "select * from [dbo].[CarDetail] where cid ='" + carID + "'";
                SqlCommand sqlcomm = new SqlCommand(sqlquery, con);

                con.Open();

                SqlDataReader reader = sqlcomm.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        lblCarDetailsID.Text = reader.GetString(0);
                        lblCarID.Text = reader.GetString(1);
                        lblCarBrand.Text = reader.GetString(2);
                        lblCarModel.Text = reader.GetString(3);
                        txtCarDesc.Text = reader.GetString(4);
                    }
                }
                con.Close();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
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
                    cmd.CommandText = "update [dbo].[CarDetail] set [description] = '" + txtCarDesc.Text + "',[img] = '"+ name +"' where [did] = '" + lblCarDetailsID.Text + "'";
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