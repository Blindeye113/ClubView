
namespace ClubView.API.Models
{
    public class MemberClub
    {
        public int ClubId { get; set; }
        public Club Club { get; set; }

        public int MemberId { get; set; }
        public ClubMember ClubMember { get; set; }
    }
}
