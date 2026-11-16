using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;

namespace CarDealership
{
    public partial class SVehicleAdd : Page
    {
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            decimal price;
            if (!Decimal.TryParse(txtCPrice.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out price) || price < 0)
            {
                status.Text = "Enter a valid non-negative price.";
                return;
            }

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.GetConnectionString()))
            using (SqlCommand command = new SqlCommand("INSERT INTO [dbo].[CarLists] VALUES (@cid, @brand, @model, @type, @engine, @country, @price)", connection))
            {
                command.Parameters.Add("@cid", SqlDbType.NVarChar, 50).Value = txtCID.Text.Trim();
                command.Parameters.Add("@brand", SqlDbType.NVarChar, 100).Value = txtCBrand.Text.Trim();
                command.Parameters.Add("@model", SqlDbType.NVarChar, 100).Value = txtCModel.Text.Trim();
                command.Parameters.Add("@type", SqlDbType.NVarChar, 50).Value = DDLCType.SelectedValue;
                command.Parameters.Add("@engine", SqlDbType.NVarChar, 100).Value = txtCEngine.Text.Trim();
                command.Parameters.Add("@country", SqlDbType.NVarChar, 100).Value = txtCCountry.Text.Trim();
                command.Parameters.Add("@price", SqlDbType.Decimal).Value = price;
                command.Parameters["@price"].Precision = 18;
                command.Parameters["@price"].Scale = 2;
                connection.Open();
                command.ExecuteNonQuery();
            }

            status.Text = "Vehicle record added successfully.";
        }
    }
}
