using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace CryptoQuery.Domain.Articles
{
    public interface IArticleRepository : IRepository<Article>
    {
    }
}