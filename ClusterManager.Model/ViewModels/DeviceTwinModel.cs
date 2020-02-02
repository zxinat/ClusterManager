using ClusterManager.Model.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClusterManager.Model.ViewModels
{
    public class X509Thumbprint
    {
        /// <summary>
        /// 
        /// </summary>
        public string primaryThumbprint { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string secondaryThumbprint { get; set; }
    }

    public class Desired
    {
    /// <summary>
    /// 
    /// </summary>
        public metadata metadata { get; set; }
/// <summary>
/// 
/// </summary>
        [JsonProperty("$version")]
        public int version { get; set; }
    }
    [JsonObject("$metadata")]
    public class metadata
    {
    /// <summary>
    /// 
    /// </summary>
        [JsonProperty("$lastUpdated")]
        public string lastUpdated { get; set; }
    }

    public class Reported
    {
    /// <summary>
    /// 
    /// </summary>
        public metadata metadata { get; set; }
/// <summary>
/// 
/// </summary>
        [JsonProperty("$version")]
        public int version { get; set; }
    }

    public class Properties
    {
    /// <summary>
    /// 
    /// </summary>
        public Desired desired { get; set; }
    /// <summary>
    /// 
    /// </summary>
        public Reported reported { get; set; }
    }

    public class Capabilities
    {
    /// <summary>
    /// 
    /// </summary>
        public string iotEdge { get; set; }
    }

    public class DeviceTwinModel
    {
    /// <summary>
    /// 
    /// </summary>
        public string deviceId { get; set; }
    /// <summary>
    /// 
    /// </summary>
        public string etag { get; set; }
    /// <summary>
    /// 
    /// </summary>
        public string deviceEtag { get; set; }
    /// <summary>
    /// 
    /// </summary>
        public string status { get; set; }
    /// <summary>
    /// 
    /// </summary>
        public string statusUpdateTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
        public string connectionState { get; set; }
    /// <summary>
    /// 
    /// </summary>
        public string lastActivityTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
        public int cloudToDeviceMessageCount { get; set; }
    /// <summary>
    /// 
    /// </summary>
        public string authenticationType { get; set; }
    /// <summary>
    /// 
    /// </summary>
        public X509Thumbprint x509Thumbprint { get; set; }
    /// <summary>
    /// 
    /// </summary>
        public int version { get; set; }
    /// <summary>
    /// 
    /// </summary>
        public Properties properties { get; set; }
    /// <summary>
    /// 
    /// </summary>
        public Capabilities capabilities { get; set; }
    }
}
