using RTLN.MoneyTransfer.WebApi.Modules.ReceiverList.ModelRequests;
using RTLN.MoneyTransfer.WebApi.Modules.ReceiverList.ModelResponses;

namespace RTLN.MoneyTransfer.WebApi.Modules.ReceiverList.Services
{
    public interface IReceiverListService
    {
        public Task<ReceiverListModelResponse> GetReceiverListAsync(ReceiverListModelRequest modelRequest);
        public string GetReceiverListTest();
    }
}
