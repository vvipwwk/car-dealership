using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;

namespace CarDealership
{
    public partial class SDetails : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            string carId = Request.QueryString["cid"];
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.GetConnectionString()))
            using (SqlCommand command = new SqlCommand("SELECT [cid], [brand], [model] FROM [dbo].[CarLists] WHERE [cid] = @cid", connection))
            {
                command.Parameters.Add("@cid", SqlDbType.NVarChar, 50).Value = carId ?? String.Empty;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        Response.Redirect("SVehicles.aspx");
                        return;
                    }

                    lblCID.Text = HttpUtility.HtmlEncode(Convert.ToString(reader["cid"]));
                    lblCBrand.Text = HttpUtility.HtmlEncode(Convert.ToString(reader["brand"]));
                    lblCModel.Text = HttpUtility.HtmlEncode(Convert.ToString(reader["model"]));
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!imgUpload.HasFile)
            {
                status.Text = "Choose a vehicle image to upload.";
                return;
            }

            string extension = Path.GetExtension(imgUpload.FileName).ToLowerInvariant();
            if ((extension != ".jpg" && extension != ".png") || imgUpload.PostedFile.ContentLength > 5 * 1024 * 1024)
            {
                status.Text = "Upload a JPG or PNG image no larger than 5 MB.";
                return;
            }

            string fileName = Guid.NewGuid().ToString("N") + extension;
            string relativePath = "img/" + fileName;
            imgUpload.SaveAs(Server.MapPath(relativePath));

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.GetConnectionString()))
            using (SqlCommand command = new SqlCommand("INSERT INTO [dbo].[CarDetail] VALUES (@did, @cid, @brand, @model, @description, @image)", connection))
            {
                command.Parameters.Add("@did", SqlDbType.NVarChar, 50).Value = txtCDID.Text.Trim();
                command.Parameters.Add("@cid", SqlDbType.NVarChar, 50).Value = HttpUtility.HtmlDecode(lblCID.Text);
                command.Parameters.Add("@brand", SqlDbType.NVarChar, 100).Value = HttpUtility.HtmlDecode(lblCBrand.Text);
                command.Parameters.Add("@model", SqlDbType.NVarChar, 100).Value = HttpUtility.HtmlDecode(lblCModel.Text);
                command.Parameters.Add("@description", SqlDbType.NVarChar, -1).Value = txtCDesc.Text.Trim();
                command.Parameters.Add("@image", SqlDbType.NVarChar, 260).Value = relativePath;
                connection.Open();
                command.ExecuteNonQuery();
            }

            status.Text = "Vehicle details added successfully.";
        }
    }
}
