using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CreditCard
    {
        public CreditCardBrandEnum CreditCardBrand { get; set; }
        public string CreditCardNumber { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public string SecurityCode { get; set; }
        public string HolderName { get; set; }

    }
}
