using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTLN.MoneyTransfer.Core.Entities
{
    public class Originator
    {
        public Identification Identification { get; set; }
        public Participant Participant { get; set; }
        [AllowNull]
        public string? FullName { get; set; }
        [AllowNull]
        public List<AdditionalIdentification>? AdditionalIdentification { get; set; }
    }
}
