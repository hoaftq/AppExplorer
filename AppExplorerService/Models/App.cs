using System;
using System.Collections.Generic;

class App
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string ShortDescription { get; set; }

    public string Description { get; set; }

    public string ImagePath { get; set; }

    public Level Level { get; set; }

    public AppUrl Urls { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }


    public ICollection<AppLanguage> AppLanguages { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }
}