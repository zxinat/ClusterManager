using System;
using System.Collections.Generic;
using System.Text;

namespace ClusterManager.Model
{
    public class TokenModel
    {
        //Token info
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public int expires_on { get; set; }
        public int ext_expires_in { get; set; }
        public int not_before { get; set; }
        public string resource { get; set; }
        public string token_type { get; set; }
    }
}
