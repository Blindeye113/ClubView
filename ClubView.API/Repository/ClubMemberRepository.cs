using Microsoft.EntityFrameworkCore;
using ClubView.API.Interfaces;
using ClubView.Library.Models;
using ClubView.API.DataAccess;

namespace ClubView.API.Repository
{
    public class ClubMemberRepository : IClubMemberRepository
    {
        private readonly DataContext _dbContext;

        public ClubMemberRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ClubMember> GetByIdAsync(int id)
        {
            return await _dbContext.Set<ClubMember>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ClubMember>> GetAllAsync()
        {
            return await _dbContext.Set<ClubMember>().ToListAsync();
        }

        public async Task AddAsync(ClubMember member)
        {
            await _dbContext.Set<ClubMember>().AddAsync(member);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ClubMember member)
        {
            _dbContext.Entry(member).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var member = await _dbContext.Set<ClubMember>().FirstOrDefaultAsync(x => x.Id == id);

            if (member != null)
            {
                _dbContext.Set<ClubMember>().Remove(member);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
