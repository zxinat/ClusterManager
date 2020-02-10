using System;
using System.Collections.Generic;
using System.Text;

namespace ClusterManager.Model.ViewModels
{
    public class InsightModel
    {
        public string timespan { get; set; }
        public string interval { get; set; }
        public string metricnames { get; set; }
        public string aggregation { get; set; }
    }
}
