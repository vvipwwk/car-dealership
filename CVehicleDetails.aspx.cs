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
    public partial class CVehicleDetails : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDealerConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            Image1.Visible = false;
            Label1.Visible = false;
            lblDesc.Visible = false;

            if (!Page.IsPostBack)
            {
                var carID = Request.QueryString["cid"];
                string sqlquery = "select brand, model, type, engine, country, price from CarLists where cid = '"+carID+"'";
                SqlCommand sqlcomm = new SqlCommand(sqlquery, con);
                con.Open();

                SqlDataReader reader = sqlcomm.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        lblCarBrand.Text = reader.GetString(0);
                        lblCarName.Text = reader.GetString(1);
                        lblType.Text = reader.GetString(2);
                        lblEngine.Text = reader.GetString(3);
                        lblCountry.Text = reader.GetString(4);
                        lblPrice.Text = reader.GetValue(5).ToString();
                    }
                }
                con.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
                var carID = Request.QueryString["cid"];
                string sqlquery = "select img, description from CarDetail where cid = '" + carID + "'";
                SqlCommand sqlcomm = new SqlCommand(sqlquery, con);
                con.Open();

                SqlDataReader reader = sqlcomm.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        Image1.Visible = true;
                        Label1.Visible = true;
                        lblDesc.Visible = true;
                        Image1.ImageUrl = reader.GetString(0);
                        lblDesc.Text = reader.GetString(1);
                    }
                }
                con.Close();
        }
    }
}