using ClubView.Library.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubView.API.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Whiskey> Whiskey { get; set; }
        public DbSet<ClubMember> ClubMember { get; set; }
        public DbSet<Club> Club { get; set; }
        public DbSet<MemberClub> MemberClub { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MemberClub>()
                .HasKey(mc => new { mc.MemberId, mc.ClubId });

            modelBuilder.Entity<MemberClub>()
                .HasOne(mc => mc.ClubMember)
                .WithMany(m => m.MemberClubs)
                .HasForeignKey(mc => mc.MemberId);

            modelBuilder.Entity<MemberClub>()
                .HasOne(mc => mc.Club)
                .WithMany(c => c.MemberClubs)
                .HasForeignKey(mc => mc.ClubId);
        }
    }
}
