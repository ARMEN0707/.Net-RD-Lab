using System;


namespace Histogram.Models
{
    public class ColumnHistogram
    {
        public string Label { get; set; }
        public long Time { get; set; }

        public ColumnHistogram(string label, long time)
        {
            Label = label;
            Time = time;
        }
    }
}
