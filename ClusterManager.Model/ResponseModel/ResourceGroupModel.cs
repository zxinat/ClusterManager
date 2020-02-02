using System;
using System.Collections.Generic;
using System.Text;

namespace ClusterManager.Model.ResponseModel
{
    public class ResourceGroupModel
    {
        public List<ValueItem> value { get; set; }
    }
    /*public class Properties
    {
        /// <summary>
        /// 
        /// </summary>
        public string provisioningState { get; set; }
    }*/

    public class ValueItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Properties properties { get; set; }
    }
}
