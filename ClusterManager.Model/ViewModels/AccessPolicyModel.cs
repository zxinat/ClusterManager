using System;
using System.Collections.Generic;
using System.Text;

namespace ClusterManager.Model.ViewModels
{
    public class AccessPolicyModel
    {
        //public string DeviceId { get; set; }
        public string HostName { get; set; }
        public string SharedAccessKeyName { get; set; }
        public string SharedAccessKey { get; set; }
    }
}
