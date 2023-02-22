var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MoneyTransferDbContext>();
builder.Services.AddTransient<StaticData>();
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

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
