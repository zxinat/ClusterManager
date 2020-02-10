using ClusterManager.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClusterManager.Dto.Infrastructures
{
    public interface ISubscriptionDto
    {
        Task<List<SubscriptionModel>> GetSubscriptions(string access_token);
    }
}
