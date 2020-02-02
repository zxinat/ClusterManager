using System;
using System.Collections.Generic;
using Autofac.Extensions.DependencyInjection;
using System.Text;
namespace ClusterManager.DI
{
    public interface IocContainer
    {
        IocContainer Build();
        AutofacServiceProvider FetchServiceProvider();
    }
}
