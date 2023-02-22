using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RTLN.MoneyTransfer.Core.Entities
{
    public class Participant
    {
        [JsonRequired]
        public int ParticipantId { get; set; }
        [AllowNull]
        public string? Country { get; set; }
    }
}
