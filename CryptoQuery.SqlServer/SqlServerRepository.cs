using CryptoQuery.Domain.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using CSharpFunctionalExtensions;

namespace CryptoQuery.SqlServer
{
    public class SqlServerArticleRepository : IArticleRepository
    {
        private static ILogger _logger = LogManager.GetCurrentClassLogger();

        private CryptoDbContext _cryptoDbContext = new CryptoDbContext();

        public SqlServerArticleRepository()
        {
        }

        public Result<Article> CreateArticle(Article article)
        {
            Article createdArticle = null;

            try
            {
                var result =_cryptoDbContext.Articles.Add(article);
                createdArticle = result.Entity;
                _cryptoDbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                _logger.Error(exception, exception.Message);
                return Result.Fail<Article>(exception.Message);
            }

            return Result.Ok<Article>(createdArticle);
        }

        public Result<Article> DeleteById(Guid articleId)
        {
            Article articleToRemove = null;

            try
            {
                var result = GetById(articleId);

                if ( result.Value == null )
                {
                    return Result.Fail<Article>($"Element with provided id of {articleId} could not be found.");
                }

                articleToRemove = result.Value;

                _cryptoDbContext.Articles.Remove(articleToRemove);

                _cryptoDbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                _logger.Error(exception, exception.Message);
                return Result.Fail<Article>(exception.Message);
            }

            return Result.Ok(articleToRemove);
        }

        public Result<IEnumerable<Article>> GetArticles()
        {
            IEnumerable<Article> articles = null;

            try
            {
                articles = _cryptoDbContext.Articles.AsEnumerable();
            }
            catch (Exception exception)
            {
                _logger.Error(exception, exception.Message);
                return Result.Fail<IEnumerable<Article>>(exception.Message);
            }

            return Result.Ok(articles);
        }

        public Result<Article> GetById(Guid articleId)
        {
            Article article = null;

            article = _cryptoDbContext.Articles.FirstOrDefault(existingArticle => existingArticle.Id == articleId);
            
            return (article == null) ?  Result.Fail<Article>($"Article with {articleId.ToString()} not found."): Result.Ok(article);
        }
    }
}
