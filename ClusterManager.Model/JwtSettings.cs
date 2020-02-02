using System;
using System.Collections.Generic;
using System.Text;

namespace ClusterManager.Model
{
    public class JwtSettings
    {
        string SecurityKey { get; set; }
        string Issuer { get; set; }
        string Audience { get; set; }
        int ExpireSeconds { get; set; }
    }
}
