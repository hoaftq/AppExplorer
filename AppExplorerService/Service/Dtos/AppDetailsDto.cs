using System;
using System.Collections.Generic;

namespace Service.Dtos
{
    public class AppDetailsDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public AppInfoDto AppInfo { get; set; }

        public IList<LanguageDto> Languages { get; set; }

        public AppUrlsDto AppUrls { get; set; }

        public CategoryDto Category { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }

    public class AppInfoDto
    {
        public string ShortDescription { get; }

        public string Description { get; }

        public string ImagePath { get; }
    }

    public class AppUrlsDto
    {
        public string SourceUrl { get; }

        public string ProductUrl { get; }

        public string LibUrl { get; }

        public string DownloadUrl { get; }

        public string ArticleUrl { get; }
    }
}