﻿using CryptoQuery.Domain.Articles;
using CryptoQuery.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoQuery.SqlServer
{
    public class CryptoDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<User> Users { get; set; }

        public CryptoDbContext()
        {
        }

        public CryptoDbContext(DbContextOptions<CryptoDbContext> context) : base(context)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=tcp:cryptoqueryapi2018dbserver.database.windows.net,1433;Initial Catalog=CryptoQuery;Persist Security Info=False;User ID=csqdaL25!;Password=!!eL9624Jrm;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            //optionsBuilder.UseSqlServer(@"Server=tcp:cryptoquery.database.windows.net,1433;Initial Catalog=CryptoQuery;Persist Security Info=False;User ID=cqsda;Password=Rfv84720^7Tgb;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            //optionsBuilder.UseSqlServer(
            //   @"Server = localhost\MSSQLSERVER2017;Database = CryptoQuery; Trusted_Connection = True;");
        }
    }
}
