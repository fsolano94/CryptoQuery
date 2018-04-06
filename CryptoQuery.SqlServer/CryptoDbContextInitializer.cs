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
        private static Guid philGuid;
        private static Guid franciscoGuid;
        private static Guid maxGuid;
        private static Guid standardUserGuid;

        public static void Initialize(CryptoDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.FirstOrDefault(user => user.Role == "Administrator") == null)
            {
                var phil = new User()
                {
                    Role = "Administrator",
                    UserName = "phil",
                    ArticleQueryProfile = new ArticleQueryProfile()
                    {
                        PushEnabled = true,
                        Id = Guid.NewGuid(),
                        Complexity = 10,
                        Quality = 10,
                        Topics = "BitCoin, Etherium, Litecoin"
                    },
                    CreatedAt = DateTime.Now.ToString(),
                    Email = "",
                    HashedPassword = "abc123",
                };

                var francisco = new User()
                {
                    Role = "Administrator",
                    UserName = "max",
                    ArticleQueryProfile = new ArticleQueryProfile()
                    {
                        PushEnabled = true,
                        Id = Guid.NewGuid(),
                        Complexity = 10,
                        Quality = 10,
                        Topics = "Bytecoin, blockchain, bitcoin"
                    },
                    CreatedAt = DateTime.Now.ToString(),
                    Email = "",
                    HashedPassword = "abc123",
                };

                var max = new User()
                {
                    Role = "Administrator",
                    UserName = "francisco",
                    ArticleQueryProfile = new ArticleQueryProfile()
                    {
                        PushEnabled = true,
                        Id = Guid.NewGuid(),
                        Complexity = 10,
                        Quality = 10,
                        Topics = "Etherium, BitCoin"
                    },
                    CreatedAt = DateTime.Now.ToString(),
                    Email = "initial email. Ensure to change.",
                    HashedPassword = "abc123",
                };

                context.Users.Add(phil);
                context.Users.Add(max);
                context.Users.Add(francisco);

                context.SaveChanges();
            }
        }
    }
}
