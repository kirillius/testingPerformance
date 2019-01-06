using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestNetwork
{
    public partial class TestConnectionForm : Form
    {
        List<CustomConnection> tasks;
        int delta;
        DateTime endExperiments;
        public static List<int> successQueriesList = new List<int>();

        public TestConnectionForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            endExperiments = DateTime.Now.AddMinutes(Int32.Parse(textBox2.Text));
            timer1.Start();
            label3.Text = "До конца эксперимента осталось: " + textBox2.Text + " мин.";
            label3.Visible = true;
            int lambda = Int32.Parse(textBox1.Text);
            CalculateIntervalTimeConnection objCalculate = new CalculateIntervalTimeConnection(lambda, Int32.Parse(textBox2.Text));
            delta = objCalculate.GetDelay();
            Console.WriteLine("Интервал: {0}", String.Format("{0}", delta));

            List<TimeSpan> times = objCalculate.GetTimes();
            Console.WriteLine("Количество: {0}", times.Count.ToString());
            /*int i = 1;
            this.Height = 661;
            foreach (var item in times)
            {
                //var result = item.GetResult();
                dataGridView2.Rows.Add(i, item.ToString("hh':'mm':'ss'.'fff"),
                    "", 0,
                    "");
                i++;
            }*/
            Dictionary<string, bool> paramsConnection = new Dictionary<string, bool>()
            {
                {"pooling", cbPooling.Checked},
                {"query", rbQuery.Checked }
            };
            for(int i=0; i<lambda; i++)
            {
                var itemTime = times.ElementAt(i);
                if (i == 0)
                {
                    Task.Run(() => {
                        CustomConnection connection = new CustomConnection(itemTime, paramsConnection);
                        tasks.Add(connection);
                        connection.startConnection();
                    });
                }
                else
                {
                    Task.Run(() => {
                        CustomConnection connection = new CustomConnection(itemTime, paramsConnection);
                        tasks.Add(connection);

                        if(cbDelta.Checked)
                            Task.Delay(delta);

                        connection.startConnection();
                    });
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*this.Height = 451;
            int i = 1;
            foreach(var item in tasks)
            {
                var result = item.GetResult();
                dataGridView1.Rows.Add(i, result.timePlanningStart.ToString("hh':'mm':'ss'.'fff"), 
                    result.timeFactStart.ToString("hh':'mm':'ss'.'fff"), result.durationConnection, 
                    ((result.errorText!=null) ? result.errorText.ToString() : "Нет ошибок"));
                i++;
            }*/
            ExcelExport export = new ExcelExport(tasks);
            int result = export.Export();
            string exportMessage = (result == 1) ? "Экспорт успешно завершен" : "Экспорт завершен с ошибками, подробности в логе";
            MessageBox.Show(exportMessage);
        }

        private void TestConnectionForm_Load(object sender, EventArgs e)
        {
            tasks = new List<CustomConnection>();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lCountSuccessQueries.Text = String.Format("Завершено {0} из {1} запросов", successQueriesList.Count, textBox1.Text);
            if(!lCountSuccessQueries.Visible)
                lCountSuccessQueries.Visible = true;

            DateTime now = DateTime.Now;
            TimeSpan diff = endExperiments - now;

            if (diff.Minutes<=0 & diff.Seconds<=0)
            {
                label3.Text = "Эксперимент завершен";
                timer1.Stop();
                return;
            }

            
            label3.Text = String.Format("До конца эксперимента осталось: {0}:{1}", diff.Minutes, diff.Seconds);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AnalysisResults result = new AnalysisResults(tasks);
            var resultAnalyze = result.analyze();

            this.Height = 661;
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();

            dataGridView1.Rows.Add(resultAnalyze.countSuccessQueries, resultAnalyze.countErrorQueries, 
                resultAnalyze.countSuccessTimeStart, resultAnalyze.countWrongTimeStart, resultAnalyze.countNotStart, 
                resultAnalyze.avgDuration, resultAnalyze.avgWaiting);

            int i = 1;
            var listForGrid = new List<ModelGrid>();
            foreach (var item in tasks)
            {
                var resultRow = item.GetResult();
                var objList = new ModelGrid()
                {
                    nomRow = i,
                    timePlanningStart = resultRow.timePlanningStart.ToString("hh':'mm':'ss'.'fff"),
                    timeFactStart = resultRow.timeFactStart.ToString("hh':'mm':'ss'.'fff"),
                    durationConnection = resultRow.durationConnection,
                    waitingTime = resultRow.waitingTime,
                    errorText = (resultRow.errorText != null) ? resultRow.errorText.ToString() : ""
                };
                listForGrid.Add(objList);
                i++;
            }

            foreach(var item in listForGrid.OrderByDescending(s=>s.durationConnection))
            {
                dataGridView2.Rows.Add(item.nomRow, item.timePlanningStart, item.timeFactStart, item.waitingTime, item.durationConnection,
                    item.errorText);
            }
        }

        class ModelGrid
        {
            public int nomRow { get; set; }
            public string timePlanningStart { get; set; }
            public string timeFactStart { get; set; }
            public double durationConnection { get; set; }
            public double waitingTime {get;set;}
            public string errorText { get; set; }
        }
    }
}
