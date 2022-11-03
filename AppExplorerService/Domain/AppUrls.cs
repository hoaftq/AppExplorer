using Domain.Common;

namespace Domain
{
    public class AppUrls : ValueObject<AppUrls>
    {
        public string SourceUrl { get; }

        public string ProductUrl { get; }

        public string LibUrl { get; }

        public string DownloadUrl { get; }

        public string ArticleUrl { get; }

        public AppUrls(
            string sourceUrl,
            string productUrl = null,
            string libUrl = null,
            string downloadUrl = null,
            string articleUrl = null)
        {
            SourceUrl = sourceUrl ?? throw new ArgumentNullException(nameof(sourceUrl));
            ProductUrl = productUrl;
            LibUrl = libUrl;
            DownloadUrl = downloadUrl;
            ArticleUrl = articleUrl;
        }

        public override int GetValueHashCode()
        {
            throw new NotImplementedException();
        }

        public override bool ValueEquals(AppUrls t)
        {
            throw new NotImplementedException();
        }
    }
}