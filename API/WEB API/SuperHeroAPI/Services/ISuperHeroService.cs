namespace SuperHeroAPI.Services
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetSuperHeroesAsync();
        Task<SuperHero?> GetSuperHeroByIdAsync(int id);
        Task<List<SuperHero>> AddSuperHeroAsync(SuperHero hero);
        Task<List<SuperHero>?> UpdateSuperHeroAsync(int id, SuperHero newHero);
        Task<List<SuperHero>?> DeleteSuperHeroAsync(int id);
    }
}
