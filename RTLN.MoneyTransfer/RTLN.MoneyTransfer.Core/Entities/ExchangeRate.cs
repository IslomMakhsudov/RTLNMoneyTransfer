using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTLN.MoneyTransfer.Core.Entities
{
    public class ExchangeRate
    {
        public string CurrencyCode { get; set; }
        public decimal SellRate { get; set; }
        public decimal BuyRate { get; set; }
        public long ParticipantId { get; set; }
    }
}
