using System;
using System.Collections.Generic;

namespace CryptoQuery.Domain.Articles
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetArticles();

        Article GetById(Guid article);

        Article DeleteById(Guid article);

        Article CreateArticle(Article article);
    }
}
