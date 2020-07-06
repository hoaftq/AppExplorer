using Microsoft.EntityFrameworkCore;

class AppExplorerContext : DbContext
{
    public DbSet<App> Apps { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Language> Languages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AppExplorer;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    }
}