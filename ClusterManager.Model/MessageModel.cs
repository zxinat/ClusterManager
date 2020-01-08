using System;
using System.Collections.Generic;
using System.Text;

namespace ClusterManager.Model
{
    class MessageModel<T>
    {
        // 操作是否成功
        public bool Success { get; set; }
        //返回信息
        public string Msg { get; set; }
        //返回数据集合
        public List<T> Data { get; set; }
    }
}
