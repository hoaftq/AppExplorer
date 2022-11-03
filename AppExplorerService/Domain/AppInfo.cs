using Domain.Common;

namespace Domain
{
    public class AppInfo : ValueObject<AppInfo>
    {
        public string ShortDescription { get; }

        public string Description { get; }

        public string ImagePath { get; }

        public AppInfo(string shortDescription, string description, string imagePath = null)
        {
            ShortDescription = shortDescription ?? throw new ArgumentNullException(nameof(shortDescription));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            ImagePath = imagePath;
        }

        public override int GetValueHashCode()
        {
            throw new NotImplementedException();
        }

        public override bool ValueEquals(AppInfo t)
        {
            throw new NotImplementedException();
        }
    }
}
