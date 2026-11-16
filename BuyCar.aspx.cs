using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.UI;

namespace CarDealership
{
    public partial class BuyCar : Page
    {
        private readonly string connectionString = DatabaseConnection.GetConnectionString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            DataTable vehicles = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("select c.[cid],c.[brand],c.[model],c.[type],c.[engine],c.[country],c.[price],d.[img] from [dbo].[CarLists] c left join [dbo].[CarDetail] d on d.[cid] = c.[cid]", connection))
                adapter.Fill(vehicles);

            StringBuilder cards = new StringBuilder("<div class=\"vehicle-grid\">");
            foreach (DataRow vehicle in vehicles.Rows)
            {
                string carId = Convert.ToString(vehicle["cid"]);
                string make = HttpUtility.HtmlEncode(Convert.ToString(vehicle["brand"]));
                string model = HttpUtility.HtmlEncode(Convert.ToString(vehicle["model"]));
                string image = Convert.ToString(vehicle["img"]);
                cards.Append("<article class=\"vehicle-card\">");
                if (String.IsNullOrWhiteSpace(image))
                    cards.Append("<div class=\"vehicle-art\" aria-hidden=\"true\"></div>");
                else if (IsSafeImagePath(image))
                    cards.Append("<div class=\"vehicle-photo\"><img src=\"").Append(HttpUtility.HtmlAttributeEncode(image)).Append("\" alt=\"").Append(make).Append(" ").Append(model).Append("\" /></div>");
                else
                    cards.Append("<div class=\"vehicle-art\" aria-hidden=\"true\"></div>");
                cards.Append("<div class=\"vehicle-card-body\">");
                cards.Append("<h2>").Append(make).Append(" ").Append(model).Append("</h2>");
                cards.Append("<div class=\"vehicle-meta\">").Append(HttpUtility.HtmlEncode(Convert.ToString(vehicle["type"]))).Append(" · ").Append(HttpUtility.HtmlEncode(Convert.ToString(vehicle["engine"])));
                cards.Append("<br />Imported from ").Append(HttpUtility.HtmlEncode(Convert.ToString(vehicle["country"]))).Append("</div>");
                cards.Append("<div class=\"vehicle-price\">RM ").Append(HttpUtility.HtmlEncode(Convert.ToString(vehicle["price"])));
                cards.Append("</div><div class=\"vehicle-actions\"><a class=\"btn btn-small\" href=\"BookCar.aspx?cid=").Append(HttpUtility.UrlEncode(carId)).Append("\">Book this vehicle</a></div></div></article>");
            }
            cards.Append("</div>");
            if (vehicles.Rows.Count == 0)
                cards = new StringBuilder("<p class=\"page-intro\">There are no vehicles available to book right now.</p>");
            saledb.Controls.Add(new LiteralControl(cards.ToString()));
        }

        private static bool IsSafeImagePath(string imagePath)
        {
            if (String.IsNullOrWhiteSpace(imagePath) || !imagePath.StartsWith("img/", StringComparison.OrdinalIgnoreCase))
                return false;

            string fileName = System.IO.Path.GetFileName(imagePath);
            string extension = System.IO.Path.GetExtension(imagePath);
            return String.Equals(imagePath.Substring(4), fileName, StringComparison.Ordinal) &&
                (String.Equals(extension, ".jpg", StringComparison.OrdinalIgnoreCase) || String.Equals(extension, ".png", StringComparison.OrdinalIgnoreCase));
        }
    }
}
