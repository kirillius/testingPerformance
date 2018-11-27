using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestNetwork
{
    public partial class testForm : Form
    {
        List<GenerateUserThread> usersThread;
        public testForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Нужно заполнить количество пользователей и количество запросов");
                return;
            }

            int countUsers = 0, countQueries = 0;
            Int32.TryParse(textBox1.Text, out countUsers);
            Int32.TryParse(textBox2.Text, out countQueries);
            usersThread = new List<GenerateUserThread>();

            for(int i=0; i<countUsers; i++)
            {
                GenerateUserThread userThread = new GenerateUserThread(countQueries);
                usersThread.Add(userThread);
                userThread.startQueriesUser();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //int numRequest = 1;
            var result = getTimeServer(Config.GetQuery()); //new ModelTimeServer();

            foreach (var user in usersThread)
            {
                DataGridViewRow currentRow = user.getRow();
                if (currentRow == null)
                {
                    int rowIndex = dataGridView1.Rows.Add(user.userId, user.countQueries, 0, 0, 0, 0, 0, 0, 0, 0);
                    currentRow = dataGridView1.Rows[rowIndex];
                    user.setRow(currentRow);
                }

                var objTimes = user.tasksQuery.Select(s => new
                {
                    timeAll = user.tasksQuery.Select(d => d.timeAll).Average(),
                    allTimeSql = user.tasksQuery.Select(d => d.allTimeSql).Average(),
                    timeExecuteRequest = result.timeExecuteRequest,
                    timeNetwork = user.tasksQuery.Select(d => d.timeNetwork).Average(),
                    timeNetworkCalculate = user.tasksQuery.Select(d => d.timeNetworkCalculate).Average(),
                    parsingTime = user.tasksQuery.Select(d => d.parsingTime).Average(),
                    sizeData = user.tasksQuery.Select(d => d.sizeDataMain).Average(),
                    timeStartParsing = s.timeStartParsing,
                    countItems = s.countItems
                }).FirstOrDefault();

                currentRow.Cells[2].Value = String.Format("{0:F3}", (objTimes.timeAll/1000));
                currentRow.Cells[3].Value = String.Format("{0:F3}", (objTimes.allTimeSql/1000));
                currentRow.Cells[4].Value = String.Format("{0:F3}", ((objTimes.timeExecuteRequest/1000)/1000));
                currentRow.Cells[5].Value = String.Format("{0:F3}", (objTimes.timeNetwork/1000));
                currentRow.Cells[6].Value = String.Format("{0:F3}", objTimes.timeNetworkCalculate);
                currentRow.Cells[7].Value = String.Format("{0:F3}", (objTimes.parsingTime/1000));
                currentRow.Cells[8].Value = String.Format("{0:F3}", (objTimes.sizeData/1024)/1024);
                currentRow.Cells[9].Value = String.Format("{0:O}", objTimes.timeStartParsing);
                currentRow.Cells[10].Value = String.Format("{0}", objTimes.countItems);
            }

            this.Height = 465;
        }

        private ModelTimeServer getTimeServer(string queryTest)
        {
            string connectionString = Config.GenerateConnectionStringServer();
            var result = new ModelTimeServer();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "select avg(Duration) as timeExecuteRequest from simple where EventClass=12 and ApplicationName=N'.Net SqlClient Data Provider' and CONVERT(NVARCHAR(MAX), TextData) = N'"+queryTest+"'";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = null;
                try
                {
                    connection.Open();
                    reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        var r = Serialize(reader);
                        foreach (var row in r)
                        {
                            string json = JsonConvert.SerializeObject(row, Formatting.Indented);
                            result = JsonConvert.DeserializeObject<ModelTimeServer>(json);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
                finally
                {
                    // Always call Close when done reading.
                    if (reader != null)
                        reader.Close();

                    connection.Close();
                }
            }

            return result;
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

    public class ModelTimeServer
    {
        public double timeExecuteRequest { get; set; }
    }
}
