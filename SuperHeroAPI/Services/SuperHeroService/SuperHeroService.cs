using MongoDB.Driver;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly IMongoCollection<SuperHero> _superHeroes;
        public SuperHeroService(ISuperHeroDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _superHeroes = database.GetCollection<SuperHero>(settings.SuperHeroesCollectionName);
        }

        public SuperHero Create(SuperHero hero)
        {
            _superHeroes.InsertOne(hero);
            return hero;
        }

        public List<SuperHero> Get()
        {
            return _superHeroes.Find(heroes => true).ToList();
        }

        public SuperHero Get(string id)
        {
            return _superHeroes.Find(hero => hero.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _superHeroes.DeleteOne(hero => hero.Id == id);
        }

        public void Update(string id, SuperHero hero)
        {
            _superHeroes.ReplaceOne(hero => hero.Id == id, hero);
        }
    }
}