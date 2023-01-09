using RestSharp;
using RTLN.MoneyTransfer.WebApi.Modules.ReceiverList.ModelResponses;
using RTLN.MoneyTransfer.WebApi.Modules.Transfer.Check.ModelRequests;
using RTLN.MoneyTransfer.WebApi.Modules.Transfer.Check.ModelResponses;

namespace RTLN.MoneyTransfer.WebApi.Modules.Transfer.Check.Services
{
    public class CheckTransferService : ICheckTransferService
    {
        private readonly IConfiguration _config;
        public CheckTransferService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<CheckTransferModelResponse> CheckTransferAsync(CheckTransferModelRequest modelRequest)
        {
            var client = new RestClient($"{_config.GetValue<string>("PlatformUrl")}/v2/transfer/check");

            var request = new RestRequest()
                .AddJsonBody(modelRequest);

            var response = await client.PostAsync<CheckTransferModelResponse>(request);

            if (response == null)
                throw new InvalidOperationException("");

            return response;
        }

        public string CheckTransferTest()
        {
            return "{\r\n\"platformReferenceNumber\":\"a9ce69fc-c2a8-4870-b077-28116c4a6942108a0915-6e9a-41a7-8b7bab176bddcfa1\",\r\n\"originator\":{\r\n\"identification\": {\r\n\"type\": \"PHONE\",\r\n\"value\":\"79252804531\"\r\n},\r\n\"participant\":{\r\n\"participantId\":123456\r\n}\r\n},\r\n\"receiver\":{\r\n\"identification\": {\r\n\"type\": \"PHONE\",\r\n\"value\":\"49252804532\"\r\n},\r\n\"participant\":{\r\n\"participantId\":7654321\r\n},\r\n\"displayName\":\"Andrew B.\",\r\n\"currencies\": [\r\n\"BYN\",\r\n\"RUB\"\r\n]\r\n},\r\n\"paymentAmount\":{\r\n\"amount\": 534,\r\n\"currency\": \"RUB\"\r\n},\r\n\"settlementAmount\":{\r\n\"amount\": 534,\r\n\"currency\": \"RUB\"\r\n},\r\n\"receivingAmount\":{\r\n\"amount\":17.99,\r\n\"currency\": \"BYN\"\r\n},\r\n\"checkDate\":\"2020-03-04T12:07:43Z\",\r\n\"conversionRateSell\":{\r\n\"type\":\"INT\"\r\n\"settlementCurrency\":\"RUB\",\r\n\"receivingCurrency\":\"BYN\",\r\n\"rate\":0.034,\r\n\"baseRate\":0.035\r\n}\r\n\"transferState\":{\r\n\"state\":\"CHECKED\",\r\n\"errorCode\":100,\r\n\"errorMessage\": \"Successfully completed\"\r\n}\r\n}";
        }
    }
}
