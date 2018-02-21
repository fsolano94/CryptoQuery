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

        public Result<Article> CreateArticle(Article article)
        {
            return _articleRepository.CreateArticle(article);
        }

        public Result<IEnumerable<Article>> GetArticles()
        {
            return _articleRepository.GetArticles();
        }

        public Result<Article> GetById(Guid id)
        {
            return _articleRepository.GetById(id);
        }

        public Result<Article> DeleteById(Guid id)
        {
            return _articleRepository.DeleteById(id);
        }
    }
}
