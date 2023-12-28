using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> superHeroes = new List<SuperHero>
        {
            new SuperHero { Id = 1, Name = "Spider Man", FirstName="Peter", LastName="Parker", Place = "New York"},
            new SuperHero { Id = 2, Name = "BatMan", FirstName="Bruce", LastName="Wayne", Place = "Gotham"}
        };
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        {
            return Ok(superHeroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSuperHeroById(int id)
        {
            SuperHero? superHero = superHeroes.Find(x => x.Id == id);
            if(superHero == null)
                return NotFound("SuperHero not found for this id");
            return Ok(superHero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddSuperHero(SuperHero hero)
        {
            superHeroes.Add(hero);
            return Ok(superHeroes);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateSuperHero(int id, SuperHero newHero)
        {
            SuperHero? superHero = superHeroes.Find(x => x.Id == id);
            if (superHero == null)
                return NotFound("SuperHero not found for this id");
            superHero.Name = newHero.Name;
            superHero.FirstName = newHero.FirstName;
            superHero.LastName = newHero.LastName;
            superHero.Place = newHero.Place;
            return Ok(superHeroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero(int id)
        {
            SuperHero? superHero = superHeroes.Find(x => x.Id == id);
            if (superHero == null)
                return NotFound("SuperHero not found for this id");
            superHeroes.Remove(superHero);
            return Ok(superHeroes);
        }

    }
}
