using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNetwork
{
    class CustomConnection
    {
        private TimeSpan timePlanningStart, timeFactStart;
        private SqlConnection connection;
        private string connectionString, query;
        private ModelTimeConnection resultObj;
        Stopwatch stopwatch;

        public CustomConnection(TimeSpan timePlanningStart)
        {
            this.timePlanningStart = timePlanningStart;
            stopwatch = new Stopwatch();

            //получаем строку подключения и запрос из конфига
            connectionString = Config.GenerateConnectionString();
            query = Config.GetQuery();

            resultObj = new ModelTimeConnection();
            resultObj.timePlanningStart = timePlanningStart;

            stopwatch.Start();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.StatisticsEnabled = true;
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    stopwatch.Stop();
                    resultObj.timeFactStart = DateTime.Now.TimeOfDay;
                    resultObj.countRowsResult = command.ExecuteNonQuery();
                }
                catch (Exception exp)
                {
                    resultObj.countRowsResult = -1;
                    resultObj.errorText = exp.Message;
                }
                finally
                {
                    connection.Close();

                    var statistic = connection.RetrieveStatistics();
                    double connectionTime = 0;
                    //Double.TryParse(statistic["ConnectionTime"].ToString(), out connectionTime);

                    resultObj.durationConnection = stopwatch.Elapsed.TotalMilliseconds; //connectionTime;
                }
            }
        }

        public ModelTimeConnection GetResult()
        {
            return resultObj;
        }
    }

    public class ModelTimeConnection
    {
        public TimeSpan timePlanningStart { get; set; }
        public TimeSpan timeFactStart { get; set; }
        public int countRowsResult { get; set; }
        public string errorText { get; set; }
        public double durationConnection { get; set; }
    }
}
