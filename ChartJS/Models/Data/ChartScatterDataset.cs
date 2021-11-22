﻿using System.Collections.Generic;

namespace Wesley.ChartJS.Models
{
    public class ChartScatterDataset : IChartDataset
    {
        public string type { get; set; }
        public string label { get; set; }
        public int? order { get; set; }
        public IEnumerable<ChartScatterDataPoint> data { get; set; }
        public string backgroundColor { get; set; }
    }
}
