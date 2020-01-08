using System;
using System.Collections.Generic;
using System.Text;
using ClusterManager.Dao.Infrastructures;
using ClusterManager.Model;
using MongoDB.Driver;
using ClusterManager.Utility;
using MongoDB.Driver.Linq;

namespace ClusterManager.Dao
{
     public class TokenDao:ITokenDao
    {
        public TokenDao()
        {
            var client = new MongoClient(Constant.getMongoDBConnectString());
            var database = client.GetDatabase("clustermanager");
        }
        public string Create(TokenModel tokenModel)
        {
            throw new NotImplementedException();
        }

        public string Update(int id, TokenModel tokenModel)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TokenModel GetLatestToken()
        {
            throw new NotImplementedException();
        }
    }
}
