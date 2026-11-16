using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;

namespace CarDealership
{
    public partial class CVehicleDetails : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Image1.Visible = false;
            Label1.Visible = false;
            lblDesc.Visible = false;

            if (IsPostBack) return;

            string carId = Request.QueryString["cid"];
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.GetConnectionString()))
            using (SqlCommand command = new SqlCommand("SELECT [brand], [model], [type], [engine], [country], [price] FROM [dbo].[CarLists] WHERE [cid] = @cid", connection))
            {
                command.Parameters.Add("@cid", SqlDbType.NVarChar, 50).Value = carId ?? String.Empty;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        Response.Redirect("CVehicles.aspx");
                        return;
                    }

                    lblCarBrand.Text = HttpUtility.HtmlEncode(Convert.ToString(reader["brand"]));
                    lblCarName.Text = HttpUtility.HtmlEncode(Convert.ToString(reader["model"]));
                    lblType.Text = HttpUtility.HtmlEncode(Convert.ToString(reader["type"]));
                    lblEngine.Text = HttpUtility.HtmlEncode(Convert.ToString(reader["engine"]));
                    lblCountry.Text = HttpUtility.HtmlEncode(Convert.ToString(reader["country"]));
                    lblPrice.Text = HttpUtility.HtmlEncode(Convert.ToString(reader["price"]));
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string carId = Request.QueryString["cid"];
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.GetConnectionString()))
            using (SqlCommand command = new SqlCommand("SELECT [img], [description] FROM [dbo].[CarDetail] WHERE [cid] = @cid", connection))
            {
                command.Parameters.Add("@cid", SqlDbType.NVarChar, 50).Value = carId ?? String.Empty;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read()) return;

                    string imagePath = Convert.ToString(reader["img"]);
                    string extension = Path.GetExtension(imagePath);
                    string fileName = Path.GetFileName(imagePath);
                    if (!String.IsNullOrEmpty(imagePath) && imagePath.StartsWith("img/", StringComparison.OrdinalIgnoreCase) &&
                        String.Equals(imagePath.Substring(4), fileName, StringComparison.Ordinal) &&
                        (String.Equals(extension, ".jpg", StringComparison.OrdinalIgnoreCase) || String.Equals(extension, ".png", StringComparison.OrdinalIgnoreCase)))
                    {
                        Image1.ImageUrl = "~/" + imagePath;
                        Image1.Visible = true;
                    }
                    Label1.Visible = true;
                    lblDesc.Visible = true;
                    lblDesc.Text = HttpUtility.HtmlEncode(Convert.ToString(reader["description"]));
                }
            }
        }
    }
}
