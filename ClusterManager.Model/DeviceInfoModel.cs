using System;
using System.Collections.Generic;
using System.Text;

namespace ClusterManager.Model
{
     public class DeviceInfoModel
    {
        public string deviceId { get; set; }
        public string generationId { get; set; }
        public string etag { get; set; }
        public string connectionState { get; set; }
        public string status { get; set; }
        public string statusReason { get; set; }
        public string connectionStateUpdatedTime { get; set; }
        public string statusUpdatedTime { get; set; }
        public string lastActivityTime { get; set; }
        public int cloudToDeviceMessageCount { get; set; }
        public authentication authentication { get; set; }
        public capabilities capabilities { get; set; }
        public string deviceScope { get; set; }
        
    }
    public class authentication
    {
        public symmetricKey symmetricKey { get; set; }
        public x509Thumbprint x509Thumbprint { get; set; }
        public string type { get; set; }
    }
    public class symmetricKey
    {
        public string primaryKey { get; set; }
        public string secondaryKey { get; set; }
    }
    public class x509Thumbprint
    {
        public string primaryThumbprint { get; set; }
        public string secondaryThumbprint { get; set; }
    }
    public class capabilities
    {
        public bool iotEdge { get; set; }
    }
}
