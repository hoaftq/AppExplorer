using System;
using System.Collections.Generic;

namespace Service.Dtos
{
    public class AppDetailsDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public AppInfoDto AppInfo { get; set; }

        public IReadOnlyList<LanguageDto> Languages { get; set; }

        public AppUrlsDto AppUrls { get; set; }

        public CategoryDto Category { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }

    public class AppInfoDto
    {
        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }
    }

    public class AppUrlsDto
    {
        public string SourceUrl { get; set; }

        public string ProductUrl { get; set; }

        public string LibUrl { get; set; }

        public string DownloadUrl { get; set; }

        public string ArticleUrl { get; set; }
    }
}