using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order
    {
        public string OrderReference { get; set; }
        public string OrderKey { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
