using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoQuery.Domain.Articles
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetArticles();
    }
}
