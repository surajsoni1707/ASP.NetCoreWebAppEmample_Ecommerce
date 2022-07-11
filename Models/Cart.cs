using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NetCoreWebAppEmample.Models
{
    public class Cart
    {
        [Key]
        public int Cid { get; set; }
        public int Pid { get; set; }
        public int Uid { get; set; }
        public int Quantity { set; get; }
    }
}
