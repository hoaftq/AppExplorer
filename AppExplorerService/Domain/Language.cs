using Domain.Common;

namespace Domain
{
    public class Language : Entity
    {
        public string Name { get; private set; }

        public IReadOnlyList<App> Apps { get; } = new List<App>();

        private Language()
        {
        }

        public Language(string name)
        {
            Update(name);
        }

        public void Update(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name must not be empty or spaces", nameof(name));
            }

            Name = name;
        }
    }
}