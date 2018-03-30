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

            if (context.Users.FirstOrDefault(n => n.UserName == "phil") == null)
            {
                context.Users.Add(new User()
                {
                    Role = "Administrator",
                    UserName = "phil",
                    ArticleQueryProfile = null,
                    CreatedAt = DateTime.Now.ToString(),
                    Email = "",
                    HashedPassword = "abc123",
                });

                context.SaveChanges();
            }

            if (context.Users.FirstOrDefault(n => n.UserName == "max") == null)
            {
                context.Users.Add(new User()
                {
                    Role = "Administrator",
                    UserName = "max",
                    ArticleQueryProfile = null,
                    CreatedAt = DateTime.Now.ToString(),
                    Email = "",
                    HashedPassword = "abc123",
                });

                context.SaveChanges();
            }

            if (context.Users.FirstOrDefault(n => n.UserName == "francisco") == null)
            {
                context.Users.Add(new User()
                {
                    Role = "Administrator",
                    UserName = "francisco",
                    ArticleQueryProfile = null,
                    CreatedAt = DateTime.Now.ToString(),
                    Email = "",
                    HashedPassword = "abc123",
                });

                context.SaveChanges();
            }

            if (context.Users.FirstOrDefault(n => n.UserName == "standardUser") == null)
            {
                context.Users.Add(new User()
                {
                    Role = "StandardUser",
                    UserName = "standardUser",
                    ArticleQueryProfile = null,
                    CreatedAt = DateTime.Now.ToString(),
                    Email = "",
                    HashedPassword = "abc123",
                });

                context.SaveChanges();
            }

        }
    }
}
