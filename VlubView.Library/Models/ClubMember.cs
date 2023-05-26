
namespace ClubView.Library.Models
{
    public class ClubMember
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<MemberClub> MemberClubs { get; set; }
    }
}
