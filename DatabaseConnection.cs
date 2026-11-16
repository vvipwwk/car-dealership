using System;
using System.Configuration;

namespace CarDealership
{
    public static class DatabaseConnection
    {
        public static string GetConnectionString()
        {
            string hostedConnectionString = Environment.GetEnvironmentVariable("CARDEALER_CONNECTION_STRING");
            if (!String.IsNullOrWhiteSpace(hostedConnectionString))
                return hostedConnectionString;

            ConnectionStringSettings localConnectionString = ConfigurationManager.ConnectionStrings["CarDealerConnectionString"];
            if (localConnectionString == null || String.IsNullOrWhiteSpace(localConnectionString.ConnectionString))
                throw new ConfigurationErrorsException("Set CARDEALER_CONNECTION_STRING or configure CarDealerConnectionString in Web.config.");

            return localConnectionString.ConnectionString;
        }
    }
}
