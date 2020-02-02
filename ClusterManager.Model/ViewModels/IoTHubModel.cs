using System;
using System.Collections.Generic;
using System.Text;

namespace ClusterManager.Model.ViewModels
{
    public class IoTHubModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public string resourceGroupName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Model.Sku sku { get; set; }
    }
    /*public class Sku
    {
        /// <summary>
        /// S1
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Standard
        /// </summary>
        public string tier { get; set; }
        /// <summary>
        /// 1
        /// </summary>
        public int capacity { get; set; }
    }*/
}
