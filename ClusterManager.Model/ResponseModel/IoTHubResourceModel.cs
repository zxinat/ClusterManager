using System;
using System.Collections.Generic;
using System.Text;

namespace ClusterManager.Model.ResponseModel
{
    /*public class Sku
    {
        /// <summary>
        /// F1
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Free
        /// </summary>
        public string tier { get; set; }
        /// <summary>
        /// Capacity
        /// </summary>
        public int capacity { get; set; }
    }*/

    /*public class Value
    {
        /// <summary>
        /// /subscriptions/6273fbea-8a11-498b-8218-02b6f4398e12/resourceGroups/zengyxsource/providers/Microsoft.Devices/IotHubs/testzengyxiot
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// testzengyxiot
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Microsoft.Devices/IotHubs
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// chinaeast
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// Tags
        /// </summary>
        public string subscriptionid { get; set; }
        /// <summary>
        /// zengyxsource
        /// </summary>
        public string resourcegroup { get; set; }
        /// <summary>
        /// AAAAAADAo38=
        /// </summary>
        public string etag { get; set; }
        /// <summary>
        /// Properties
        /// </summary>
        public Sku sku { get; set; }
    }*/

    public class IoTHubResourceModel
    {
        /// <summary>
        /// Value
        /// </summary>
        public List<IoTHubInfoModel> value { get; set; }
    }
    /*public class OperationsMonitoringEvents
    {
        /// <summary>
        /// RetentionTimeInDays
        /// </summary>
        public int retentionTimeInDays { get; set; }
        /// <summary>
        /// PartitionCount
        /// </summary>
        public int partitionCount { get; set; }
        /// <summary>
        /// PartitionIds
        /// </summary>
        public List<string> partitionIds { get; set; }
        /// <summary>
        /// iothub-ehub-testzengyx-88010-97fc268c59
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// sb://ihsumcprodshres014dednamespace.servicebus.chinacloudapi.cn/
        /// </summary>
        public string endpoint { get; set; }
    }*/

    /*public class Endpoints
    {
        /// <summary>
        /// ServiceBusQueues
        /// </summary>
        public List<string> serviceBusQueues { get; set; }
        /// <summary>
        /// ServiceBusTopics
        /// </summary>
        public List<string> serviceBusTopics { get; set; }
        /// <summary>
        /// EventHubs
        /// </summary>
        public List<string> eventHubs { get; set; }
        /// <summary>
        /// StorageContainers
        /// </summary>
        public List<string> storageContainers { get; set; }
    }*/

    /*public class FallbackRoute
    {
        /// <summary>
        /// $fallback
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// DeviceMessages
        /// </summary>
        public string source { get; set; }
        /// <summary>
        /// true
        /// </summary>
        public string condition { get; set; }
        /// <summary>
        /// EndpointNames
        /// </summary>
        public List<string> endpointNames { get; set; }
        /// <summary>
        /// IsEnabled
        /// </summary>
        public bool isEnabled { get; set; }
    }*/

    /*public class Routing
    {
        /// <summary>
        /// Endpoints
        /// </summary>
        public Endpoints endpoints { get; set; }
        /// <summary>
        /// Routes
        /// </summary>
        public List<string> routes { get; set; }
        /// <summary>
        /// FallbackRoute
        /// </summary>
        public FallbackRoute fallbackRoute { get; set; }
    }*/

    /*public class _default
    {
        /// <summary>
        /// PT1H
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
    }*/

    /*public class StorageEndpoints
    {
        /// <summary>
        /// _default
        /// </summary>
        public _default _default { get; set; }
    }*/

    /*public class FileNotifications
    {
        /// <summary>
        /// PT1M
        /// </summary>
        public string lockDurationAsIso8601 { get; set; }
        /// <summary>
        /// PT1H
        /// </summary>
        public string ttlAsIso8601 { get; set; }
        /// <summary>
        /// MaxDeliveryCount
        /// </summary>
        public int maxDeliveryCount { get; set; }
    }*/

    /*public class MessagingEndpoints
    {
        /// <summary>
        /// FileNotifications
        /// </summary>
        public FileNotifications fileNotifications { get; set; }
    }*/

    /*public class Feedback
    {
        /// <summary>
        /// PT1M
        /// </summary>
        public string lockDurationAsIso8601 { get; set; }
        /// <summary>
        /// PT1H
        /// </summary>
        public string ttlAsIso8601 { get; set; }
        /// <summary>
        /// MaxDeliveryCount
        /// </summary>
        public int maxDeliveryCount { get; set; }
    }*/

    /*public class CloudToDevice
    {
        /// <summary>
        /// MaxDeliveryCount
        /// </summary>
        public int maxDeliveryCount { get; set; }
        /// <summary>
        /// PT3H
        /// </summary>
        public string defaultTtlAsIso8601 { get; set; }
        /// <summary>
        /// Feedback
        /// </summary>
        public Feedback feedback { get; set; }
    }*/

    


}
