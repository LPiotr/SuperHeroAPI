using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private static List<SuperHero> superHeroes = new List<SuperHero>()
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


        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            return Ok(superHeroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero == null) 
                return NotFound($"Nie mam takiego id {id} w bazie.");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> NewHero(SuperHero hero)
        {
            superHeroes.Add(hero);  
            return Ok(hero); 
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SuperHero>> UpdateHero(int id, SuperHero request)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero == null)
                return NotFound($"Nie mam takiego id {id} w bazie.");
            
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;
            
            return Ok(superHeroes);
        }
    }
}

