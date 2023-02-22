using RTLN.MoneyTransfer.WebApi.Modules.Transfer.Check.ModelRequests;
using RTLN.MoneyTransfer.WebApi.Modules.Transfer.Check.ModelResponses;

namespace RTLN.MoneyTransfer.WebApi.Modules.Transfer.Check.Services
{
    public interface ICheckTransferService
    {
        public Task<ToPlatformCheckModelResponse> ToPlatform(ToPlatformCheckModelRequest modelRequest);
        public Task<FromPlatformCheckModelResponse> FromPlatform(FromPlatformCheckModelRequest modelRequest);
    }
}
