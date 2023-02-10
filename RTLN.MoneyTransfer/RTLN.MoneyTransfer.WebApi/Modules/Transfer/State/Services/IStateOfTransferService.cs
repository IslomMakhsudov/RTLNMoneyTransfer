using RTLN.MoneyTransfer.WebApi.Modules.Transfer.State.ModelRequests;
using RTLN.MoneyTransfer.WebApi.Modules.Transfer.State.ModelResponses;

namespace RTLN.MoneyTransfer.WebApi.Modules.Transfer.State.Services
{
    public interface IStateOfTransferService
    {
        public Task<ToPlatformStateModelResponse> ToPlatform(ToPlatformStateModelRequest modelRequest);

        public Task<FromPlatformStateModelResponse> FromPlatform(FromPlatformStateModelRequest modelRequest);
    }
}
