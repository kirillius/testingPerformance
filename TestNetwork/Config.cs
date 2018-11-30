using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNetwork
{
    public class Config
    {
        private ConfigServer productionConfig;
        private ConfigServer developmentConfig;
        private ConfigServer developmentExternalConfig;
        private static ConfigServer currentConfig;

        public Config()
        {
            productionConfig = new ConfigServer("192.168.0.88", "University", "kirillius", "kirillius1991");
            developmentConfig = new ConfigServer("DESKTOP-FREG6V4\\SQLEXPRESS", "University", "kirillius", "kirillius1991");
            developmentExternalConfig = new ConfigServer("185.158.153.107", "dissertation", "rental", "kirillius1991");
        }

        public void SetConfig(string env)
        {
            switch(env)
            {
                case "production":
                    currentConfig = productionConfig;
                    break;
                case "development":
                    currentConfig = developmentConfig;
                    break;
                case "external":
                    currentConfig = developmentExternalConfig;
                    break;
            }
        }

        public static string GenerateConnectionString()
        {
            if (currentConfig == null)
                return null;

            string connectionString = null; //"Server=185.158.153.107;Database=dissertation;User Id=rental;Password=kirillius1991;pooling=true";

            connectionString = "Server=" + currentConfig.urlServer;
            connectionString += ";Database=" + currentConfig.databaseName;
            connectionString += ";User Id=" + currentConfig.login;
            connectionString += ";Password=" + currentConfig.password;
            connectionString += ";pooling=false";

            return connectionString;
        }

        public static string GenerateConnectionStringServer()
        {
            if (currentConfig == null)
                return null;

            string connectionString = null;

            connectionString = "Server=" + currentConfig.urlServer;
            connectionString += ";Database=testClient";
            connectionString += ";User Id=" + currentConfig.login;
            connectionString += ";Password=" + currentConfig.password;
            connectionString += ";pooling=true";

            return connectionString;
        }

        public static string GetQuery()
        {
            return "select * from Person"; //"EXEC [dbo].[GetPersons]";
        }
    }

    public class ConfigServer
    {
        public string urlServer, databaseName, login, password;

        public ConfigServer(string urlServer, string databaseName, string login, string password)
        {
            this.urlServer = urlServer;
            this.databaseName = databaseName;
            this.login = login;
            this.password = password;
        }
    }
}
