using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTLN.MoneyTransfer.Core.Entities
{
    public class Fee
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Type { get; set; }
    }
}
