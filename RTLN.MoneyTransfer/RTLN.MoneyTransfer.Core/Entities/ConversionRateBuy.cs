using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTLN.MoneyTransfer.Core.Entities
{
    public class ConversionRateBuy
    {
        public string OriginatorCurrency { get; set; }
        public string SettlementCurrency { get; set; }
        public decimal Rate { get; set; }
        public decimal BaseRate { get; set; }

    }
}
