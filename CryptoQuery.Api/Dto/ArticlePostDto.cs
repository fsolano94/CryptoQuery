using System.Collections.Generic;
using CryptoQuery.Api.Models;

namespace CryptoQuery.Api.Dto
{
    public class ArticlePostDto
    {
        public List<string> Topics { get; set; }
        public string PublishedAt { get; set; }
        public string Author { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public int Complexity { get; set; }
        public int Quality { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
    }
}
