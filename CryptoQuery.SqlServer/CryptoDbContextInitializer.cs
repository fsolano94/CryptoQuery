using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CryptoQuery.Domain;
using CryptoQuery.Domain.Users;

namespace CryptoQuery.SqlServer
{
    public static class CryptoDbContextInitializer
    {

        public static void Initialize(CryptoDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.FirstOrDefault(user => user.Role == "Administrator") == null)
            {
                var phil = new User()
                {
                    Role = "Administrator",
                    ArticleQueryProfile = new ArticleQueryProfile()
                    {
                        Id = Guid.NewGuid(),
                        Complexity = 10,
                        Quality = 10,
                        Topics = "BitCoin, Etherium, Litecoin"
                    },
                    CreatedAt = DateTime.Now.ToString(),
                    UpdatedAt = "no update",
                    Email = "phil@gmail.com",
                    PlainTextPassword = "abc123",
                };

                var francisco = new User()
                {
                    Role = "Administrator",
                    ArticleQueryProfile = new ArticleQueryProfile()
                    {
                        Id = Guid.NewGuid(),
                        Complexity = 10,
                        Quality = 10,
                        Topics = "Bytecoin, blockchain, bitcoin"
                    },
                    CreatedAt = DateTime.Now.ToString(),
                    UpdatedAt = "no update",
                    Email = "francisco@gmail.com",
                    PlainTextPassword = "abc123",
                };

                var max = new User()
                {
                    Role = "Administrator",
                    ArticleQueryProfile = new ArticleQueryProfile()
                    {
                        Id = Guid.NewGuid(),
                        Complexity = 10,
                        Quality = 10,
                        Topics = "Etherium, BitCoin"
                    },
                    CreatedAt = DateTime.Now.ToString(),
                    UpdatedAt = "no update",
                    Email = "max@gmail.com",
                    PlainTextPassword = "abc123",
                };

                context.Users.Add(phil);
                context.Users.Add(max);
                context.Users.Add(francisco);

                context.SaveChanges();
            }
        }
    }
}
