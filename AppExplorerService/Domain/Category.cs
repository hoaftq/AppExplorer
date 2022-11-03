using Domain.Common;

namespace Domain
{
    public class Category : Entity
    {
        public string Name { get; }

        private Category()
        {
        }

        public Category(string name)
        {
            Name = name;
        }
    }
}