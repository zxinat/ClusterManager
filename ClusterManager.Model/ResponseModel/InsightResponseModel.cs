using System;
using System.Collections.Generic;
using System.Text;

namespace ClusterManager.Model.ResponseModel
{
    public class InsightResponseModel
    {
        public int cost { get; set; }
        public string timespan { get; set; }
        public string interval { get; set; }
        public List<Value> value { get; set; }
        
    }
    public class Value
    {
        public string id { get; set; }
        public string type { get; set; }
        public name name { get; set; }
        public string displayDescription { get; set; }
        public string unit { get; set; }
        public List<timeseries> timeseries { get; set; }
        public string errorCode { get; set; }
        
    }
    public class name
    {
        public string value { get; set; }
        public string localizedValue { get; set; }
    }
    public class timeseries
    {
        public List<data> data { get; set; }
    }
    

    public class data
    {
        public string timeStamp { get; set; }
        public float total { get; set; }
        public float average { get; set; }
        public float minimum { get; set; }
        public float maximum { get; set; }
    }
}
