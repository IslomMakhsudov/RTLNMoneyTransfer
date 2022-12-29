using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTLN.MoneyTransfer.Core.Entities
{
    public class ClientList
    {
        public Identification Identification { get; set; }
        public string DisplayName { get; set; }
        public FullParticipant Participant { get; set; }
    }
}
