namespace RTLN.MoneyTransfer.WebApi.Services {
    public interface IHashService {
        string CalculateSignature(ToPlatformCheckModelRequest model);
        string CalculateSignature(ToPlatformConfirmModelRequest model);
    }
}