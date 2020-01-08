using System;
using System.Collections.Generic;
using System.Text;
using ClusterManager.Model;

namespace ClusterManager.IDto
{
    public interface IIoTHubResourceDto
    {
        string ListBySubId(string SubId);
    }
}
