using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNetwork
{
    class CalculateIntervalTimeConnection
    {
        private int delay, lambda;
        private List<TimeSpan> timesStartThread;

        public CalculateIntervalTimeConnection(int lambda, int minutes)
        {
            this.lambda = lambda;
            Random rand = new Random();

            int modelTime = minutes * 60 * 1000;
            double R = Convert.ToDouble(rand.Next(100)) / 100;
            double t = (-1 * (1 / (double)lambda)) * Math.Log(R);
            delay = Convert.ToInt32(t * modelTime);

            CalculateTimeSpan();
        }

        public int GetDelay()
        {
            return delay;
        }

        private void CalculateTimeSpan()
        {
            timesStartThread = new List<TimeSpan>();
            DateTime date = DateTime.Now;

            timesStartThread.Add(date.TimeOfDay);
            for(int i=1; i<lambda; i++)
            {
                date = date.AddMilliseconds(delay);
                timesStartThread.Add(date.TimeOfDay);
            }
        }

        public List<TimeSpan> GetTimes()
        {
            return timesStartThread;
        }
    }
}
