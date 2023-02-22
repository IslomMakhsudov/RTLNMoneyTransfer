namespace RTLN.MoneyTransfer.WebApi.Modules.Transfer.Confirm.Services
{
    public interface IConfirmTransferService
    {
        public Task<ToPlatformConfirmModelResponse> ToPlatform(ToPlatformConfirmModelRequest modelRequest);
        public Task<FromPlatformConfirmModelResponse> FromPlatform(FromPlatformConfirmModelRequest modelRequest);
    }
}
