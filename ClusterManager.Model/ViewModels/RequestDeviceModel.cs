using System;
using System.Collections.Generic;
using System.Text;

namespace ClusterManager.Model.ViewModels
{
    public class RequestDeviceModel
    {
    /// <summary>
    /// 
    /// </summary>
        public string apiVersion { get; set; }
    /// <summary>
    /// 
    /// </summary>
        public string authorizationPolicyKey { get; set; }
        public string etag { get; set; }
    /// <summary>
    /// 
    /// </summary>
        public string authorizationPolicyName { get; set; }
    /// <summary>
    /// 
    /// </summary>
        public string hostName { get; set; }
    /// <summary>
    /// 
    /// </summary>
        public string requestBody { get; set; }
    /// <summary>
    /// 
    /// </summary>
        public string requestPath { get; set; }
    }
}
