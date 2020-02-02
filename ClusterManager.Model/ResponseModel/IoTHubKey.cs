using System;
using System.Collections.Generic;
using System.Text;

namespace ClusterManager.Model.ResponseModel
{
    public class IoTHubKey
    {
        /// <summary>
        /// 
        /// </summary>
        public string keyName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string primaryKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string secondaryKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string rights { get; set; }
    }
    public class IoTHubKeys
    {
        public List<IoTHubKey> value { get; set; }
    }

}
