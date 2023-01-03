using RTLN.MoneyTransfer.Infrastructure;
using RTLN.MoneyTransfer.WebApi.Modules.ExchangeRates.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MoneyTransferDbContext>();
builder.Services.AddTransient<IExchangeRateService, ExchangeRateService>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
