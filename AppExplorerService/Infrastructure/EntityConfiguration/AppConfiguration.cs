using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    internal class AppConfiguration : BaseConfiguration<App>
    {
        public override void Configure(EntityTypeBuilder<App> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(App));
            builder.Property(a => a.Name).IsRequired();
            builder.OwnsOne(a => a.AppInfo, a =>
            {
                a.Property(ai => ai.ShortDescription);
                a.Property(ai => ai.Description);
                a.Property(ai => ai.ImagePath);
            });
            builder.Navigation(a => a.AppInfo).IsRequired();

            builder.OwnsOne(a => a.AppUrls, a =>
            {
                a.Property(au => au.ProductUrl);
                a.Property(au => au.DownloadUrl);
                a.Property(au => au.ArticleUrl);
                a.Property(au => au.SourceUrl);
                a.Property(au => au.LibUrl);
            });
            builder.Navigation(a => a.AppUrls).IsRequired();

            builder.HasOne(a => a.Category).WithMany();
            builder.HasMany(a => a.Languages)
                .WithMany(l => l.Apps)
                .UsingEntity<Dictionary<string, object>>(
                    j => j.HasOne<Language>().WithMany().HasForeignKey("LanguageId"),
                    j => j.HasOne<App>().WithMany().HasForeignKey("AppId")
                );
        }
    }
}
