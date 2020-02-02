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
        [BsonElement("TalentId")]
        public String TalentId { get; set; }
        [BsonElement("SubscriptionId")]
        public String SubscriptionId { get; set; }
        [BsonElement("ClientId")]
        public String ClientId { get; set; }
        [BsonElement("ClientSecret")]
        public String ClientSecret { get; set; }

    }
}
