using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities.Blog 
{
    public class Tbl_Blog 
    {
        [Key]
        public int Id { get; set; }
        public string TitleBlog { get; set; }
        public int IdCtegoryBlog { get; set; }
        public string SummaryBlog { get; set; }
        public string ImageMainBlog { get; set; }
        public string FullTextBlog { get; set; }
        public string KeywordsBlog { get; set; }
        public string Language { get; set; }
    }
}