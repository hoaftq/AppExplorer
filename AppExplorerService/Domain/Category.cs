using Domain.Common;

namespace Domain
{
    public class Category : Entity
    {
        public string Name { get; private set; }

        public Category(string name)
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