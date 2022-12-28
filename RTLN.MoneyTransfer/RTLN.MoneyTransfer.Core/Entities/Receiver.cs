using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTLN.MoneyTransfer.Core.Entities
{
    public class Receiver
    {
        public Identification Identification { get; set; }
        public Participant Participant { get; set; }
    }
}
