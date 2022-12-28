using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTLN.MoneyTransfer.Core.Entities
{
    public class ConversionRateSell
    {
        public string Type { get; set; }
        public string SettlementCurrency { get; set; }
        public string ReceivingCurrency { get; set; }
        public decimal Rate { get; set; }
        public decimal BaseRate { get; set; }
    }
}
