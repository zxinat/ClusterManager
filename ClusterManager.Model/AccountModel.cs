﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClusterManager.Model
{
    public class AccountModel
    {
        public string tenantId { get; set; }
        public string resource { get; set; }
        public string subscriptionId { get; set; }
        public string clientId { get; set; }
        public string clientSecret { get; set; }
    }
}
