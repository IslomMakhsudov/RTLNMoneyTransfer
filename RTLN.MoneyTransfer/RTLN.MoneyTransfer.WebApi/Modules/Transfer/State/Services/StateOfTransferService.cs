namespace RTLN.MoneyTransfer.WebApi.Modules.Transfer.State.Services
{
    public class StateOfTransferService : IStateOfTransferService
    {
        private readonly IConfiguration _config;
        private readonly StaticData _staticData;
        public StateOfTransferService(IConfiguration config, StaticData staticData)
        {
            _config = config;
            _staticData = staticData;
        }
        public async Task<ToPlatformStateModelResponse> ToPlatform(ToPlatformStateModelRequest modelRequest)
        {
            var client = new RestClient($"{_config.GetValue<string>("PlatformUrl")}/v2/transfer/confirm");

            var request = new RestRequest()
                .AddJsonBody(modelRequest);

            var response = await client.PostAsync<ToPlatformStateModelResponse>(request);

            if (response == null)
                throw new InvalidOperationException("");

            return response;
        }

        public async Task<FromPlatformStateModelResponse> FromPlatform(FromPlatformStateModelRequest modelRequest)
        {
            using var connection = new SqlConnection(_staticData.ConnectionString);

            var query = "";

            using var command = new SqlCommand(query, connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@PlatformReferenceNumber", modelRequest.PlatformReferenceNumber);

            try
            {
                await connection.OpenAsync();
                using var reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    await reader.ReadAsync();

                    var modelResponse = new FromPlatformStateModelResponse();

                    modelResponse.PlatformReferenceNumber = reader.GetString("PlatformReferenceNumber");
                    modelResponse.Receiver.Identification.Type = reader.GetString("Type");
                    modelResponse.Receiver.Identification.Value = reader.GetString("Value");
                    modelResponse.Receiver.Participant.ParticipantId = reader.GetInt32("ParticipantId");
                    modelResponse.ReceivingAmount.Amount = reader.GetDecimal("Amount");
                    modelResponse.ReceivingAmount.Currency = reader.GetString("Currency");
                    modelResponse.ReceivedDate = reader.GetString("ReceivedDate");
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
    }
}
