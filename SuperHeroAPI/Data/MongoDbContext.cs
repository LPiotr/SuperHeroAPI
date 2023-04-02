using MongoDB.Driver;
using SuperHeroAPI.Data.Models;

namespace SuperHeroAPI.Data

{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("Mongo1");
        }

        public IMongoCollection<SuperHero> SuperHereos => _database.GetCollection<SuperHero>("SuperHeroes");

    }
}
