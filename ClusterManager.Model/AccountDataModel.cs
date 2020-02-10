using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ClusterManager.Model
{
    public class AccountDataModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }
        [BsonElement("Email")]
        public String Email { get; set; }
        [BsonElement("Password")]
        public String Password { get; set; }
        [BsonElement("ServicePrinciples")]
        public List<ServicePrinciple> servicePrinciples { get; set; }

    }
    public class ServicePrinciple
    {
        public bool flag { get; set; }
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
    /*public class Client
    {
        [BsonElement("ClientId")]
        public string ClientId { get; set; }
        [BsonElement("ClientSecret")]
        public string ClientSecret { get; set; }
    }
    /*public class Tenant
    {
        [BsonElement("TenantId")]
        public string TenantId { get; set; }
        public List<Client> clients { get; set; }
    }*/
}
