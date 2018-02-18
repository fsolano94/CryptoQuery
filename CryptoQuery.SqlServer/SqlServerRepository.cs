using CryptoQuery.Domain.Articles;
using System;
using System.Collections.Generic;

namespace CryptoQuery.SqlServer
{
    public class SqlServerArticleRepository : IArticleRepository
    {
        private CryptoDbContext cryptoDbContext = new CryptoDbContext(@"Server=(localdb)\DESKTOP-0EIN6C4;Database=CryptoQuery;Trusted_Connection=True;");

        public SqlServerArticleRepository()
        {

        }

        public IEnumerable<Article> GetArticles()
        {
            return cryptoDbContext.Articles;
        }
    }
}
