using Domain;
using Domain.Common;
using Infrastructure.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        private readonly string connectionString;

        public DbSet<App> Apps { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Language> Languages { get; set; }

        public AppDbContext(string connectionString)
        {
            this.connectionString = connectionString;

            ChangeTracker.StateChanged += ChangeTracker_StateChanged;
            ChangeTracker.Tracked += ChangeTracker_Tracked;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
        }

        private void ChangeTracker_Tracked(object? sender, Microsoft.EntityFrameworkCore.ChangeTracking.EntityTrackedEventArgs e)
        {
            if (e.Entry.Entity is Entity entity && e.Entry.State == EntityState.Added)
            {
                entity.CreatedDate = entity.UpdatedDate = DateTime.UtcNow;
            }
        }

        private void ChangeTracker_StateChanged(object? sender, Microsoft.EntityFrameworkCore.ChangeTracking.EntityStateChangedEventArgs e)
        {
            if (e.Entry.Entity is Entity entity && e.Entry.State == EntityState.Modified)
            {
                entity.UpdatedDate = DateTime.UtcNow;
            }
        }
    }
}
