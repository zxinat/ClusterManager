using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ClusterManager.Model;
using WebApiClient.Extensions.Autofac;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApiClient;
using ClusterManager.DI;
using Microsoft.AspNetCore.HttpOverrides;
using Swashbuckle.AspNetCore.Swagger;
using System.Net;
using Microsoft.Extensions.Configuration;
using Autofac.Configuration;
using Autofac.Extensions.DependencyInjection;
using ClusterManager.Utility;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ClusterManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.KnownProxies.Add(IPAddress.Parse("10.0.0.100"));
            });

            services.AddCors(options =>
            {

                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        //builder.WithOrigins(this.Configuration.GetSection("CorsIp")["IpAddress"])
                        builder.WithOrigins("*")
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials();
                    });
            });
            services.AddSwaggerGen(gen =>
            {
                gen.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
            services.AddAuthentication(sharedOptions =>
            {
                sharedOptions.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                sharedOptions.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            });
            /*AddAzureAd(options =>
            {
                Configuration.Bind("AzureAd", options);
                AzureAdOptions.Settings = options;
            })
            .AddCookie();*/
            services.Configure<AccountModel>(Configuration.GetSection("accountsetting"));
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));
            JwtSettings jwtSettings = new JwtSettings();
            Configuration.Bind("JwtSettings", jwtSettings);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = "http://localhost:44350",
                        ValidIssuer = "http://localhost:44350",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSettings:SecurityKey"]))
                    };
                });

            services.AddHttpClient("chinacloudapi", x =>
            {
                x.BaseAddress = new Uri("https://management.chinacloudapi.cn/subscriptions/");
                x.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
            });
            services.AddHttpClient();
            services.AddLogging();
            services.AddScoped<JWTHelper>();
            IocContainer autofac = new AutofacContainer(services);
            return autofac.Build().FetchServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseForwardedHeaders(
                new ForwardedHeadersOptions
                { ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto });
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseCors(MyAllowSpecificOrigins);
            app.UseMvc();
        }
    }
}
