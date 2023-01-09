using RestSharp;
using RTLN.MoneyTransfer.WebApi.Modules.ParticipantList.ModelResponses;
using RTLN.MoneyTransfer.WebApi.Modules.ReceiverList.ModelRequests;
using RTLN.MoneyTransfer.WebApi.Modules.ReceiverList.ModelResponses;

namespace RTLN.MoneyTransfer.WebApi.Modules.ReceiverList.Services
{
    public class ReceiverListService : IReceiverListService
    {
        private readonly IConfiguration _config;
        public ReceiverListService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<ReceiverListModelResponse> GetReceiverListAsync(ReceiverListModelRequest modelRequest)
        {
            var client = new RestClient($"{_config.GetValue<string>("PlatformUrl")}/v2/participantlist");

            var request = new RestRequest()
                .AddJsonBody(modelRequest);

            var response = await client.PostAsync<ReceiverListModelResponse>(request);

            if (response == null)
                throw new InvalidOperationException("");

            return response;
        }

        public string GetReceiverListTest()
        {
            return "{\r\n\"clientList\": [\r\n{\r\n\"identification\": {\r\n\"type\": \"PHONE\",\r\n\"value\":\"79252804531\"\r\n},\r\n\"displayName\": \"Firstname L.\",\r\n\"participant\": {\r\n\"localizedName\": \"АБЦ Банк\",\r\n\"logo\": \"http://platform.rtln.ru/static/logos/abc_bank_34_34.png\",\r\n\"country\": \"RUS\",\r\n\"participantId\": 123456,\r\n\"currencies\": [\r\n\"RUB\",\r\n\"USD\"\r\n]\r\n}\r\n},\r\n{\r\n\"identification\": {\r\n\"type\": \"PHONE\",\r\n\"value\":\"79252804531\"\r\n},\r\n\"displayName\": \"Firstname L.\",\r\n\"participant\": {\r\n\"localizedName\": \"Бобров Дебетовые Системы Банк\",\r\n\"logo\": \"./logos/bds_34_34.png\",\r\n\"country\": \"RUS\",\r\n\"participantId\": 100006,\r\n\"currencies\": [\r\n\"RUB\"\r\n]\r\n}\r\n}\r\n]\r\n}";
        }
    }
}
