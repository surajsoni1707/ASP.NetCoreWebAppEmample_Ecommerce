using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NetCoreWebAppEmample.Models
{
    public class Order
    {
        public int oid { get; set; }
        public int Pid { get; set; }
        public int Uid { get; set; }
        public int Quantity { set; get; }
    }
}
