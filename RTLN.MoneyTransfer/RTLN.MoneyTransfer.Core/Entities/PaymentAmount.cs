using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTLN.MoneyTransfer.Core.Entities
{
    public class PaymentAmount
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
