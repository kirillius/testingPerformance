using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNetwork
{
    class AnalysisResults
    {
        public List<CustomConnection> list;
        public AnalysisResults(List<CustomConnection> list)
        {
            this.list = list;
        }

        public ModelResultAnalisys analyze()
        {
            ModelResultAnalisys result = new ModelResultAnalisys()
            {
                countSuccessQueries = 0,
                countErrorQueries = 0,
                countSuccessTimeStart = 0,
                countWrongTimeStart = 0,
                countNotStart = 0,
                avgDuration = 0,
                avgWaiting = 0
            };

            foreach(var item in list)
            {
                if ((item.GetResult().errorText == null || item.GetResult().errorText.Equals("")) & item.GetResult().durationConnection > 0)
                    result.countSuccessQueries++;
                else if (item.GetResult().durationConnection > 0)
                    result.countErrorQueries++;
                else
                    result.countNotStart++;

                if (item.GetResult().timeFactStart <= item.GetResult().timePlanningStart)
                    result.countSuccessTimeStart++;
                else
                    result.countWrongTimeStart++;
            }

            result.avgDuration = list.Average(s => s.GetResult().durationConnection);
            result.avgWaiting = list.Average(s => s.GetResult().waitingTime);

            return result;
        }
    }

    public class ModelResultAnalisys
    {
        public int countSuccessQueries { get; set; }
        public int countErrorQueries { get; set; }
        public int countSuccessTimeStart { get; set; }
        public int countWrongTimeStart { get; set; }
        public int countNotStart { get; set; }
        public double avgDuration { get; set; }
        public double avgWaiting { get; set; }
    }
}
