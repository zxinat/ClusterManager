using System;
using System.Collections.Generic;
using System.Text;

namespace ClusterManager.Core.Infrastructures
{
    public interface IAccountBus
    {
        object CreateUser(string email, string pwd);
        object Login(string email, string pwd);
    }
}
