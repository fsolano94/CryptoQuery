using CryptoQuery.Domain.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;

namespace CryptoQuery.SqlServer
{
    public class SqlServerArticleRepository : IArticleRepository
    {
        private CryptoDbContext _cryptoDbContext = new CryptoDbContext();

        public SqlServerArticleRepository()
        {
        }

        public Result<Article> Create(Article item)
        {

            Article createdArticle = null;
             var result = _cryptoDbContext.Articles.Add(item);
                createdArticle = result.Entity;
                _cryptoDbContext.SaveChanges();
            return Result.Ok<Article>(createdArticle);
        }

        public Result<IEnumerable<Article>> Create(IEnumerable<Article> items)
        {
            _cryptoDbContext.Articles.AddRange(items);

            _cryptoDbContext.SaveChanges();

            return Result.Ok(items);
        }

        public void Delete(Guid articleId)
        {
            Article articleToRemove = null;

            var result = Get(articleId);

            if (result.Value == null)
            {
                return;
            }

            articleToRemove = result.Value;

            _cryptoDbContext.Articles.Remove(articleToRemove);

            _cryptoDbContext.SaveChanges();

        }

        public Result<IEnumerable<Article>> Get()
        {
            IEnumerable<Article> articles = null;

            articles = _cryptoDbContext.Articles.AsEnumerable();

            return Result.Ok(articles);
        }

        public Result<Article> Get(Guid articleId)
        {
            Article article = null;

            article = _cryptoDbContext.Articles.FirstOrDefault(existingArticle => existingArticle.Id == articleId);

            return (article == null) ? Result.Fail<Article>($"Article with {articleId.ToString()} not found.") : Result.Ok(article);
        }

        public Result<Article> Update(Article article)
        {
            var articleFound = _cryptoDbContext.Articles.FirstOrDefault(existingArticle => existingArticle.Id == article.Id);

            if (articleFound == null)
            {
                return Result.Fail<Article>($"Article with {article.Id.ToString()} not found.");
            }

            _cryptoDbContext.Articles.Update(article);

            _cryptoDbContext.SaveChanges();

            return Result.Ok<Article>(article);
        }
    }
}
