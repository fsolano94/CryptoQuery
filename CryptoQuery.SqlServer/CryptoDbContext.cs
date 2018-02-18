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

        public CryptoDbContext(string connString)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;");
        }

    }
}
