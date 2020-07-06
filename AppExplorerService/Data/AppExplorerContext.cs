using Microsoft.EntityFrameworkCore;

class AppExplorerContext : DbContext
{
    public DbSet<App> Apps { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Language> Languages { get; set; }

    public DbSet<AppLanguage> AppLanguages { get; set; }

    public AppExplorerContext(DbContextOptions<AppExplorerContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<App>(b =>
        {
            b.ToTable("App");
            b.Property(e => e.Name).HasMaxLength(100).IsRequired();
            b.HasIndex(e => e.Name).IsUnique(); // Name is unique
            b.Property(e => e.ShortDescription).HasMaxLength(1000).IsRequired();
            b.Property(e => e.Description).IsRequired();
            b.Property(e => e.ImagePath).HasMaxLength(255).IsUnicode(false);
            b.Property(e => e.Level); // int is required by default
            b.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()"); // default value implies value genarated on adding
            b.Property(e => e.UpdatedDate).HasDefaultValueSql("GETDATE()").ValueGeneratedOnUpdate();

            b.OwnsOne(e => e.Urls, ob =>
            {
                ob.Property(e => e.ArticleUrl).HasColumnName("ArticleUrl").HasMaxLength(255).IsUnicode(false);
                ob.Property(e => e.DeployedUrl).HasColumnName("DeployedUrl").HasMaxLength(255).IsUnicode(false);
                ob.Property(e => e.DownloadUrl).HasColumnName("DownloadUrl").HasMaxLength(255).IsUnicode(false);
                ob.Property(e => e.LibUrl).HasColumnName("LibUrl").HasMaxLength(255).IsUnicode(false);
                ob.Property(e => e.SourceUrl).HasColumnName("SourceUrl").HasMaxLength(255).IsUnicode(false).IsRequired();
            });
        });

        modelBuilder.Entity<Category>(b =>
        {
            b.ToTable("Category");
            b.Property(e => e.Name).HasMaxLength(200).IsRequired();
        });

        modelBuilder.Entity<Language>().ToTable("Language").Property(e => e.Name).HasMaxLength(50);
        modelBuilder.Entity<Language>().HasData(
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

        modelBuilder.Entity<AppLanguage>().ToTable("AppLanguage").HasKey(e => new { e.AppId, e.LanguageId });

        modelBuilder.Entity<User>(b =>
        {
            b.Property(e => e.UserId).HasMaxLength(100).IsUnicode(false).IsRequired();
            b.Property<string>("Password").HasMaxLength(100).IsUnicode(false).IsRequired();
            b.HasData(new { UserId = "admin", Password = "password" });
        });
    }
}
