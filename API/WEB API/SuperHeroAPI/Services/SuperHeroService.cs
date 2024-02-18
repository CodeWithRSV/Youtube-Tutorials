
using SuperHeroAPI.Data;

namespace SuperHeroAPI.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext _datacontext;

        public SuperHeroService(DataContext datacontext)
        {
            _datacontext = datacontext;
        }

        public async Task<List<SuperHero>> AddSuperHeroAsync(SuperHero hero)
        {
            await _datacontext.SuperHeroes.AddAsync(hero);
            await _datacontext.SaveChangesAsync();
            return await _datacontext.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>?> DeleteSuperHeroAsync(int id)
        {
            SuperHero? superHero = await _datacontext.SuperHeroes.FindAsync(id);
            if (superHero == null)
                return null;
            _datacontext.SuperHeroes.Remove(superHero);
            await _datacontext.SaveChangesAsync();
            return await _datacontext.SuperHeroes.ToListAsync();
        }

        public async Task<SuperHero?> GetSuperHeroByIdAsync(int id)
        {
            SuperHero? superHero = await _datacontext.SuperHeroes.FindAsync(id);
            if (superHero == null)
                return null;
            return superHero;
        }

        public async Task<List<SuperHero>> GetSuperHeroesAsync()
        {
            return await _datacontext.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>?> UpdateSuperHeroAsync(int id, SuperHero newHero)
        {
            SuperHero? superHero = await _datacontext.SuperHeroes.FindAsync(id);
            if (superHero == null)
                return null;
            superHero.Name = newHero.Name;
            superHero.FirstName = newHero.FirstName;
            superHero.LastName = newHero.LastName;
            superHero.Place = newHero.Place;
            await _datacontext.SaveChangesAsync();
            return await _datacontext.SuperHeroes.ToListAsync();
        }
    }
}
