using Microsoft.EntityFrameworkCore;
using MSt.Context.Configuration;
using MSt.Data.Entity;

namespace MSt.Context
{
    public class MusicStoreDbContext : DbContext
    {
        public MusicStoreDbContext(DbContextOptions<MusicStoreDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<RoleClaim> RoleClaims { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserRoleConfig());
        }

    }
}
