using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Transaction
    {
        public ICollection<CreditCardTransaction> CreditCardTransactionCollection { get; set; }

        public Order Order { get; set; }

        public Transaction()
        {
            CreditCardTransactionCollection = new Collection<CreditCardTransaction>();
        }
    }
}
