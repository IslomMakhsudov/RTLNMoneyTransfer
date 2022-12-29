using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RTLN.MoneyTransfer.Core.Entities
{
    public class ConfirmRequestOriginator : Originator
    {
        public string FullName { get; set; }
        public string Nationality { get; set; }
        public List<AdditionalIdentification> AdditionalIdentification { get; set; }
    }
}
