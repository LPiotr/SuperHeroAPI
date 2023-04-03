using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

using SuperHeroAPI.Models;
using SuperHeroAPI.Services.SuperHeroService;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;
        public SuperHeroController(ISuperHeroService superHeroService)
        {
           _superHeroService = superHeroService;

           ObjectIdSerializer objectIdSerializer = new();
        }

        /// <summary>
        /// Get list of all heroes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var result = await Task.FromResult(_superHeroService.GetAllHeroes());

            return await Task.FromResult(result);
        }

        /// <summary>
        /// Get one hero specified by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        [HttpGet("{id}")]
        public ActionResult<SuperHero> Get(string id)
        {
            var hero = _superHeroService.Get(id);
            if (hero == null)
            {
                return NotFound($"Nie mam takiego id {id} w bazie.");
            }
            
            return hero;
        }

        /// <summary>
        /// Create new hero
        /// </summary>
        /// <param name="hero"></param>
        /// <returns>Object collection</returns>
        [HttpPost]
        public ActionResult<SuperHero> Post([FromBody] SuperHero hero)
        {
            _superHeroService.Create(hero);

            return CreatedAtAction(nameof(Get), new { id = hero.Id }, hero);
        }

        /// <summary>
        /// Update hero
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        ///
        [HttpPut("{id}")]
        public ActionResult Put(string id, SuperHero hero)
        {
            var existingStudent =_superHeroService.Get(id);
            if (existingStudent == null)
            {
                return NotFound($"Nie mam takiego id {id} w bazie.");
            }
            
            _superHeroService.Update(id, hero);
            
            return NoContent();
        }

        /// <summary>
        /// Delete hero
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        //[HttpDelete("{id}")]
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            var hero = _superHeroService.Get(id);
            
            if (hero != null)
            {
                return NotFound($"Heros o tym id: {id} nie znajduje się w bazie");
            }

            _superHeroService.Delete(id);

            return Ok($"Heros o tym Id = {id} został usunięty");
        }
    }
}

