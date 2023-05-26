using ClubView.API.Models;

namespace ClubView.API.Interfaces
{
    public interface IWhiskeyRepository
    {
        Task<Whiskey> GetByIdAsync(int id);
        Task<List<Whiskey>> GetAllAsync();
        Task AddAsync(Whiskey whiskey);
        Task UpdateAsync(Whiskey whiskey);
        Task DeleteAsync(int id);
    }
}
