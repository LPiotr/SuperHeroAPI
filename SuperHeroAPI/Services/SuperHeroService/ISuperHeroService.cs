using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        List<SuperHero> Get();
        SuperHero Get(string id);
        SuperHero Create(SuperHero hero);
        void Update(string id, SuperHero request);
        void Remove(string id);
    }
}
