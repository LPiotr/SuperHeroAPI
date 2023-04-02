using MongoDB.Bson;
using SuperHeroAPI.Data.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        List<SuperHero> GetAllHeroes();
        SuperHero GetSingleHero(ObjectId id);
        List<SuperHero> NewHero(SuperHero hero);
        List<SuperHero> UpdateHero(ObjectId id, SuperHero request);
        List<SuperHero> DeleteHero(ObjectId id);
    }
}
