using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace CryptoQuery.Domain.Articles
{
    public interface IArticleRepository
    {
        Result<IEnumerable<Article>> GetArticles();

        Result<Article> GetById(Guid article);

        Result<Article> DeleteById(Guid article);

        Result<Article> CreateArticle(Article article);
    }
}