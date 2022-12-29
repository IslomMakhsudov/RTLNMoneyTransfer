using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTLN.MoneyTransfer.Core.Entities
{
    public class ReceiverResponse
    {
        public Identification Identification { get; set; }
        public Participant Participant { get; set; }
        public string DisplayName { get; set; }
        public List<string> Currencies { get; set; }
    }
}
