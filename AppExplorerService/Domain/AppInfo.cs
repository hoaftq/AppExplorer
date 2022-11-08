using Domain.Common;

namespace Domain
{
    public class AppInfo : ValueObject<AppInfo>
    {
        public string ShortDescription { get; private set; }

        public string Description { get; private set; }

        public string ImagePath { get; private set; }

        public AppInfo(string shortDescription, string description, string imagePath = null)
        {
            ShortDescription = shortDescription ?? throw new ArgumentNullException(nameof(shortDescription));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            ImagePath = imagePath;
        }

        public override int GetValueHashCode()
        {
            return HashCode.Combine(ShortDescription, Description, ImagePath);
        }

        public override bool ValueEquals(AppInfo t)
        {
            return ShortDescription == t.ShortDescription
                && Description == t.Description
                && ImagePath == t.ImagePath;
        }
    }
}
