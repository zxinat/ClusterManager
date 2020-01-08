using System;
using System.Collections.Generic;
using System.Text;
using ClusterManager;
using ClusterManager.Model;

namespace ClusterManager.IDto
{
    public interface ITokenDto
    {

        //获取Token

        List<TokenModel> GetToken(string tenantId);
    }
}
