using Autofac;
using ClusterManager.Dto;
using ClusterManager.Dto.Infrastructures;
using ClusterManager.Dao.Infrastructures;
using ClusterManager.Dao;
using ClusterManager.Core;
using ClusterManager.Core.Infrastructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClusterManager.DI
{
    internal sealed class RegisterModel:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IoTHubResourceDto>().As<IIoTHubResourceDto>();
            builder.RegisterType<TokenDto>().As<ITokenDto>();
            builder.RegisterType<ResourceGroupDto>().As<IResourceGroupDto>();
            //builder.RegisterType<TokenDao>().As<ITokenDao>();
            //Bus-IBus
            builder.RegisterType<IoTHubResourceBus>().As<IIoTHubResourceBus>();
            builder.RegisterType<ResourceGroupBus>().As<IResourceGroupBus>();
            //base.Load(builder);
        }
    }
}
