using CryptoQuery.Domain.Users;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptoQuery.SqlServer
{
    public class SqlServerUserRepository : IUserRepository
    {
        private CryptoDbContext _cryptoDbContext = new CryptoDbContext();

        public SqlServerUserRepository()
        {
        }

        public Result<User> Create(User user)
        {
            User createdUser = null;
            var result = _cryptoDbContext.Users.Add(user);
            createdUser = result.Entity;
            _cryptoDbContext.SaveChanges();
            return Result.Ok<User>(createdUser);
        }

        public Result<IEnumerable<User>> Create(IEnumerable<User> users)
        {
            _cryptoDbContext.Users.AddRange(users);

            _cryptoDbContext.SaveChanges();

            return Result.Ok(users);
        }

        public void Delete(Guid userId)
        {
            User userToRemove = null;

            var result = Get(userId);

            if (result.Value == null)
            {
                return;
            }

            userToRemove = result.Value;

            _cryptoDbContext.Users.Remove(userToRemove);

            _cryptoDbContext.SaveChanges();

        }

        public User GetUserByUserName(string userName)
        {
            return _cryptoDbContext.Users.FirstOrDefault(user => user.UserName == userName);
        }

        public Result<IEnumerable<User>> Get()
        {
            IEnumerable<User> users = null;

            users = _cryptoDbContext.Users.Include(x => x.ArticleQueryProfile).AsEnumerable();

            return Result.Ok(users);
        }

        public Result<User> Get(Guid userId)
        {
            User user = null;

            user = _cryptoDbContext.Users.FirstOrDefault(existingArticle => existingArticle.Id == userId);

            return (user == null) ? Result.Fail<User>($"User with {userId.ToString()} not found.") : Result.Ok(user);
        }

        public Result<User> Update(User user)
        {
            var userFound = _cryptoDbContext.Users.FirstOrDefault(existingArticle => existingArticle.Id == user.Id);

            if (userFound == null)
            {
                return Result.Fail<User>($"User with {user.Id.ToString()} not found.");
            }

            _cryptoDbContext.Users.Update(user);

            _cryptoDbContext.SaveChanges();

            return Result.Ok<User>(user);
        }
    }
}
