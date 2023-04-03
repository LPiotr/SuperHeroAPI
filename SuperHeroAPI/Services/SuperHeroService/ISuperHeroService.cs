using MongoDB.Bson;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public interface ISuperHeroService
    {

        List<SuperHero> GetAllHeroes();
        SuperHero Get(string id);
        SuperHero Create(SuperHero hero);
        void Update(string id, SuperHero request);
        void Delete(string id);
    }
}
