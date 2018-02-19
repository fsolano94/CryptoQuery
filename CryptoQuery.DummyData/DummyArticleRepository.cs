using CryptoQuery.Domain.Articles;
using System;
using System.Collections.Generic;

namespace CryptoQuery.DummyData
{
    public class DummyArticleRepository : IArticleRepository
    {
        public Article CreateArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public Article DeleteById(Guid article)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetArticles()
        {
            return new List<Article>()
            {
                new Article()
                {
                    Author = "jon doe",
                    Complexity = 6,
                    CreatedAt = DateTime.Now,
                    DateOfPublification = DateTime.Now,
                    Id = Guid.NewGuid(),
                },
                new Article()
                {
                    Author = "jane smith",
                    Complexity = 1,
                    CreatedAt = DateTime.Now,
                    DateOfPublification = DateTime.Now,
                    Id = Guid.NewGuid(),
                }
            };
        }

        public Article GetById(Guid article)
        {
            throw new NotImplementedException();
        }
    }
 }
