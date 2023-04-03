using MongoDB.Driver;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Data

{
    public class DataContext 
    {
        private readonly IMongoCollection<SuperHero> _superHeroes;

        public DataContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("SuperHeroesDb");

            try
            {
                _superHeroes = database.GetCollection<SuperHero>("SuperHeroes");
            }
            catch(MongoException ex)
            {
                throw new ApplicationException("Brak połączenia z bazą MongoDB", ex);
            }
        }

        public List<SuperHero> SuperHeroes => _superHeroes.Find(h => true).ToList();

        public SuperHero GetSuperHeroById(string id) => _superHeroes.Find(h => h.Id == id).FirstOrDefault();

        public SuperHero CreateSuperHero(SuperHero hero)
        {
            _superHeroes.InsertOne(hero);
            
            return hero;
        }

        public void UpdateSuperHero(string id, SuperHero heroIn) => _superHeroes.ReplaceOne(h => h.Id == id, heroIn);

        public void DeleteSuperHero(string id) => _superHeroes.DeleteOne(h => h.Id == id);
    }
}
