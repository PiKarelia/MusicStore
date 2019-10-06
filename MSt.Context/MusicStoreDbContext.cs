using Microsoft.EntityFrameworkCore;
using MSt.Context.Configuration;
using MSt.Data.Entity;
using System;

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

            modelBuilder.Entity<Role>().HasData(
            new Role
            {
                Guid = new Guid("e06f16e2-1af4-4d62-9790-ceb7b705298f"),
                Name = "artist"
            });

            modelBuilder.Entity<RoleClaim>().HasData(
           new RoleClaim
           {
               RoleGuid = new Guid("e06f16e2-1af4-4d62-9790-ceb7b705298f"),
               Guid = new Guid("2bddc6f2-78c2-4c39-b25a-f4bfa9933070"),
               ClaimType = "music",
               ClaimValue = "add"
           });

            modelBuilder.Entity<User>().HasData(new User
            {
                Guid = new Guid("e2d11f90-81ed-4eb8-a691-377396be8f6c"),
                Email = "dj.music@yopmail.com",
                Password = "73fb1f36b321b11a7d9606d5b22e7701",//dj123!dj
                Login = "dj.music@yopmail.com"
            });

            modelBuilder.Entity<UserRole>().HasData(
            new UserRole
            {
                UserGuid = new Guid("e2d11f90-81ed-4eb8-a691-377396be8f6c"),
                RoleGuid = new Guid("e06f16e2-1af4-4d62-9790-ceb7b705298f"),
            });

        }
    }
}
