using RestSharp;
using RTLN.MoneyTransfer.WebApi.Modules.Transfer.Confirm.ModelResponses;
using RTLN.MoneyTransfer.WebApi.Modules.Transfer.State.ModelRequests;
using RTLN.MoneyTransfer.WebApi.Modules.Transfer.State.ModelResponses;

namespace RTLN.MoneyTransfer.WebApi.Modules.Transfer.State.Services
{
    public class StateOfTransferService : IStateOfTransferService
    {
        private readonly IConfiguration _config;
        public StateOfTransferService(IConfiguration config)
        {
            _config = config;
        }
        public async Task<StateOfTransferModelResponse> StateOfTransferAsync(StateOfTransferModelRequest modelRequest)
        {
            var client = new RestClient($"{_config.GetValue<string>("PlatformUrl")}/v2/transfer/confirm");

            var request = new RestRequest()
                .AddJsonBody(modelRequest);

            var response = await client.PostAsync<StateOfTransferModelResponse>(request);

            if (response == null)
                throw new InvalidOperationException("");

            return response;
        }

        public string StateOfTransferTest()
        {
            return "{\r\n\"platformReferenceNumber\":\"a9ce69fc-c2a8-4870-b077-28116c4a6942108a0915-6e9a-41a7-8b7bab176bddcfa1\",\r\n\"originator\":{\r\n\"identification\": {\r\n\"type\": \"PHONE\",\r\n\"value\":\"79252804531\"\r\n},\r\n\"participant\":{\r\n\"participantId\":123456\r\n}\r\n},\r\n\"receiver\":{\r\n\"identification\": {\r\n\"type\": \"PHONE\",\r\n\"value\":\"49252804532\"\r\n},\r\n\"participant\":{\r\n\"participantId\":7654321\r\n},\r\n},\r\n\"paymentAmount\":{\r\n\"amount\": 200,\r\n\"currency\": \"UAH\"\r\n},\r\n\"feeAmount\":[\r\n{\r\n\"amount\": 8.01,\r\n\"currency\": \"RUB\",\r\n\"type\": \"PLATFORM\"\r\n},\r\n{\r\n\"amount\": 1.01,\r\n\"currency\": \"RUB\",\r\n\"type\": \"INTERMEDIARY\"\r\n},\r\n{\r\n\"amount\": 12.01,\r\n\"currency\": \"RUB\",\r\n\"type\": \"RECEIVER\"\r\n}\r\n],\r\n\"settlementAmount\":{\r\n\"amount\": 530.5,\r\n\"currency\": \"RUB\"\r\n},\r\n\"receivingAmount\":{\r\n\"amount\":17.80,\r\n\"currency\": \"BYN\"\r\n},\r\n\"checkDate\":\"2020-03-04T12:07:43Z\",\r\n\"transferDate\":\"2020-03-04T12:08:43Z\",\r\n\"receivedDate\": \"2020-03-04T15:02:11Z\",\r\n\"conversionRateSell\":{\r\n\"originalCurrency\":\"UAH\",\r\n\"settlementCurrency\":\"RUB\",\r\n\"rate\":2.66\r\n},\r\n\"conversionRateBuy\":{\r\n\"type\":\"EXT\"\r\n},\r\n\"transferState\":{\r\n\"state\":\"CONFIRMED\",\r\n\"errorCode\":200,\r\n\"errorMessage\": \"Successfully completed\"\r\n}\r\n}";
        }
    }
}
