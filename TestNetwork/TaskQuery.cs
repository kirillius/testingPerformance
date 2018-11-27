using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestNetwork
{
    class TaskQuery
    {
        string query, error;
        int result;
        public string queryId;
        public int numQuery;
        Stopwatch stopwatch;
        Stopwatch stopwatchParsing;
        List<objectsModel> items;
        System.Collections.IDictionary statistic;
        DataGridViewRow row;
        public static bool startParsing;

        //значения времени
        public double timeAll {get;set;}
        public double allTimeSql { get; set; }
        public double parsingTime { get; set; }
        public double sizeDataMain { get; set; }
        public double timeNetwork { get; set; }
        public double timeNetworkCalculate { get; set; }
        public DateTime timeStartParsing { get; set; }
        public int countItems { get; set; }

        public TaskQuery()
        {
            stopwatch = new Stopwatch();
            stopwatchParsing = new Stopwatch();
            result = -1;
            queryId = RandomString(5);
        }

        public void startWach()
        {
            stopwatch.Start();
        }

        public void stopWatch()
        {
            stopwatch.Stop();
        }

        public void startWachParsing()
        {
            timeStartParsing = DateTime.Now;
            stopwatchParsing.Start();
        }

        public void stopWatchParsing()
        {
            stopwatchParsing.Stop();
        }

        public void setRow(DataGridViewRow row)
        {
            this.row = row;
        }

        public DataGridViewRow getRow()
        {
            return this.row;
        }

        public void setResult(int result, int countItems, System.Collections.IDictionary statistic, string error)
        {
            this.result = result;
            this.error = error;
            //this.items = items;
            this.countItems = countItems;
            this.statistic = statistic;

            getTime();
        }

        public int getResult()
        {
            return result;
        }

        public string getError()
        {
            return error;
        }

        public void getTime() //Dictionary<string, string>
        {
            if (statistic == null)
                return;

            TimeSpan ts = stopwatch.Elapsed;
            //double networkTime = 0;
            //Double.TryParse(statistic["NetworkServerTime"].ToString(), out networkTime);

            /*Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("timeAll", String.Format("{0:00}", ts.TotalMilliseconds));
            result.Add("allTimeSql", statistic["ExecutionTime"].ToString());
            //result.Add("timeExecuteRequest", String.Format("{0:00}", (ts.TotalMilliseconds-networkTime-stopwatchParsing.Elapsed.TotalMilliseconds)));
            //result.Add("timeNetwork", networkTime.ToString());
            result.Add("parsingTime", String.Format("{0:00}", stopwatchParsing.Elapsed.TotalMilliseconds));
            result.Add("sizeData", statistic["BytesReceived"].ToString());*/

            double sizeData = 0;
            Double.TryParse(statistic["BytesReceived"].ToString(), out sizeData);
            timeNetworkCalculate = getNetworkTime(sizeData);
            timeNetwork = ts.TotalMilliseconds - stopwatchParsing.Elapsed.TotalMilliseconds;

            timeAll = ts.TotalMilliseconds;

            double allTimeOut = 0;
            Double.TryParse(statistic["ExecutionTime"].ToString(), out allTimeOut);
            allTimeSql = allTimeOut;

            parsingTime = stopwatchParsing.Elapsed.TotalMilliseconds;

            double sizeDataOut = 0;
            Double.TryParse(statistic["BytesReceived"].ToString(), out sizeDataOut);
            sizeDataMain = sizeDataOut;

            //countItems = items.Count;

            //result.Add("timeNetwork", networkTime.ToString());
            //result.Add("timeNetworkCalculate", networkTimeCalculate.ToString());

            //return result;
        }

        private double getNetworkTime(double sizeData)
        {
            double capacity = 97.52;
            double sizeDataInMega = (sizeData / 1024) / 1024;
            return sizeDataInMega / capacity;
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
