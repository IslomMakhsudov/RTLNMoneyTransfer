namespace RTLN.MoneyTransfer.WebApi.Modules.Transfer.State.Services
{
    public interface IStateOfTransferService
    {
        public Task<ToPlatformStateModelResponse> ToPlatform(ToPlatformStateModelRequest modelRequest);

        public Task<FromPlatformStateModelResponse> FromPlatform(FromPlatformStateModelRequest modelRequest);
    }
}
