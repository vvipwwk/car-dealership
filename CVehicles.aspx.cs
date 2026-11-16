using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.UI;

namespace CarDealership
{
    public partial class CVehicles : Page
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["CarDealerConnectionString"].ConnectionString;

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
                string type = HttpUtility.HtmlEncode(Convert.ToString(vehicle["type"]));
                string engine = HttpUtility.HtmlEncode(Convert.ToString(vehicle["engine"]));
                string country = HttpUtility.HtmlEncode(Convert.ToString(vehicle["country"]));
                string price = HttpUtility.HtmlEncode(Convert.ToString(vehicle["price"]));
                string image = Convert.ToString(vehicle["img"]);
                cards.Append("<article class=\"vehicle-card\">");
                if (String.IsNullOrWhiteSpace(image))
                    cards.Append("<div class=\"vehicle-art\" aria-hidden=\"true\"></div>");
                else
                    cards.Append("<div class=\"vehicle-photo\"><img src=\"").Append(HttpUtility.HtmlAttributeEncode(image)).Append("\" alt=\"").Append(make).Append(" ").Append(model).Append("\" /></div>");
                cards.Append("<div class=\"vehicle-card-body\">");
                cards.Append("<h2>").Append(make).Append(" ").Append(model).Append("</h2>");
                cards.Append("<div class=\"vehicle-meta\">").Append(type).Append(" · ").Append(engine).Append("<br />Imported from ").Append(country).Append("</div>");
                cards.Append("<div class=\"vehicle-price\">RM ").Append(price).Append("</div><div class=\"vehicle-actions\">");
                cards.Append("<a class=\"btn btn-small\" href=\"CVehicleDetails.aspx?cid=").Append(HttpUtility.UrlEncode(carId)).Append("\">View details</a></div></div></article>");
            }
            cards.Append("</div>");
            if (vehicles.Rows.Count == 0)
                cards = new StringBuilder("<p class=\"page-intro\">There are no vehicles listed right now. Please check back soon.</p>");
            vehicledb.Controls.Add(new LiteralControl(cards.ToString()));
        }
    }
}
