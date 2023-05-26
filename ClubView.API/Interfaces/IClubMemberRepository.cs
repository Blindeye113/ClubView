using ClubView.Library.Models;

namespace ClubView.API.Interfaces
{
    public interface IClubMemberRepository
    {
        Task<ClubMember> GetByIdAsync(int id);
        Task<List<ClubMember>> GetAllAsync();
        Task AddAsync(ClubMember member);
        Task UpdateAsync(ClubMember member);
        Task DeleteAsync(int id);
    }
}