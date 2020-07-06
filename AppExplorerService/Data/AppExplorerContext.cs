using Microsoft.EntityFrameworkCore;

class AppExplorerContext : DbContext
{
    public DbSet<App> Apps { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Language> Languages { get; set; }

    public AppExplorerContext(DbContextOptions<AppExplorerContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<App>(b =>
        {
            b.ToTable("App");
        });

        modelBuilder.Entity<Category>(b =>
        {
            b.ToTable("Category");
            b.Property(e => e.Name).HasMaxLength(200).IsRequired();
        });

        modelBuilder.Entity<Language>().ToTable("Language")
                                       .HasData(
                                                    new Language() { Id = 1, Name = "C#" },
                                                    new Language() { Id = 2, Name = "Java" },
                                                    new Language() { Id = 3, Name = "Javascript" },
                                                    new Language() { Id = 4, Name = "Typescript" },
                                                    new Language() { Id = 5, Name = "HTML" },
                                                    new Language() { Id = 6, Name = "CSS" },
                                                    new Language() { Id = 7, Name = "SCSS" },
                                                    new Language() { Id = 8, Name = "Angular" },
                                                    new Language() { Id = 9, Name = "JQuery" },
                                                    new Language() { Id = 10, Name = "Bootstrap" },
                                                    new Language() { Id = 11, Name = "Asp.Net Core API" },
                                                    new Language() { Id = 12, Name = "Asp.Net Core MVC" },
                                                    new Language() { Id = 13, Name = "Asp.Net Core Razor" },
                                                    new Language() { Id = 14, Name = "Entity Framework Core" }
                                                );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AppExplorer;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    }
}
