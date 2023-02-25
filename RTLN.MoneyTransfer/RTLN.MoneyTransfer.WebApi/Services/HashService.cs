using System.Security.Cryptography;
using System.Text;

namespace RTLN.MoneyTransfer.WebApi.Services {
    public class HashService : IHashService {
        private readonly IConfiguration _config;
        public HashService(IConfiguration config)
        {
            _config = config;
        }

        public string CalculateSignature(ToPlatformCheckModelRequest model) {
            
            var parameters = new List<KeyValuePair<string, object>> {
                new KeyValuePair<string, object>("originatorReferenceNumber", model.OriginatorReferenceNumber ?? "null"),
                new KeyValuePair<string, object>("originator/identification/type", model.Originator.Identification.Type ?? "null"),
                new KeyValuePair<string, object>("originator/identification/value", model.Originator.Identification.Value ?? "null"),
                new KeyValuePair<string, object>("originator/participant/participantId", model.Originator.Participant.ParticipantId.ToString() ?? "null"),
                new KeyValuePair<string, object>("originator/nationality", model.Originator.Nationality ?? "null"),
                new KeyValuePair<string, object>("receiver/identification/type", model.Receiver.Identification.Type ?? "null"),
                new KeyValuePair<string, object>("receiver/identification/type", model.Receiver.Identification.Value ?? "null"),
                new KeyValuePair<string, object>("receiver/participant/participantId", model.Receiver.Participant.ParticipantId.ToString() ?? "null"),
                new KeyValuePair<string, object>("paymentAmount/amount", model.PaymentAmount.Amount.ToString() ?? "null"),
                new KeyValuePair<string, object>("paymentAmount/currency", model.PaymentAmount.Currency ?? "null"),
                new KeyValuePair<string, object>("receivingAmount/amount", model.ReceivingAmount.Amount.ToString() ?? "null"),
                new KeyValuePair<string, object>("receivingAmount/currency", model.ReceivingAmount.Currency ?? "null")
            };

            var result = GetSignedBase64Hash(parameters);
            return result;
        }

        public string CalculateSignature(ToPlatformConfirmModelRequest model) {
            var parameters = new List<KeyValuePair<string, object>> {
                new KeyValuePair<string, object>("originatorReferenceNumber", model.OriginatorSignature ?? "null"),
                new KeyValuePair<string, object>("platformReferenceNumber", model.PlatformReferenceNumber ?? "null"),
                new KeyValuePair<string, object>("originator/identification/type", model.Originator.Identification.Type ?? "null"),
                new KeyValuePair<string, object>("originator/identification/value", model.Originator.Identification.Value ?? "null"),
                new KeyValuePair<string, object>("originator/participant/participantId", model.Originator.Participant.ParticipantId.ToString() ?? "null"),
                new KeyValuePair<string, object>("originator/fullName", model.Originator.FullName ?? "null"),
                new KeyValuePair<string, object>("originator/nationality", model.Originator.Nationality ?? "null"),
                new KeyValuePair<string, object>("receiver/identification/type", model.Receiver.Identification.Type ?? "null"),
                new KeyValuePair<string, object>("receiver/identification/type", model.Receiver.Identification.Value ?? "null"),
                new KeyValuePair<string, object>("receiver/participant/participantId", model.Receiver.Participant.ParticipantId.ToString() ?? "null"),
                new KeyValuePair<string, object>("paymentAmount/amount", model.PaymentAmount.Amount.ToString() ?? "null"),
                new KeyValuePair<string, object>("paymentAmount/currency", model.PaymentAmount.Currency ?? "null"),
                new KeyValuePair<string, object>("receivingAmount/amount", model.ReceivingAmount.Amount.ToString() ?? "null"),
                new KeyValuePair<string, object>("receivingAmount/currency", model.ReceivingAmount.Currency ?? "null")
            };

            var result = GetSignedBase64Hash(parameters);
            return result;
        }

        private string GetSignedBase64Hash(List<KeyValuePair<string, object>> parameters) {
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
