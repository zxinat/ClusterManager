using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using ClusterManager.DI;
using ClusterManager.Dao.Infrastructures;
using ClusterManager.Dto.Infrastructures;
using ClusterManager.Utility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;

namespace ClusterManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            //AuthResponse.GetAuthorizationResponse();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseIISIntegration()
            .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>();
    }
}
