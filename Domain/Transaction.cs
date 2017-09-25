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
        public PriorityEnum Priority { get; set; }
        public int FileOrder { get; set; }
        public string ErrorReport { get; set; }
        public int InternalTime { get; set; }
        public ICollection<CreditCardTransaction> CreditCardTransactionResultCollection { get; set; }
        public ICollection<CreditCardTransaction> CreditCardTransactionCollection { get; set; }
        public Order Order { get; set; }
        public Order OrderResult { get; set; }

        public Transaction()
        {
            CreditCardTransactionCollection = new Collection<CreditCardTransaction>();
            CreditCardTransactionResultCollection = new Collection<CreditCardTransaction>();
        }
    }
}
