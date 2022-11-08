using Domain.Common;

namespace Domain
{
    public class AppUrls : ValueObject<AppUrls>
    {
        public string SourceUrl { get; private set; }

        public string ProductUrl { get; private set; }

        public string LibUrl { get; private set; }

        public string DownloadUrl { get; private set; }

        public string ArticleUrl { get; private set; }

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
            return HashCode.Combine(SourceUrl, ProductUrl, LibUrl, DownloadUrl, ArticleUrl);
        }

        public override bool ValueEquals(AppUrls t)
        {
            return SourceUrl == t.SourceUrl
                && ProductUrl == t.ProductUrl
                && LibUrl == t.LibUrl
                && DownloadUrl == t.DownloadUrl
                && ArticleUrl == t.ArticleUrl;
        }
    }
}