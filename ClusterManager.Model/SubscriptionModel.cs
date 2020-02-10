using System;
using System.Collections.Generic;
using System.Text;

namespace ClusterManager.Model
{
    public class SubscriptionModel
    {
        public string id { get; set; }
        public string authorizationSource { get; set; }
        public string subscriptionId { get; set; }
        public string displayName { get; set; }
        public string state { get; set; }
        public subscriptionPolicies subscriptionPolicies { get; set; }
    }
    public class subscriptionPolicies
    {
        public string locationPlacementId { get; set; }
        public string quotaId { get; set; }
        public string spendingLimit { get; set; }
    }
    public class SubscriptionsModel
    {
        public List<SubscriptionModel> value { get; set; }
    }
}
