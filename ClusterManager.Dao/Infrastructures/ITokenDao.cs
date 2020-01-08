using System;
using System.Collections.Generic;
using System.Text;
using ClusterManager.Model;

namespace ClusterManager.Dao.Infrastructures
{
    public interface ITokenDao
    {
        string Create(TokenModel tokenModel);
        string Update(int id, TokenModel tokenModel);
        string Delete(int id);
        TokenModel GetLatestToken();

    }
}
