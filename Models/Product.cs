using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NetCoreWebAppEmample.Models
{
    public class Product
    {
        [Key]

        public int ProductId { set; get; }
        public string Pname { set; get; }
        public float Price { set; get; }
        public string Company { set; get; }
        public string Description { set; get; }
    }
}
