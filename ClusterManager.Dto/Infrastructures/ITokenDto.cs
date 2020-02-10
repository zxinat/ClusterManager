using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ClusterManager.Model;

namespace ClusterManager.Dto.Infrastructures
{
    public interface ITokenDto
    {
        //获取Token
        // List<TokenModel> GetToken(string tenantId);
        Task<TokenModel> GetToken(string email);
    }
}
