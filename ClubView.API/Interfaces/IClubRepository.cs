using ClubView.API.Models;

namespace ClubView.API.Interfaces
{
    public interface IClubRepository
    {
        Task<Club> GetByIdAsync(int id);
        Task<List<Club>> GetAllAsync();
        Task AddAsync(Club club);
        Task UpdateAsync(Club club);
        Task DeleteAsync(int id);
    }
}
