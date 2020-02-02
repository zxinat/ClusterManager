using System;
using System.Collections.Generic;
using System.Text;

namespace ClusterManager.Model
{
    public class Tags
    {
    }

    public class Events_
    {
        /// <summary>
        /// 
        /// </summary>
        public string None { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Connections { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DeviceTelemetry { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string C2DCommands { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DeviceIdentityOperations { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FileUploadOperations { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Routes { get; set; }
    }

    public class OperationsMonitoringProperties
    {
        /// <summary>
        /// 
        /// </summary>
        public Events_ events { get; set; }
    }

    public class Events
    {
        /// <summary>
        /// 
        /// </summary>
        public int retentionTimeInDays { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int partitionCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> partitionIds { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string endpoint { get; set; }
    }

    public class OperationsMonitoringEvents
    {
        /// <summary>
        /// 
        /// </summary>
        public int retentionTimeInDays { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int partitionCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> partitionIds { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string endpoint { get; set; }
    }

    public class EventHubEndpoints
    {
        /// <summary>
        /// 
        /// </summary>
        public Events_ events { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public OperationsMonitoringEvents operationsMonitoringEvents { get; set; }
    }

    public class Endpoints
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> serviceBusQueues { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> serviceBusTopics { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> eventHubs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> storageContainers { get; set; }
    }

    public class FallbackRoute
    {
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string source { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string condition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> endpointNames { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isEnabled { get; set; }
    }

    public class Routing
    {
        /// <summary>
        /// 
        /// </summary>
        public Endpoints endpoints { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> routes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FallbackRoute fallbackRoute { get; set; }
    }

    public class _default
    {
    /// <summary>
    /// 
    /// </summary>
        public string sasTtlAsIso8601 { get; set; }
    /// <summary>
    /// 
    /// </summary>
        public string connectionString { get; set; }
    /// <summary>
    /// 
    /// </summary>
        public string containerName { get; set; }
    }

    public class StorageEndpoints
    {
    /// <summary>
    /// 
    /// </summary>
        public _default Default { get; set; }
    }

    public class FileNotifications
{
    /// <summary>
    /// 
    /// </summary>
    public string lockDurationAsIso8601 { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string ttlAsIso8601 { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int maxDeliveryCount { get; set; }
}

    public class MessagingEndpoints
{
    /// <summary>
    /// 
    /// </summary>
    public FileNotifications fileNotifications { get; set; }
}

    public class Feedback
{
    /// <summary>
    /// 
    /// </summary>
    public string lockDurationAsIso8601 { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string ttlAsIso8601 { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int maxDeliveryCount { get; set; }
}

    public class CloudToDevice
{
    /// <summary>
    /// 
    /// </summary>
    public int maxDeliveryCount { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string defaultTtlAsIso8601 { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Feedback feedback { get; set; }
}

    public class Properties
{
    /// <summary>
    /// 
    /// </summary>
    public OperationsMonitoringProperties operationsMonitoringProperties { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string state { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string provisioningState { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<string> ipFilterRules { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string hostName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public EventHubEndpoints eventHubEndpoints { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Routing routing { get; set; }
    /// <summary>
    /// 
    /// </summary>
    //public StorageEndpoints storageEndpoints { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public MessagingEndpoints messagingEndpoints { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string enableFileUploadNotifications { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public CloudToDevice cloudToDevice { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string features { get; set; }
    }

    public class Sku
    {
    /// <summary>
    /// 
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string tier { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int capacity { get; set; }
    }

    public class IoTHubInfoModel
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
    public string type { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string location { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Tags tags { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string subscriptionid { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string resourcegroup { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string etag { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Properties properties { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Sku sku { get; set; }
}
}