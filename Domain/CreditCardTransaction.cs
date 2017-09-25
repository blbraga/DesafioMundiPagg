using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CreditCardTransaction
    {
        public string AcquirerMessage { get; set; }
        public bool Success { get; set; }
        public int AmountInCents { get; set; }
        public CreditCard CreditCard { get; set; }
        public string CreditCardOperation { get; set; }
        public int InstallmentCount { get; set; }
    }
}
