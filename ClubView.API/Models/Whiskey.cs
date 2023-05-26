
namespace ClubView.API.Models
{
    public class Whiskey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Base64Image { get; set; }
        public int ClubMemberId { get; set; }

    }
}
