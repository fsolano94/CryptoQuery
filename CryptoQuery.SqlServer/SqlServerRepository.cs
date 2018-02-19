using CryptoQuery.Domain.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using NLog;

namespace CryptoQuery.SqlServer
{
    public class SqlServerArticleRepository : IArticleRepository
    {
        private static ILogger _logger = LogManager.GetCurrentClassLogger();

        private CryptoDbContext _cryptoDbContext = new CryptoDbContext();

        public SqlServerArticleRepository()
        {
        }

        public Article CreateArticle(Article article)
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
            }

            return createdArticle;
        }

        public Article DeleteById(Guid articleId)
        {
            Article articleToRemove = null;

            try
            {
                articleToRemove = GetById(articleId);

                if ( articleToRemove == null )
                {
                    return articleToRemove;
                }

                _cryptoDbContext.Articles.Remove(articleToRemove);

                _cryptoDbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                _logger.Error(exception, exception.Message);
            }

            return articleToRemove;
        }

        public IEnumerable<Article> GetArticles()
        {
            IEnumerable<Article> articles = null;

            try
            {
                articles = _cryptoDbContext.Articles.AsEnumerable();
            }
            catch (Exception exception)
            {
                _logger.Error(exception, exception.Message);
            }

            return articles;
        }

        public Article GetById(Guid articleId)
        {
            Article article = null;

            try
            {
                article = _cryptoDbContext.Articles.FirstOrDefault(existingArticle => existingArticle.Id == articleId);
            }
            catch (Exception exception)
            {
                _logger.Error(exception, exception.Message);
            }
            return article;
        }

       private bool ArticleExists(Article article)
        {
            Article articleExists = null;

            try
            {
                articleExists = _cryptoDbContext.Articles.FirstOrDefault(existingArticle => existingArticle.Id == article.Id);
            }
            catch (Exception exception)
            {
                _logger.Error(exception, exception.Message);
            }
            return articleExists != null;
        }
    }
}
