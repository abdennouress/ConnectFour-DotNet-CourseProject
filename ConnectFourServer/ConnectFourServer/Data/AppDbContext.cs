// ------------------------------------------------------------
// Authors: [Yosi Ben Shushan] & [Noam Ben Benjamin]
// Project: Connect Four Server - 10212 Course Project
// Date: August 2025
// Description: Part of the semester project for the .NET course.
// ------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using ConnectFourServer.Models;

namespace ConnectFourServer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Move> Moves { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasOne(g => g.Player)
                .WithMany(p => p.Games)
                .HasForeignKey("PlayerId")
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
