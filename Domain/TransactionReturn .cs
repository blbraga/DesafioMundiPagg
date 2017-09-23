using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TransactionReturn
    {
        public string ErrorReport { get; set; }
        public int InternalTime { get; set; }
        public ICollection<CreditCardTransaction> CreditCardTransactionResultCollection { get; set; }

        public Order OrderResult { get; set; }

        public TransactionReturn()
        {
            CreditCardTransactionResultCollection = new Collection<CreditCardTransaction>();
        }
    }
}
