using CryptoQuery.Domain.Articles;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace CryptoQuery.DummyData
{
    public class DummyArticleRepository : IArticleRepository
    {
        public Result<Article> CreateArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public Result<Article> DeleteById(Guid article)
        {
            throw new NotImplementedException();
        }

        public Result<IEnumerable<Article>> GetArticles()
        {
            var articles = new List<Article>()
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

            return Result.Ok < IEnumerable < Article >> (articles);
        }

        public Result<Article> GetById(Guid article)
        {
            throw new NotImplementedException();
        }
    }
 }
