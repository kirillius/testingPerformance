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
        private int id;
        Stopwatch stopwatch;

        public CustomConnection(TimeSpan timePlanningStart, Dictionary<string, bool> paramsConnection)
        {
            this.timePlanningStart = timePlanningStart;
            stopwatch = new Stopwatch();

            //получаем строку подключения и запрос из конфига
            Config.SetParamsConfig(paramsConnection);
            connectionString = Config.GenerateConnectionString();
            query = Config.GetQuery();

            //Console.WriteLine("Строка подключения: {0}\nЗапрос: {1}", connectionString, query);

            resultObj = new ModelTimeConnection();
            resultObj.timePlanningStart = timePlanningStart;

            Random rnd = new Random();
            id = rnd.Next(0, 90000000);
        }

        public void startConnection()
        {
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
                    resultObj.errorText = "";
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
                    //double connectionTime = 0;
                    //Double.TryParse(statistic["ConnectionTime"].ToString(), out connectionTime);

                    resultObj.durationConnection = stopwatch.Elapsed.TotalMilliseconds; //connectionTime;
                    resultObj.waitingTime = ((resultObj.timeFactStart - resultObj.timePlanningStart).TotalMilliseconds>0) ? (resultObj.timeFactStart - resultObj.timePlanningStart).TotalMilliseconds : 0;
                    TestConnectionForm.successQueriesList.Add(id);
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
        public double waitingTime { get; set; }
    }
}
