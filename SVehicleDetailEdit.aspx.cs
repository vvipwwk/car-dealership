using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;

namespace CarDealership
{
    public partial class SVehicleDetailEdit : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            string carId = Request.QueryString["cid"];
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.GetConnectionString()))
            using (SqlCommand command = new SqlCommand("SELECT [did], [cid], [brand], [model], [description] FROM [dbo].[CarDetail] WHERE [cid] = @cid", connection))
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

                    lblCarDetailsID.Text = HttpUtility.HtmlEncode(Convert.ToString(reader["did"]));
                    lblCarID.Text = HttpUtility.HtmlEncode(Convert.ToString(reader["cid"]));
                    lblCarBrand.Text = HttpUtility.HtmlEncode(Convert.ToString(reader["brand"]));
                    lblCarModel.Text = HttpUtility.HtmlEncode(Convert.ToString(reader["model"]));
                    txtCarDesc.Text = Convert.ToString(reader["description"]);
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string imagePath = null;
            if (imgUpload.HasFile)
            {
                string extension = Path.GetExtension(imgUpload.FileName).ToLowerInvariant();
                if ((extension != ".jpg" && extension != ".png") || imgUpload.PostedFile.ContentLength > 5 * 1024 * 1024)
                {
                    status.Text = "Upload a JPG or PNG image no larger than 5 MB.";
                    return;
                }

                string fileName = Guid.NewGuid().ToString("N") + extension;
                imagePath = "img/" + fileName;
                imgUpload.SaveAs(Server.MapPath(imagePath));
            }

            string sql = "UPDATE [dbo].[CarDetail] SET [description] = @description";
            if (imagePath != null) sql += ", [img] = @image";
            sql += " WHERE [did] = @did";

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.GetConnectionString()))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@description", SqlDbType.NVarChar, -1).Value = txtCarDesc.Text.Trim();
                command.Parameters.Add("@did", SqlDbType.NVarChar, 50).Value = HttpUtility.HtmlDecode(lblCarDetailsID.Text);
                if (imagePath != null)
                    command.Parameters.Add("@image", SqlDbType.NVarChar, 260).Value = imagePath;

                connection.Open();
                command.ExecuteNonQuery();
            }

            status.Text = "Vehicle details updated successfully.";
        }
    }
}
