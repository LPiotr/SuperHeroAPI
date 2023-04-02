using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using SuperHeroAPI.Data.Models;
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
            //return Ok(result);
        }

        /// <summary>
        /// Get one hero specified by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var result = await Task.FromResult(_superHeroService.GetSingleHero(id));
            if (result == null)
                return NotFound($"Nie mam takiego id {id} w bazie.");
            
            return Ok(result);
        }

        /// <summary>
        /// Create new hero
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> NewHero(SuperHero hero)
        {
            var result = await Task.FromResult(_superHeroService.NewHero(hero));
            
            return Ok(result);
        }

        /// <summary>
        /// Update hero
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// 
        [HttpPut("{id}")]
        public async Task<ActionResult<SuperHero>> UpdateHero(int id, SuperHero request)
        {
            var result = await Task.FromResult(_superHeroService.UpdateHero(id, request));
            if (result != null)
                return Ok(result);

            return NotFound($"Nie mam takiego id {id} w bazie.");
        }

        /// <summary>
        /// Delete hero
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperHero>> DeleteHero(int id)
        {
            var result = _superHeroService.DeleteHero(id);
            if (result != null)
                return Ok(result);

            return NotFound($"Heros o tym id: {id} nie znajduje się w bazie");
        }
    }
}

