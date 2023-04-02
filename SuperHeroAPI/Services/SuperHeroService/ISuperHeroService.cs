using MongoDB.Bson;
using SuperHeroAPI.Data.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        List<SuperHero> GetAllHeroes();
        SuperHero GetSingleHero(int id);
        List<SuperHero> NewHero(SuperHero hero);
        List<SuperHero> UpdateHero(int id, SuperHero request);
        List<SuperHero> DeleteHero(int id);
    }
}
