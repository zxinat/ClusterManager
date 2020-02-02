using ClusterManager.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClusterManager.Dao.Infrastructures
{
    public interface IAccountDao
    {
        object CreateUser(string email, string pwd);
        AccountModel GetUserByEmail(string email);
        bool UserIsExist(string email);
    }
}
