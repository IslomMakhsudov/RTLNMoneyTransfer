using RTLN.MoneyTransfer.Infrastructure;
using RTLN.MoneyTransfer.WebApi.Modules.ExchangeRates.Services;
using RTLN.MoneyTransfer.WebApi.Modules.ParticipantList.Services;
using RTLN.MoneyTransfer.WebApi.Modules.ReceiverList.Services;
using RTLN.MoneyTransfer.WebApi.Modules.Transfer.Check.Services;
using RTLN.MoneyTransfer.WebApi.Modules.Transfer.Confirm.Services;
using RTLN.MoneyTransfer.WebApi.Modules.Transfer.State.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MoneyTransferDbContext>();
builder.Services.AddTransient<IExchangeRateService, ExchangeRateService>();
builder.Services.AddTransient<IReceiverListService, ReceiverListService>();
builder.Services.AddTransient<IParticipantListService, ParticipantListService>();
builder.Services.AddTransient<ICheckTransferService, CheckTransferService>();
builder.Services.AddTransient<IConfirmTransferService, ConfirmTransferService>();
builder.Services.AddTransient<IStateOfTransferService, StateOfTransferService>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
