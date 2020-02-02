using System;
using System.Collections.Generic;
using System.Text;
using ClusterManager.Model.ViewModels;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Shared;

namespace ClusterManager.Model.ResponseModel
{
    public class DeviceTwinResponseModel
    {
        public Twin body { get; set; }
        public string headers { get; set; }
        public string statusCode { get; set; }
        public string successful { get; set; }

    }
}
