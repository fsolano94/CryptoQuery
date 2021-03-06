﻿using CryptoQuery.Api.Models;

namespace CryptoQuery.Api.Dto
{
    public class ArticlePostDto : Resource
    {
        public string UpdatedAt { get; set; }
        public string CreatedAt { get; set; }
        public string DateOfPublification { get; set; }
        public string Author { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Topic { get; set; }
        public int Complexity { get; set; }
        public int Quality { get; set; }

    }
}
