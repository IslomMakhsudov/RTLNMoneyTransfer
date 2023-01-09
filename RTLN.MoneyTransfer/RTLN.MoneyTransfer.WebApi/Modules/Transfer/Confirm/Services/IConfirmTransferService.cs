using RTLN.MoneyTransfer.WebApi.Modules.Transfer.Confirm.ModelRequests;
using RTLN.MoneyTransfer.WebApi.Modules.Transfer.Confirm.ModelResponses;

namespace RTLN.MoneyTransfer.WebApi.Modules.Transfer.Confirm.Services
{
    public interface IConfirmTransferService
    {
        public Task<ConfirmTransferModelResponse> ConfirmTransferAsync(ConfirmTransferModelRequest modelRequest);
        public string ConfirmTransferTest();
    }
}
