using RTLN.MoneyTransfer.Core.Entities;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace RTLN.MoneyTransfer.WebApi.Services {
    public class PlatformSignatureVerifier : IPlatformSignatureVerifier {
        private readonly RSACryptoServiceProvider _rsaCryptoServiceProvider;
        public PlatformSignatureVerifier(IConfiguration config) {
            _rsaCryptoServiceProvider = new RSACryptoServiceProvider();
            _rsaCryptoServiceProvider.FromXmlString(config.GetValue<string>("PublicKey"));
        }

        public bool VerifySignature(FromPlatformCheckModelRequest request, string platformSignature) {
            var parameters = new Dictionary<string, string>
            {
                { "platformReferenceNumber", request.PlatformReferenceNumber },
                { "receiver/identification/value", request.Receiver.Identification.Value },
                { "paymentAmount/amount", request.PaymentAmount.Amount.ToString(CultureInfo.InvariantCulture) },
                { "paymentAmount/currency", request.PaymentAmount.Currency },
                { "settlementAmount/amount", request.SettlementAmount.Currency.ToString(CultureInfo.InvariantCulture) },
                { "settlementAmount/currency", request.SettlementAmount.Currency },
                { "receivingAmount/currency", request.ReceivingAmount.Currency }
            };

            if (request.ReceivingAmount.Amount > 0) {
                parameters.Add("receivingAmount/amount", request.ReceivingAmount.Amount.ToString(CultureInfo.InvariantCulture));
            }

            return VerifyHash(parameters, platformSignature);
        }

        public bool VerifySignature(FromPlatformConfirmModelRequest request, string platformSignature) {
            var parameters = new Dictionary<string, string>
            {
                { "platformReferenceNumber", request.PlatformReferenceNumber },
                { "receiver/identification/value", request.Receiver.Identification.Value },
                { "paymentAmount/amount", request.PaymentAmount.Amount.ToString(CultureInfo.InvariantCulture) },
                { "paymentAmount/currency", request.PaymentAmount.Currency },
                { "settlementAmount/amount", request.SettlementAmount.Currency.ToString(CultureInfo.InvariantCulture) },
                { "settlementAmount/currency", request.SettlementAmount.Currency },
                { "receivingAmount/currency", request.ReceivingAmount.Currency }
            };

            if (request.ReceivingAmount.Amount > 0) {
                parameters.Add("receivingAmount/amount", request.ReceivingAmount.Amount.ToString(CultureInfo.InvariantCulture));
            }

            return VerifyHash(parameters, platformSignature);
        }

        private bool VerifyHash(Dictionary<string, string> parameters, string platformSignature) {
            var dataToHash = new StringBuilder();
            foreach (var parameter in parameters.OrderBy(p => p.Key)) {
                var value = parameter.Value ?? "null";
                dataToHash.Append(value);
            }

            var hash = new SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(dataToHash.ToString()));
            var signature = Convert.FromBase64String(platformSignature);
            return _rsaCryptoServiceProvider.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA256"), signature);
        }
    }
}