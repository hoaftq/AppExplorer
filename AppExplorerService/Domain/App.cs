using Domain.Common;

namespace Domain
{
    // TODO private set is for mapper
    public class App : Entity
    {
        public string Name { get; private set; }

        public AppInfo AppInfo { get; private set; }

        public AppUrls AppUrls { get; private set; }

        public Category Category { get; private set; }

        public IReadOnlyList<Language> Languages { get; } = new List<Language>();

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