using Microsoft.EntityFrameworkCore;
using PracticeDonGU_Back.Models;

namespace PracticeDonGU_Back.Contexts
{
    public class PracticeDbContext : DbContext
    {
        public PracticeDbContext() { }

        public PracticeDbContext(DbContextOptions<PracticeDbContext> options) : base(options) { }

        public virtual DbSet<Mineral> Minerals { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Record> Records { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Record>()
                .HasKey(r => new { r.RecordDate, r.MineralId });

            modelBuilder.Entity<Mineral>()
                .HasMany(m => m.Records)
                .WithOne(r => r.Mineral)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Unit>()
                .HasMany(m => m.Records)
                .WithOne(u => u.Unit)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }
    }
}
