using RestSharp;
using RTLN.MoneyTransfer.WebApi.Modules.ParticipantList.ModelRequests;
using RTLN.MoneyTransfer.WebApi.Modules.ParticipantList.ModelResponses;

namespace RTLN.MoneyTransfer.WebApi.Modules.ParticipantList.Services
{
    public class ParticipantListService : IParticipantListService
    {
        private readonly IConfiguration _config;
        public ParticipantListService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<ParticipantListModelResponse> GetParticipantListAsync(ParticipantListModelRequest modelRequest)
        {
            var client = new RestClient($"{_config.GetValue<string>("PlatformUrl")}/v2/participantlist");

            var request = new RestRequest()
                .AddJsonBody(modelRequest);

            var response = await client.PostAsync<ParticipantListModelResponse>(request);

            if (response == null)
                throw new InvalidOperationException("");

            return response;
        }

        public string GetParticipantListTest()
        {
            return "{\r\n\"participantList\": [\r\n{\r\n\"order\": 1,\r\n\"localizedName\": \"АБЦ Банк\",\r\n\"logo\": \"http://platform.rtln.ru/static/logos/abc_bank_34_34.png\",\r\n\"country\": \"RUS\",\r\n\"participantId\": 123456,\r\n\"currencies\": [\r\n\"RUB\",\r\n\"USD\"\r\n]\r\n},\r\n{\r\n\"order\": 2,\r\n\"localizedName\": \"Бобров Дебетовые Системы Банк\",\r\n\"logo\": \"./logos/bds_34_34.png\",\r\n\"country\": \"RUS\",\r\n\"participantId\": 100006,\r\n\"currencies\": [\r\n\"RUB\"\r\n]\r\n},\r\n{\r\n\"order\": 3,\r\n\"localizedName\": \"ПромМашБанк\",\r\n\"logo\": \"./logos/prommash_bank_34_34.png\",\r\n\"country\": \"RUS\",\r\n\"participantId\": 234561,\r\n\"currencies\": [\r\n\"RUB\"\r\n]\r\n},\r\n{\r\n\"order\": 4,\r\n\"localizedName\": \"АхматОлгы Банк\",\r\n\"logo\": \"./logos/akhmat_34_34.png\",\r\n\"country\": \"KAZ\",\r\n\"participantId\": 6005185,\r\n\"currencies\": [\r\n\"KZT\",\r\n\"RUB\"\r\n]\r\n},\r\n{\r\n\"order\": 5,\r\n\"localizedName\": \"Кредит Казах Банк\",\r\n\"logo\": \"./logos/kredkaz_34_34.png\",\r\n\"country\": \"KAZ\",\r\n\"participantId\": 444444,\r\n\"currencies\": [\r\n\"KZT\"\r\n]\r\n}\r\n]\r\n}";
        }
    }
}
