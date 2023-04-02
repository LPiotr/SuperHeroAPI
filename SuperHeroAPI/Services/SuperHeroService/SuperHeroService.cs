using MongoDB.Bson;
using MongoDB.Driver;
using SuperHeroAPI.Data;
using SuperHeroAPI.Data.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        //private IMongoDatabase _database;   
        //private IMongoCollection<SuperHero> _superHeroes;

        //public SuperHeroService(IMongoCollection settings)
        //{
        //    var client = new MongoClient();
        //    var database = client.GetDatabase();

        //    _superHeroes = database.GetCollection<SuperHero>();
        //}

        private static List<SuperHero> _superHeroes = new()
        {
            new SuperHero
            {
                    Id = 1,
                    Name = "Spider Man",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "New York City"
            },
            new SuperHero
            {
                    Id = 2,
                    Name = "Iron Man",
                    FirstName = "Tony",
                    LastName = "Stark",
                    Place = "Malibu"
            }
        };
        public List<SuperHero> DeleteHero(int id)
        {
            var hero = _superHeroes.Find(x => x.Id == id);
            if (hero == null)
                return null;

            _superHeroes.Remove(hero);

            return _superHeroes;
        }

        public List<SuperHero> GetAllHeroes()
        {
            return _superHeroes;
        }

        public SuperHero GetSingleHero(int id)
        {
            var hero = _superHeroes.Find(x => x.Id == id);
            if (hero == null)
                return null;

            return hero;
        }

        public List<SuperHero> NewHero(SuperHero hero)
        {
            _superHeroes.Add(hero);
            return _superHeroes;
        }

        public List<SuperHero> UpdateHero(int id, SuperHero request)
        {
            var hero = _superHeroes.Find(x => x.Id == id);
            if (hero == null)
                return null;

            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;

            return _superHeroes;
        }
    }
}