using ClusterManager.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClusterManager.Core.Infrastructures
{
    public interface IAuthBus
    {
        TokenModel RequestToken(string email, string password);
    }
}
