using Microsoft.EntityFrameworkCore;
using ClubView.API.Interfaces;
using ClubView.API.Models;
using ClubView.API.DataAccess;

namespace ClubView.API.Repository
{
    public class WhiskeyRepository : IWhiskeyRepository
    {
        private readonly DataContext _dbContext;

        public WhiskeyRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Whiskey> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Whiskey>().FindAsync(id);
        }

        public async Task<List<Whiskey>> GetAllAsync()
        {
            return await _dbContext.Set<Whiskey>().ToListAsync();
        }

        public async Task AddAsync(Whiskey whiskey)
        {
            await _dbContext.Set<Whiskey>().AddAsync(whiskey);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Whiskey whiskey)
        {
            _dbContext.Entry(whiskey).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var whiskey = await GetByIdAsync(id);
            _dbContext.Set<Whiskey>().Remove(whiskey);
            await _dbContext.SaveChangesAsync();
        }
    }
}
