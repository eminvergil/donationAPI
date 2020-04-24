using Microsoft.EntityFrameworkCore;

namespace donationAPI.Models {
    public class DonationDbContext : DbContext {
        public DonationDbContext (DbContextOptions<DonationDbContext> options) : base (options) { }

        public DbSet<DCanditate> DCanditates { get; set; }
    }
}