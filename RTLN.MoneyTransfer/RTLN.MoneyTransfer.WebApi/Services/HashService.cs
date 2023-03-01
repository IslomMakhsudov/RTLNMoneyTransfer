using System.Security.Cryptography;
using System.Text;

namespace RTLN.MoneyTransfer.WebApi.Services {
    public class HashService : IHashService {
        private readonly IConfiguration _config;
        public HashService(IConfiguration config) {
            _config = config;
        }

        public string CalculateSignature(ToPlatformCheckModelRequest model) {

            var parameters = new Dictionary<string, object> {
                {"originatorReferenceNumber", model.OriginatorReferenceNumber ?? "null" },
                {"originator/identification/type", model.Originator.Identification.Type ?? "null"},
                {"originator/identification/value", model.Originator.Identification.Value ?? "null"},
                {"originator/participant/participantId", model.Originator.Participant.ParticipantId.ToString() ?? "null"},
                {"originator/nationality", model.Originator.Nationality ?? "null"},
                {"receiver/identification/type", model.Receiver.Identification.Type ?? "null"},
                {"receiver/identification/type", model.Receiver.Identification.Value ?? "null"},
                {"receiver/participant/participantId", model.Receiver.Participant.ParticipantId.ToString() ?? "null"},
                {"paymentAmount/amount", model.PaymentAmount.Amount.ToString() ?? "null"},
                {"paymentAmount/currency", model.PaymentAmount.Currency ?? "null"},
                {"receivingAmount/amount", model.ReceivingAmount.Amount.ToString() ?? "null"},
                {"receivingAmount/currency", model.ReceivingAmount.Currency ?? "null" }
            };

            var result = GetSignedBase64Hash(parameters);
            return result;
        }

        public string CalculateSignature(ToPlatformConfirmModelRequest model) {
            var parameters = new Dictionary<string, object> {
                { "platformReferenceNumber", model.PlatformReferenceNumber ?? "null" },
                { "originator/identification/type", model.Originator.Identification.Type ?? "null"},
                { "originator/identification/value", model.Originator.Identification.Value ?? "null"},
                { "originator/participant/participantId", model.Originator.Participant.ParticipantId.ToString() ?? "null"},
                { "originator/fullName", model.Originator.FullName ?? "null"},
                { "originator/nationality", model.Originator.Nationality ?? "null"},
                { "receiver/identification/type", model.Receiver.Identification.Type ?? "null"},
                { "receiver/identification/type", model.Receiver.Identification.Value ?? "null"},
                { "receiver/participant/participantId", model.Receiver.Participant.ParticipantId.ToString() ?? "null"},
                { "paymentAmount/amount", model.PaymentAmount.Amount.ToString() ?? "null"},
                { "paymentAmount/currency", model.PaymentAmount.Currency ?? "null"},
                { "receivingAmount/amount", model.ReceivingAmount.Amount.ToString() ?? "null"},
                { "receivingAmount/currency", model.ReceivingAmount.Currency ?? "null" }
            };

            var result = GetSignedBase64Hash(parameters);
            return result;
        }

        private string GetSignedBase64Hash(Dictionary<string, object> parameters) {
            var strToHash = new StringBuilder();
            foreach (var parameter in parameters) {
                strToHash.Append(parameter.Value);
            }

            // Compute SHA256 hash
            using var sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(strToHash.ToString()));

            // Sign hash with RSA
            var rsa = RSA.Create();
            var privateKey = Convert.FromBase64String(_config["PrivateKey"]); // Load private key from configuration
            rsa.ImportRSAPrivateKey(privateKey, out _);
            var signature = rsa.SignHash(hash, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

            // Convert signature to Base64
            return Convert.ToBase64String(signature);
        }
    }
}
