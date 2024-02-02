
namespace SuperHeroAPI.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private static List<SuperHero> superHeroes = new List<SuperHero>
        {
            new SuperHero { Id = 1, Name = "Spider Man", FirstName="Peter", LastName="Parker", Place = "New York"},
            new SuperHero { Id = 2, Name = "BatMan", FirstName="Bruce", LastName="Wayne", Place = "Gotham"}
        };
        public List<SuperHero> AddSuperHero(SuperHero hero)
        {
            superHeroes.Add(hero);
            return superHeroes;
        }

        public List<SuperHero>? DeleteSuperHero(int id)
        {
            SuperHero? superHero = superHeroes.Find(x => x.Id == id);
            if (superHero == null)
                return null;
            superHeroes.Remove(superHero);
            return superHeroes;
        }

        public SuperHero? GetSuperHeroById(int id)
        {
            SuperHero? superHero = superHeroes.Find(x => x.Id == id);
            if (superHero == null)
                return null;
            return superHero;
        }

        public List<SuperHero> GetSuperHeroes()
        {
            return superHeroes;
        }

        public List<SuperHero>? UpdateSuperHero(int id, SuperHero newHero)
        {
            SuperHero? superHero = superHeroes.Find(x => x.Id == id);
            if (superHero == null)
                return null;
            superHero.Name = newHero.Name;
            superHero.FirstName = newHero.FirstName;
            superHero.LastName = newHero.LastName;
            superHero.Place = newHero.Place;
            return superHeroes;
        }
    }
}
