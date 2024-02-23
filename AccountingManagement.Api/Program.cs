using AccountingManagement.ApplicationService.QueryHandlers;
using AccountingManagement.ApplicationService.Services;
using AccountingManagement.Domain.Contracts;
using AccountingManagement.Infrastructure;
using AccountingManagement.Infrastructure.Data;
using AccountingManagement.Infrastructure.Repository;
using MediatR;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

 builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

 var connectionString = builder.Configuration.GetConnectionString("MongoDB");
var client = new MongoClient(connectionString);
var database = client.GetDatabase("AccountManagement");  

builder.Services.AddSingleton<IMongoClient>(client);
builder.Services.AddSingleton<IMongoDbContext>(provider => new MongoDbContext(connectionString, "AccountManagement"));
builder.Services.AddSingleton<IMongoDatabase>(database);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(GetBalanceQueryHandler).Assembly));
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<ITransactionService, TransactionService>();
var app = builder.Build();
 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
