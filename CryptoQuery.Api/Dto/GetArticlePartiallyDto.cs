using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoQuery.Api.Dto
{
    public class GetArticlePartiallyDto
    {
        public Guid Id { get; set; }
        public List<string> Topics { get; set; }
        public string PublishedAt { get; set; }
        public string Author { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public int Complexity { get; set; }
        public int Quality { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
