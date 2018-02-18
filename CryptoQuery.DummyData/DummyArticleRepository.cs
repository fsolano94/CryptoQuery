using CryptoQuery.Domain.Articles;
using System;
using System.Collections.Generic;

namespace CryptoQuery.DummyData
{
    public class DummyArticleRepository : IArticleRepository
    {
        public IEnumerable<Article> GetArticles()
        {
            return new List<Article>()
            {
                new Article()
                {
                    Author = "jon doe",
                    Complexity = 6,
                    CreatedAt = string.Empty,
                    DateOfPublification = "2/16/2018",
                    Id = Guid.NewGuid(),
                },
                new Article()
                {
                    Author = "jane smith",
                    Complexity = 1,
                    CreatedAt = string.Empty,
                    DateOfPublification = "2/15/2018",
                    Id = Guid.NewGuid(),
                }
            };
        }
    }
 }
