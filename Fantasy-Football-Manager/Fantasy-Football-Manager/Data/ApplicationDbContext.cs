using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Fantasy_Football_Manager.Models;

namespace Fantasy_Football_Manager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public DbSet<User> Users { get; set; }
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword

        public DbSet<Echipa> Echipe { get; set; }

        public DbSet<Jucator> Jucatori { get; set; }

        public DbSet<Liga> Ligi { get; set; }

        public DbSet<StatisticiJucator> StatisticiJucatori { get; set; }

        public DbSet<UserLiga> UsersLigi { get; set; } 

        public DbSet<EchipaJucator> EchipeJucatori { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserLiga>()
                .HasKey(ul => new { ul.UserId, ul.LigaId });
            modelBuilder.Entity<UserLiga>()
                .HasOne(ul => ul.User)
                .WithMany(u => u.Ligi)
                .HasForeignKey(ul => ul.UserId);
            modelBuilder.Entity<UserLiga>()
                .HasOne(ul => ul.Liga)
                .WithMany(l => l.Users)
                .HasForeignKey(ul => ul.LigaId);

            modelBuilder.Entity<EchipaJucator>()
                .HasKey(ej => new { ej.EchipaId, ej.JucatorId });
            modelBuilder.Entity<EchipaJucator>()
                .HasOne(ej => ej.Echipa)
                .WithMany(e => e.Jucatori)
                .HasForeignKey(ej => ej.EchipaId);
            modelBuilder.Entity<EchipaJucator>()
                .HasOne(ej => ej.Jucator)
                .WithMany(j => j.Echipe)
                .HasForeignKey(ej => ej.JucatorId);
        }
    }
}
