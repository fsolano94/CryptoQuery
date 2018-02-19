using CryptoQuery.Domain.Articles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoQuery.SqlServer
{
    public class CryptoDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=localhost;Database=CryptoQuery;Trusted_Connection=True;");
           optionsBuilder.UseSqlServer(@"Server=tcp:cryptoquery.database.windows.net,1433;Initial Catalog=CryptoQuery;Persist Security Info=False;User ID=cqsda;Password=Rfv84720^7Tgb;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
