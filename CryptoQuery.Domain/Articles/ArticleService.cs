using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoQuery.Domain.Articles
{
    // Business logic
    public class ArticleService
    {
        private IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public Result<Article> Create(Article article)
        {
            return _articleRepository.Create(article);
        }

        public Result<IEnumerable<Article>> Create(IEnumerable<Article> articles)
        {
            return _articleRepository.Create(articles);
        }

        public Result<IEnumerable<Article>> Get()
        {
            return _articleRepository.Get();
        }

        public Result<Article> Get(Guid id)
        {
            return _articleRepository.Get(id);
        }

        public void Delete(Guid id)
        {
            _articleRepository.Delete(id);
        }

        public Result<List<Article>> GetArticlesByTopics(List<string> topics, int numberOfArticlesToSkip, int maximumNumberOfArticlesToRetreive)
        {
            return _articleRepository.GetArticlesByTopics(topics, numberOfArticlesToSkip, maximumNumberOfArticlesToRetreive);
        }
    }
}
