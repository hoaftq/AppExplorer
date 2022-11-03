using Domain.Common;

namespace Domain
{
    public class Language : Entity
    {
        public string Name { get; }

        public IReadOnlyList<App> Apps { get; }

        private Language()
        {
        }

        public Language(string name, IReadOnlyList<App> apps)
        {
            Name = name;
            Apps = apps;
        }
    }
}