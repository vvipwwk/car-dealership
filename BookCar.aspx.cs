using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace CarDealership
{
    public partial class BookCar : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            string carId = Request.QueryString["cid"];
            if (String.IsNullOrWhiteSpace(carId))
            {
                Response.Redirect("BuyCar.aspx");
                return;
            }

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.GetConnectionString()))
            using (SqlCommand command = new SqlCommand("SELECT [brand], [model], [price] FROM [dbo].[CarLists] WHERE [cid] = @cid", connection))
            {
                command.Parameters.Add("@cid", SqlDbType.NVarChar, 50).Value = carId;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        Response.Redirect("BuyCar.aspx");
                        return;
                    }

                    lblCarBrand.Text = HttpUtility.HtmlEncode(Convert.ToString(reader["brand"]));
                    lblCarModel.Text = HttpUtility.HtmlEncode(Convert.ToString(reader["model"]));
                    lblCarPrice.Text = HttpUtility.HtmlEncode(Convert.ToString(reader["price"]));
                }
            }

            lblSalesID.Text = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpperInvariant();
            lblBuyer.Text = HttpUtility.HtmlEncode(Convert.ToString(Session["username"]));
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            string buyer = Convert.ToString(Session["username"]);
            string carId = Request.QueryString["cid"];
            if (String.IsNullOrWhiteSpace(buyer) || String.IsNullOrWhiteSpace(carId))
            {
                Response.Redirect("CustLogin.aspx");
                return;
            }

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.GetConnectionString()))
            {
                connection.Open();
                string brand;
                string model;
                object price;
                using (SqlCommand car = new SqlCommand("SELECT [brand], [model], [price] FROM [dbo].[CarLists] WHERE [cid] = @cid", connection))
                {
                    car.Parameters.Add("@cid", SqlDbType.NVarChar, 50).Value = carId;
                    using (SqlDataReader reader = car.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            status.Text = "This vehicle is no longer available.";
                            return;
                        }
                        brand = Convert.ToString(reader["brand"]);
                        model = Convert.ToString(reader["model"]);
                        price = reader["price"];
                    }
                }

                using (SqlCommand booking = new SqlCommand("INSERT INTO [dbo].[Sale] VALUES (@saleId, @brand, @model, @price, @buyer)", connection))
                {
                    booking.Parameters.Add("@saleId", SqlDbType.NVarChar, 6).Value = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpperInvariant();
                    booking.Parameters.Add("@brand", SqlDbType.NVarChar, 100).Value = brand;
                    booking.Parameters.Add("@model", SqlDbType.NVarChar, 100).Value = model;
                    booking.Parameters.AddWithValue("@price", price);
                    booking.Parameters.Add("@buyer", SqlDbType.NVarChar, 100).Value = buyer;
                    booking.ExecuteNonQuery();
                }
            }

            status.Text = "Car is booked. Please refer to our salesperson for more information.";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuyCar.aspx");
        }
    }
}
