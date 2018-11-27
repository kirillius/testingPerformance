using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestNetwork
{
    class GenerateUserThread
    {
        public int userId, countQueries;
        string connectionString, query;
        public List<TaskQuery> tasksQuery;
        DataGridViewRow row;

        public void setRow(DataGridViewRow row)
        {
            this.row = row;
        }

        public DataGridViewRow getRow()
        {
            return this.row;
        }

        public GenerateUserThread(int countQueries)
        {
            this.countQueries = countQueries;
            userId = new Random().Next();
            connectionString = Config.GenerateConnectionString();
            query = Config.GetQuery(); //"select * from objects";
            tasksQuery = new List<TaskQuery>();
        }

        public void startQueriesUser()
        {
            for(var i=0; i<countQueries; i++)
            {
                Task.Run(() => {
                    TaskQuery queryObj = new TaskQuery();
                    tasksQuery.Add(queryObj);
                    queryObj.startWach();
                    sendQuery(queryObj);
                });
            }
        }

        private void sendQuery(TaskQuery obj)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.StatisticsEnabled = true;
                int result = 1;
                string error = null;
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = null;
                List<objectsModel> items = new List<objectsModel>();
                try
                {
                    connection.Open();
                    var currentObj = tasksQuery.Where(p => p.queryId == obj.queryId).FirstOrDefault();

                    if (tasksQuery.IndexOf(currentObj)==0)
                    {
                        reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            obj.startWachParsing();
                            var r = Serialize(reader);
                            foreach (var row in r)
                            {
                                string json = JsonConvert.SerializeObject(row, Formatting.Indented);
                                var objectItem = JsonConvert.DeserializeObject<objectsModel>(json);
                                items.Add(objectItem);
                            }

                            obj.stopWatchParsing();
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                    }
                }
                catch (Exception exp)
                {
                    result = 0;
                    error = exp.Message;
                }
                finally
                {
                    // Always call Close when done reading.
                    if (reader != null)
                        reader.Close();

                    connection.Close();
                    obj.stopWatch();
                    int countItems = items.Count;
                    items = null;
                    obj.setResult(result, countItems, connection.RetrieveStatistics(), error);
                }
            }
        }

        private IEnumerable<Dictionary<string, object>> Serialize(SqlDataReader reader)
        {
            var results = new List<Dictionary<string, object>>();
            var cols = new List<string>();
            for (var i = 0; i < reader.FieldCount; i++)
                cols.Add(reader.GetName(i));

            while (reader.Read())
                results.Add(SerializeRow(cols, reader));

            return results;
        }
        private Dictionary<string, object> SerializeRow(IEnumerable<string> cols, SqlDataReader reader)
        {
            var result = new Dictionary<string, object>();
            foreach (var col in cols)
                result.Add(col, reader[col]);
            return result;
        }
    }
}
