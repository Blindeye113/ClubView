using ClubView.API.Interfaces;
using ClubView.API.Models;
using Microsoft.EntityFrameworkCore;
using ClubView.API.DataAccess;

namespace ClubView.API.Repository
{
    public class ClubRepository : IClubRepository
    {
        private readonly DataContext _dbContext;

        public ClubRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Club> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Club>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Club>> GetAllAsync()
        {
            return await _dbContext.Set<Club>().ToListAsync();
        }

        public async Task AddAsync(Club club)
        {
            await _dbContext.Set<Club>().AddAsync(club);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Club club)
        {
            _dbContext.Set<Club>().Update(club);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var club = await GetByIdAsync(id);
            _dbContext.Set<Club>().Remove(club);
            await _dbContext.SaveChangesAsync();
        }
    }
}
