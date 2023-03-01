namespace RTLN.MoneyTransfer.WebApi.Services {
    public interface IPlatformSignatureVerifier {
        bool VerifySignature(FromPlatformCheckModelRequest request, string PlatformSignature);
        bool VerifySignature(FromPlatformConfirmModelRequest request, string PlatformSignature);
    }
}
