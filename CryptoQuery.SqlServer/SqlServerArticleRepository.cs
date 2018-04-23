using CryptoQuery.Domain.Articles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CryptoQuery.Domain.Users;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

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

            List < Article > newArticles = items.ToList();


            newArticles.ForEach(article =>
            {
                article.CreatedAt = DateTime.Now;
                article.UpdatedAt = DateTime.Now;
            });

            _cryptoDbContext.Articles.AddRange(newArticles);

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

        public Result<List<Article>> GetArticlesByTopics(List<string> desiredTopics)
        {


            if ( !_cryptoDbContext.Articles.Any() )
            {
                return Result.Fail<List<Article>>("No articles present");
            }

            var allArticlesInDatabase = _cryptoDbContext.Articles.Select(element => element).ToList();

            List<Article> articlesWithDesiredTopics = new List<Article>();

            for (int currentArticleIndex = 0; currentArticleIndex < desiredTopics.Count; ++currentArticleIndex)
            {
                var topicsForCurrentArticle = allArticlesInDatabase[currentArticleIndex].Topics.Split(",");

                var currentDesiredTopicFoundInCurrentArticle = topicsForCurrentArticle.Any(topic =>
                    string.Compare(topic, desiredTopics[currentArticleIndex], StringComparison.InvariantCultureIgnoreCase) == 0);
                
                if ( currentDesiredTopicFoundInCurrentArticle )
                {
                    articlesWithDesiredTopics.Add(allArticlesInDatabase[currentArticleIndex]);
                }
            }

            return Result.Ok( allArticlesInDatabase );

        }

        public Result<IEnumerable<Article>> Get()
        {
            IEnumerable<Article> articles = null;

            articles = _cryptoDbContext.Articles.AsEnumerable();

            return Result.Ok(articles);
        }

        public Result<IEnumerable<Article>> GetArticlesBySettings(ArticleQueryProfile articleQueryProfile)
        {
            IEnumerable<Article> articles = null;

            //articles = _cryptoDbContext.Articles.AsEnumerable();


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
