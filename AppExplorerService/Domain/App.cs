using Domain.Common;

namespace Domain
{
    public class App : Entity
    {
        public string Name { get; }

        public AppInfo AppInfo { get; }

        public AppUrls AppUrls { get; }

        public Category Category { get; }

        public IReadOnlyList<Language> Languages { get; }

        private App()
        {
        }

        public App(string name,
            AppInfo appInfo,
            AppUrls appUrls,
            Category category,
            IReadOnlyList<Language> languages)
        {
            Name = name;
            AppInfo = appInfo;
            AppUrls = appUrls;
            Category = category;
            Languages = languages;
        }
    }
}