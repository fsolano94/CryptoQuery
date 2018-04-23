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

        public Result<IEnumerable<User>> Create(IEnumerable<User> items)
        {
            throw new NotImplementedException();
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
            return _cryptoDbContext.Users.FirstOrDefault(user => string.Compare(user.UserName, userName, StringComparison.InvariantCultureIgnoreCase)==0);
        }

        public Result UpdateUserSettings(Guid userId, ArticleQueryProfile newUserSettings)
        {
            var foo = _cryptoDbContext.Users.Include(x => x.ArticleQueryProfile).ToList();

            var u = foo.Find(user => user.Id == userId);
            
            u.ArticleQueryProfile.Complexity = newUserSettings.Complexity;
            u.ArticleQueryProfile.PushEnabled = newUserSettings.PushEnabled;
            u.ArticleQueryProfile.Topics = FormNewUniqueSetOfTopics(u.Id, newUserSettings.Topics.Split(",").ToList());
            u.ArticleQueryProfile.Quality = newUserSettings.Quality;

            _cryptoDbContext.Users.Update(u);

            _cryptoDbContext.SaveChanges();

            return Result.Ok();

        }

        public Result UpdateEmail(Guid userId, string newEmail)
        {
            var user = _cryptoDbContext.Users.FirstOrDefault(existingUser => existingUser.Id == userId);

            user.Email = newEmail;

            _cryptoDbContext.Update(user);

            _cryptoDbContext.SaveChanges();

            return Result.Ok();

        }

        public Result UpdateUserName(Guid userId, string userName)
        {
            var user = _cryptoDbContext.Users.FirstOrDefault(existingUser => existingUser.Id == userId);

            user.UserName = userName;

            _cryptoDbContext.Update(user);

            _cryptoDbContext.SaveChanges();

            return Result.Ok();
        }

        public Result<User> Update(Guid userId, User item)
        {
            var usersWithArticleQueryProfiles =
                _cryptoDbContext.Users.Include(existingUser => existingUser.ArticleQueryProfile).ToList();

            var userToUpdate = usersWithArticleQueryProfiles.Find(user => user.Id == userId);

            // do updates
            userToUpdate.Email = item.Email;
            userToUpdate.HashedPassword = item.HashedPassword;
            userToUpdate.UserName = item.UserName;
            userToUpdate.ArticleQueryProfile.PushEnabled = item.ArticleQueryProfile.PushEnabled;
            userToUpdate.ArticleQueryProfile.Complexity = item.ArticleQueryProfile.Complexity;
            userToUpdate.ArticleQueryProfile.Quality = item.ArticleQueryProfile.Quality;
            userToUpdate.ArticleQueryProfile.Topics = FormNewUniqueSetOfTopics(userToUpdate.Id, item.ArticleQueryProfile.Topics.Split(",").ToList());

            _cryptoDbContext.Users.Update(userToUpdate);

            _cryptoDbContext.Update(userToUpdate.ArticleQueryProfile);


            _cryptoDbContext.SaveChanges();

            return Result.Ok(_cryptoDbContext.Users.FirstOrDefault(user => user.Id == userId));
        }

        public Result UpdatePassword(Guid userId, string password)
        {
            var user = _cryptoDbContext.Users.FirstOrDefault(existingUser => existingUser.Id == userId);

            user.HashedPassword = password;

            _cryptoDbContext.Users.Update(user);

            _cryptoDbContext.SaveChanges();
            
            return Result.Ok();
        }

        private string FormNewUniqueSetOfTopics(Guid userId,List<string> newTopics)
        {
            var user = _cryptoDbContext.Users.First(existingUser => existingUser.Id == userId);
            var currentTopics = user.ArticleQueryProfile.Topics.Split(",");
            HashSet<string> allOfUsersTopics = new HashSet<string>(currentTopics, StringComparer.InvariantCultureIgnoreCase);

            for (int i = 0; i < newTopics.Count; ++i)
            {
                if (!allOfUsersTopics.Contains(newTopics[i], StringComparer.InvariantCultureIgnoreCase))
                {
                    allOfUsersTopics.Add(newTopics[i]);
                }
            }

            var allOfUsersTopicsAsList = allOfUsersTopics.ToList();
            var allOfUsersTopicsAsString = string.Join(",", allOfUsersTopicsAsList);
            return allOfUsersTopicsAsString;
        }

        public Result UpdateTopics(Guid userId, List<string> newTopics)
        {
            var user = _cryptoDbContext.Users.FirstOrDefault(existingUser => existingUser.Id == userId);

            if (user == null)
            {
                return Result.Fail($"Could not find user with id {userId}.");
            }

            user.ArticleQueryProfile.Topics = FormNewUniqueSetOfTopics(userId, newTopics);

            _cryptoDbContext.Users.Update(user);

            _cryptoDbContext.SaveChanges();

            return Result.Ok();
        }

        public Result<IEnumerable<User>> Get()
        {
            IEnumerable<User> users = null;

            users = _cryptoDbContext.Users.Include(x => x.ArticleQueryProfile).AsEnumerable();

            return Result.Ok(users);
        }

        public Result<User> Get(Guid userId)
        {
            var usersWithArticleQueryProfiles = _cryptoDbContext.Users.Include(existingUser => existingUser.ArticleQueryProfile).ToList();

            var targetUser = usersWithArticleQueryProfiles.Find(user => user.Id == userId);

            return (targetUser == null) ? Result.Fail<User>($"User with {userId.ToString()} not found.") : Result.Ok(targetUser);
        }

        public Result<User> Update(User userWithInformationToUpdate)
        {
            var userToUpdate =
                _cryptoDbContext.Users.FirstOrDefault(existingUser =>
                    existingUser.Id == userWithInformationToUpdate.Id);

            if (userToUpdate == null)
            {
                return Result.Fail<User>($"User with {userToUpdate.Id.ToString()} not found.");
            }

            _cryptoDbContext.Update(userToUpdate);

            _cryptoDbContext.SaveChanges();

            return Result.Ok(userToUpdate);
        }
    }
}
