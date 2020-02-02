using ClusterManager.Core.Infrastructures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json.Linq;
using ClusterManager.Model;

namespace ClusterManager.Core
{
    public class AuthBus:IAuthBus
    {
        private readonly IConfiguration _configuration;
        public AuthBus(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public TokenModel RequestToken(string email,string password)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,email)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "http://localhost:44350",
                audience: "http://localhost:44350",
                claims: claims,
                expires: DateTime.Now.AddSeconds(3600),
                signingCredentials: creds);
            var tokenInfo = new TokenModel
            {
                access_token =new JwtSecurityTokenHandler().WriteToken(token),
                expires_in=3600,
                token_type="Bearer"
            };
            return tokenInfo;
        }
    }
}
