using AccountingManagement.Domain.Entities;
using AccountingManagement.Infrastructure.Data;
using MongoDB.Driver;
namespace AccountingManagement.Infrastructure
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _database;

            public MongoDbContext(string connectionString, string databaseName)
            {
                var client = new MongoClient(connectionString);
                _database = client.GetDatabase(databaseName);
            }

            public IMongoCollection<User> Users => _database.GetCollection<User>("Users");

            public IMongoCollection<Transaction> Transactions => _database.GetCollection<Transaction>("Transactions");

         }
    }
