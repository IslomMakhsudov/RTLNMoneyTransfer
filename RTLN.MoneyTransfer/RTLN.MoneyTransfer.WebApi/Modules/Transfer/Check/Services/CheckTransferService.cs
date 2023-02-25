using RestSharp;
using RTLN.MoneyTransfer.WebApi.Modules.ReceiverList.ModelResponses;
using RTLN.MoneyTransfer.WebApi.Modules.Transfer.Check.ModelRequests;
using RTLN.MoneyTransfer.WebApi.Modules.Transfer.Check.ModelResponses;
using RTLN.MoneyTransfer.WebApi.Services;

namespace RTLN.MoneyTransfer.WebApi.Modules.Transfer.Check.Services
{
    public class CheckTransferService : ICheckTransferService
    {
        private readonly IConfiguration _config;
        private readonly StaticData _staticData;
        public CheckTransferService(IConfiguration config, StaticData staticData)
        {
            _config = config;
            _staticData = staticData;
        }

        public async Task<FromPlatformCheckModelResponse> FromPlatform(FromPlatformCheckModelRequest modelRequest)
        {
            using var connection = new SqlConnection(_staticData.ConnectionString);

            var query = "";

            using var command = new SqlCommand(query, connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@platformReferenceNumber", modelRequest.PlatformReferenceNumber);
            command.Parameters.AddWithValue("@platformSignature", modelRequest.PlatformSignature);
            command.Parameters.AddWithValue("@receiver_identification_type", modelRequest.Receiver.Identification.Type);
            command.Parameters.AddWithValue("@receiver_identification_value", modelRequest.Receiver.Identification.Value);
            command.Parameters.AddWithValue("@receiver_participant_participantId", modelRequest.Receiver.Participant.ParticipantId);
            command.Parameters.AddWithValue("@paymentAmount_amount", modelRequest.PaymentAmount.Amount);
            command.Parameters.AddWithValue("@paymentAmount_currency", modelRequest.PaymentAmount.Currency);
            command.Parameters.AddWithValue("@settlementAmount_currency", modelRequest.SettlementAmount.Currency);
            command.Parameters.AddWithValue("@settlementAmount_amount", modelRequest.SettlementAmount.Amount);
            command.Parameters.AddWithValue("@receivingAmount_amount", modelRequest.ReceivingAmount.Amount);
            command.Parameters.AddWithValue("@receivingAmount_currency", modelRequest.ReceivingAmount.Currency);

            if(modelRequest.ConversionRateSell != null)
            {
                command.Parameters.AddWithValue("@conversionRateSell_type", modelRequest.ConversionRateSell.Type);
                command.Parameters.AddWithValue("@conversionRateSell_settlementCurrency", modelRequest.ConversionRateSell.SettlementCurrency);
                command.Parameters.AddWithValue("@conversionRateSell_receivingCurrency", modelRequest.ConversionRateSell.ReceivingCurrency);
                command.Parameters.AddWithValue("@conversionRateSell_rate", modelRequest.ConversionRateSell.Rate);
                command.Parameters.AddWithValue("@conversionRateSell_baseRate", modelRequest.ConversionRateSell.BaseRate);
            }

            if (modelRequest.FeeAmount != null)
                command.Parameters.Add(CreateParameter(modelRequest.FeeAmount));

            try
            {
                await connection.OpenAsync();
                using var reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    await reader.ReadAsync();

                    var modelResponse = new FromPlatformCheckModelResponse();

                    modelResponse.PlatformReferenceNumber = reader.GetString("PlatformReferenceNumber");
                    modelResponse.TransferState.State = reader.GetString("State");
                    modelResponse.TransferState.ErrorCode = reader.GetInt32("ErrorCode");
                    modelResponse.TransferState.ErrorMessage = reader.GetString("ErrorMessage");

                    return modelResponse;
                }
                await reader.CloseAsync();
                await connection.CloseAsync();

                throw new InvalidOperationException("Empty query result");
            }
            catch (Exception ex)
            {
                if (connection.State != ConnectionState.Closed)
                {
                    await connection.CloseAsync();
                }

                throw new InvalidOperationException("");
            }
        }

        public async Task<ToPlatformCheckModelResponse> ToPlatform(ToPlatformCheckModelRequest modelRequest)
        {
            var client = new RestClient($"{_config.GetValue<string>("PlatformUrl")}/v2/transfer/check");

            var request = new RestRequest()
                .AddJsonBody(modelRequest);

            var response = await client.PostAsync<ToPlatformCheckModelResponse>(request);

            return response ?? throw new InvalidOperationException("");
        }

        private SqlParameter CreateParameter(List<Fee> list)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Amount", typeof(decimal));
            table.Columns.Add("Currency", typeof(string));
            table.Columns.Add("Type", typeof(string));

            foreach (var item in list)
                table.Rows.Add(item.Amount, item.Currency, item.Type);

            SqlParameter parameter = new SqlParameter("@feeAmount", SqlDbType.Structured);
            parameter.TypeName = "SchemaName.TypeName";
            parameter.Value = table;

            return parameter;
        }
    }
}
