using CryptoQuery.Domain.Articles;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace CryptoQuery.DummyData
{
    public class DummyArticleRepository : IArticleRepository
    {
        public Result<Article> Create(Article item)
        {
            throw new NotImplementedException();
        }

        public Result<IEnumerable<Article>> Create(IEnumerable<Article> items)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Result<IEnumerable<Article>> Get()
        {
            throw new NotImplementedException();
        }

        public Result<Article> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Result<Article> Update(Article item)
        {
            throw new NotImplementedException();
        }
    }
}
