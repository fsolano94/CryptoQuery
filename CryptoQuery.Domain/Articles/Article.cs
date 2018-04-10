using System;

namespace CryptoQuery.Domain.Articles
{
    public class Article
    {
        public Guid Id { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Author { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public string Topics { get; set; }
        public int Complexity { get; set; }
        public int Quality { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
    }
}
