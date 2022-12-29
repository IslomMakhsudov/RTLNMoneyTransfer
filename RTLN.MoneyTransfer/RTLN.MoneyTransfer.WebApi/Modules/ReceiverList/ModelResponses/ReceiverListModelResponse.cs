using RTLN.MoneyTransfer.Core.Entities;
using System.Reflection.Metadata.Ecma335;

namespace RTLN.MoneyTransfer.WebApi.Modules.ReceiverList.ModelResponses
{
    public class ReceiverListModelResponse
    {
        public List<ClientList> ClientList { get; set; }
    }
}
