using Azure.Core;

namespace RTLN.MoneyTransfer.WebApi.Modules.Transfer.Confirm.Services
{
    public class ConfirmTransferService : IConfirmTransferService
    {
        private readonly IConfiguration _config;
        private readonly StaticData _staticData;
        public ConfirmTransferService(IConfiguration config, StaticData staticData)
        {
            _config = config;
            _staticData = staticData;
        }

        public async Task<FromPlatformConfirmModelResponse> FromPlatform(FromPlatformConfirmModelRequest modelRequest)
        {
            using var connection = new SqlConnection(_staticData.ConnectionString);

            var query = "";

            using var command = new SqlCommand(query, connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@platformReferenceNumber", modelRequest.PlatformReferenceNumber);
            command.Parameters.AddWithValue("@platformSignature", modelRequest.PlatformSingature);
            command.Parameters.AddWithValue("@originator_identification_type", modelRequest.Originator.Identification.Type);
            command.Parameters.AddWithValue("@originator_identification_value", modelRequest.Originator.Identification.Value);
            command.Parameters.AddWithValue("@originator_participant_participantId", modelRequest.Originator.Participant.ParticipantId);
            command.Parameters.AddWithValue("@originator_participant_country", modelRequest.Originator.Participant.Country);
            command.Parameters.AddWithValue("@originator_fullName", modelRequest.Originator.FullName);
            command.Parameters.AddWithValue("@receiver_identification_type", modelRequest.Receiver.Identification.Type);
            command.Parameters.AddWithValue("@receiver_identification_value", modelRequest.Receiver.Identification.Value);
            command.Parameters.AddWithValue("@receiver_participant_participantId", modelRequest.Receiver.Participant.ParticipantId);
            command.Parameters.AddWithValue("@paymentAmount_amount", modelRequest.PaymentAmount.Amount);
            command.Parameters.AddWithValue("@paymentAmount_currency", modelRequest.PaymentAmount.Currency);
            command.Parameters.AddWithValue("@settlementAmount_currency", modelRequest.SettlementAmount.Currency);
            command.Parameters.AddWithValue("@settlementAmount_amount", modelRequest.SettlementAmount.Amount);
            command.Parameters.AddWithValue("@receivingAmount_amount", modelRequest.ReceivingAmount.Amount);
            command.Parameters.AddWithValue("@receivingAmount_currency", modelRequest.ReceivingAmount.Currency);
            command.Parameters.AddWithValue("@checkDate", modelRequest.CheckDate);
            command.Parameters.AddWithValue("@conversionRateBuy_originatorCurrency", modelRequest.ConversionRateBuy.OriginatorCurrency);
            command.Parameters.AddWithValue("@conversionRateBuy_settlementCurrency", modelRequest.ConversionRateBuy.SettlementCurrency);
            command.Parameters.AddWithValue("@conversionRateBuy_rate", modelRequest.ConversionRateBuy.Rate);
            command.Parameters.AddWithValue("@conversionRateBuy_baseRate", modelRequest.ConversionRateBuy.BaseRate);
            command.Parameters.AddWithValue("@conversionRateSell_type", modelRequest.ConversionRateSell.Type);
            command.Parameters.AddWithValue("@conversionRateSell_settlementCurrency", modelRequest.ConversionRateSell.SettlementCurrency);
            command.Parameters.AddWithValue("@conversionRateSell_receivingCurrency", modelRequest.ConversionRateSell.ReceivingCurrency);
            command.Parameters.AddWithValue("@conversionRateSell_rate", modelRequest.ConversionRateSell.Rate);
            command.Parameters.AddWithValue("@conversionRateSell_baseRate", modelRequest.ConversionRateSell.BaseRate);
            command.Parameters.AddWithValue("@comment", modelRequest.Comment);

            if(modelRequest.Originator.AdditionalIdentification != null)
                command.Parameters.Add(CreateParameter(modelRequest.Originator.AdditionalIdentification));

            if(modelRequest.FeeAmount != null)
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

        public async Task<ToPlatformConfirmModelResponse> ToPlatform(ToPlatformConfirmModelRequest modelRequest)
        {
            var client = new RestClient($"{_config.GetValue<string>("PlatformUrl")}/v2/transfer/confirm");

            var request = new RestRequest()
                .AddJsonBody(modelRequest);

            var response = await client.PostAsync<ToPlatformConfirmModelResponse>(request);

            if (response == null)
                throw new InvalidOperationException("");

            return response;
        }

        private SqlParameter CreateParameter(List<AdditionalIdentification> list)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Type", typeof(string));
            table.Columns.Add("Value", typeof(string));

            foreach (var item in list)
                table.Rows.Add(item.Type, item.Value);

            SqlParameter parameter = new SqlParameter("@originator_additionalIdentification", SqlDbType.Structured);
            parameter.TypeName = "SchemaName.TypeName";
            parameter.Value = table;

            return parameter;
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
