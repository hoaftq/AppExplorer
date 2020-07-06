using System;
using System.Collections.Generic;

class App
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string ShortDescription { get; set; }

    public string Description { get; set; }

    public string ImagePath { get; set; }

    public int Level { get; set; }

    public string Url { get; set; }

    public string SourceUrl { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }


    public ICollection<Language> Languages { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }
}