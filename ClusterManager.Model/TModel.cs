using System;
using System.Collections.Generic;
using System.Text;

namespace ClusterManager.Model
{
    public class TModel<T>
    {
        private T t;
        public TModel(T t)
        {
            this.t = t;
        }
        public T body { get; set; }
        public string headers { get; set; }
        public string statusCode { get; set; }
        public string successful { get; set; }
    }
}
