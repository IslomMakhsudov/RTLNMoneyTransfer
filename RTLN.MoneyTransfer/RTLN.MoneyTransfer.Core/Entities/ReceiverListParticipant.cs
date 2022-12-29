using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTLN.MoneyTransfer.Core.Entities
{
    public class FullParticipant : Participant
    {
        public int Order { get; set; }
        public string LocalizedName { get; set; }
        public string Logo { get; set; }
        public string Country { get; set; }
        public List<string> Currencies { get; set; }
    }
}
