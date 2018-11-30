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
            for(int i=0; i<lambda; i++)
            {
                var itemTime = times.ElementAt(i);
                if (i == 0)
                {
                    Task.Run(() => {
                        CustomConnection connection = new CustomConnection(itemTime);
                        tasks.Add(connection);
                    });
                }
                else
                {
                    Task.Run(async () => {
                        await Task.Delay(delta);
                        CustomConnection connection = new CustomConnection(itemTime);
                        tasks.Add(connection);
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
    }
}
