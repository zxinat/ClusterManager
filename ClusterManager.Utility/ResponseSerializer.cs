using System;
using System.Collections.Generic;
using System.Text;

namespace ClusterManager.Utility
{
    public class ResponseSerializer
    {
        public int code { get; set; }
        public String message { get; set; }
        public object data { get; set; }
        public ResponseSerializer(int _code,String _message,object _data)
        {
            this.code = _code;
            this.message = _message;
            this.data = _data;
        }
    }
}
