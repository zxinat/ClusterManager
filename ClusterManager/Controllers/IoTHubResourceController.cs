using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClusterManager.Core;
using System.Net;
using ClusterManager.Core.Infrastructures;
using ClusterManager.Model;
using ClusterManager.DI;
using ClusterManager.Dto;
using ClusterManager.Model.ResponseModel;
using ClusterManager.Model.ViewModels;
using Newtonsoft.Json;

namespace ClusterManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IoTHubResourceController : ControllerBase
    {
        private readonly IIoTHubResourceBus _ioTHubResourceBus;
        public IoTHubResourceController(IIoTHubResourceBus ioTHubResourceBus)
        {
            this._ioTHubResourceBus = ioTHubResourceBus;
        }
        [HttpGet("ListBySubId")]
        public Task<string> ListBySubId(string SubId)


        {
            //SubId = "6273fbea-8a11-498b-8218-02b6f4398e12";
            //Token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6InpqZ3V5bi16NzY0MENONHpPY2hTOVhXbXZmUSIsImtpZCI6InpqZ3V5bi16NzY0MENONHpPY2hTOVhXbXZmUSJ9.eyJhdWQiOiJodHRwczovL21hbmFnZW1lbnQuY2hpbmFjbG91ZGFwaS5jbiIsImlzcyI6Imh0dHBzOi8vc3RzLmNoaW5hY2xvdWRhcGkuY24vYzc5MTc3MzUtNWQ2MS00ODMyLThiNTQtYjExZDVmMWU3ODEwLyIsImlhdCI6MTU3ODI4OTcyMywibmJmIjoxNTc4Mjg5NzIzLCJleHAiOjE1NzgyOTM2MjMsImFpbyI6IlkyVmdZSkJVaUUzV2Y1VCtjTXB5ZndQNTJ3K3VBUUE9IiwiYXBwaWQiOiI1N2QxZWEyZi03YmE0LTRkMDMtOTM2YS0wMzYzNjhmZjk1N2MiLCJhcHBpZGFjciI6IjEiLCJpZHAiOiJodHRwczovL3N0cy5jaGluYWNsb3VkYXBpLmNuL2M3OTE3NzM1LTVkNjEtNDgzMi04YjU0LWIxMWQ1ZjFlNzgxMC8iLCJvaWQiOiI0NTUyYmZkMS1hNDU1LTQxYjgtYTY1NS1hNzQ3NzE4NWY0MDIiLCJzdWIiOiI0NTUyYmZkMS1hNDU1LTQxYjgtYTY1NS1hNzQ3NzE4NWY0MDIiLCJ0aWQiOiJjNzkxNzczNS01ZDYxLTQ4MzItOGI1NC1iMTFkNWYxZTc4MTAiLCJ1dGkiOiJLRHQ0NWNNRVMwTzlvcUxiS0lrVUFBIiwidmVyIjoiMS4wIn0.NwCJHFmYXj9jd5alPGHCU2Wnfa8Aj2WyNz7bDIZXbpH2MsrsGu9IRr4TzF4cCGf40S8jSqQoizqLPmqt7pjtltI_Ig2jTPdqb_g-2tFRzPQYpwYpLlpqqrUb1BfQdikA0K-RkFXvoyiRIm71HC_uNW7yDC2gmKxUviaCbLHuV0JSjxYnXwpLZ6Gs6-cbQY1R0LOGEdgiQKdxeXmvLgtfdoVwmuxf6zH090iIbx_hYmCZiwecVWN3vX6_gv_D7pm8wvNvHSwbrkg_C5w1XoFJWpg07jZLy6qsp9xIr2X3P9iZPwukHY_SxoJU3YYLHWy65PLZEObLzMW8PIl9RC9Kug";
            //IoTHubResourceBus ioTHubResourceBus = new IoTHubResourceBus();
            return this._ioTHubResourceBus.GetBySubId(SubId);
        }
        [HttpPut("CreateOrUpdate/{resourceGroupName}/{resourceName}")]
        public async Task<string> CreateOrUpdate([FromBody] IoTHubModel ioTHubModel,string resourceGroupName)
        {
            return await this._ioTHubResourceBus.CreateOrUpdate(ioTHubModel,resourceGroupName);
            
        }

    }
}