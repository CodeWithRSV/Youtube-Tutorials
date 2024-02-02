using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Services;


namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            this._superHeroService = superHeroService;
        }
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        {
            return Ok(_superHeroService.GetSuperHeroes());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSuperHeroById(int id)
        {
            SuperHero? superHero = _superHeroService.GetSuperHeroById(id);
            if(superHero == null)
                return NotFound("SuperHero not found for this id");
            return Ok(superHero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddSuperHero(SuperHero hero)
        {
            return Ok(_superHeroService.AddSuperHero(hero));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateSuperHero(int id, SuperHero newHero)
        {
            var heroes = _superHeroService.UpdateSuperHero(id, newHero);
            if (heroes == null)
                return NotFound("SuperHero not found for this id");
            return Ok(heroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero(int id)
        {
            var heroes = _superHeroService.DeleteSuperHero(id);
            if (heroes == null)
                return NotFound("SuperHero not found for this id");
            return Ok(heroes);
        }

    }
}
