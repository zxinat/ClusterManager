using System;
using System.Collections.Generic;
using System.Text;
using ClusterManager.Model;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ClusterManager.Utility
{
    public class JWTHelper
    {
        readonly IConfiguration _configuration;
        private string secret;
        static IJwtAlgorithm agorithm = new HMACSHA256Algorithm();//HMACSHA256加密
        static IJsonSerializer serializer = new JsonNetSerializer();//序列化和反序列化
        static IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();//Base64编解码
        static IDateTimeProvider provider = new UtcDateTimeProvider();//UTC时间获取
        public JWTHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            secret = _configuration.GetSection("JwtSettings:SecurityKey").Value;
        }
        public string CreateJwt(Dictionary<string, object> payload)
        {
            IJwtEncoder encoder = new JwtEncoder(agorithm,serializer,urlEncoder);
            var token = encoder.Encode(payload,secret);
            return token;
        }
        public bool ValidateJwt(string token,out string payload, out string message)
        {
            bool isValidate = false;
            payload = "";
            try
            {
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);
                payload = decoder.Decode(token, secret, verify: true);
                isValidate = true;
                message = "验证成功";
            }
            catch (TokenExpiredException)
            {
                message = "Token过期";
            }
            catch (SignatureVerificationException)
            {
                message = "签名错误";
            }
            return isValidate;
        }
    }
}
