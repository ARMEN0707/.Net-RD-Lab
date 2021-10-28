using System;


namespace Histogram.Models
{
    public class HistogramColumn
    {
        public string Label { get; set; }
        public long Time { get; set; }

        public HistogramColumn(string label, long time)
        {
            Label = label;
            Time = time;
        }
    }
}
