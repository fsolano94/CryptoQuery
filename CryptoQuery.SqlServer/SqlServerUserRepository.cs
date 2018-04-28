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

        public Result<User> UpdateUserSettings(Guid userId, ArticleQueryProfile newUserSettings)
        {
            var foo = _cryptoDbContext.Users.Include(x => x.ArticleQueryProfile).ToList();

            var u = foo.Find(user => user.Id == userId);
            
            u.ArticleQueryProfile.Complexity = newUserSettings.Complexity;
            u.ArticleQueryProfile.Topics = FormNewUniqueSetOfTopics(u.Id, newUserSettings.Topics.Split(',').Select(topic => topic.Trim()).ToList());
            u.ArticleQueryProfile.Quality = newUserSettings.Quality;

            _cryptoDbContext.Users.Update(u);

            _cryptoDbContext.SaveChanges();

            return Result.Ok(u);

        }

        public Result<User> UpdateEmail(Guid userId, string newEmail)
        {
            var user = _cryptoDbContext.Users.FirstOrDefault(existingUser => existingUser.Id == userId);

            user.Email = newEmail;

            _cryptoDbContext.Update(user);

            _cryptoDbContext.SaveChanges();

            return Result.Ok(user);

        }

        public Result UpdateUserName(Guid userId, string userName)
        {
            var user = _cryptoDbContext.Users.FirstOrDefault(existingUser => existingUser.Id == userId);

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
            userToUpdate.PlainTextPassword = item.PlainTextPassword;
            userToUpdate.ArticleQueryProfile.Complexity = item.ArticleQueryProfile.Complexity;
            userToUpdate.ArticleQueryProfile.Quality = item.ArticleQueryProfile.Quality;
            userToUpdate.ArticleQueryProfile.Topics = FormNewUniqueSetOfTopics(userToUpdate.Id, item.ArticleQueryProfile.Topics.Split(',').Select(topic => topic.Trim()).ToList());

            _cryptoDbContext.Users.Update(userToUpdate);

            _cryptoDbContext.Update(userToUpdate.ArticleQueryProfile);


            _cryptoDbContext.SaveChanges();

            return Result.Ok(_cryptoDbContext.Users.FirstOrDefault(user => user.Id == userId));
        }

        public Result UpdatePassword(Guid userId, string password)
        {
            var user = _cryptoDbContext.Users.FirstOrDefault(existingUser => existingUser.Id == userId);

            user.PlainTextPassword = password;

            _cryptoDbContext.Users.Update(user);

            _cryptoDbContext.SaveChanges();
            
            return Result.Ok();
        }

        private string FormNewUniqueSetOfTopics(Guid userId,List<string> newTopics)
        {
            var user = _cryptoDbContext.Users.First(existingUser => existingUser.Id == userId);
            var currentTopics = user.ArticleQueryProfile.Topics.Split(',').Select(topic => topic.Trim()).ToList();
            List<string> updatedListOfTopics = new List<string>();

            for (int newTopicIndex = 0; newTopicIndex < newTopics.Count(); newTopicIndex++)
            {
                var newCurrentTopicExists = currentTopics.Any(existingCurrentTopic =>
                    string.Compare(existingCurrentTopic, newTopics[newTopicIndex],
                        StringComparison.InvariantCultureIgnoreCase) == 0);
                if (!newCurrentTopicExists)
                {
                    updatedListOfTopics.Add(newTopics[newTopicIndex]);
                }
            }

            updatedListOfTopics.AddRange(currentTopics);

            return string.Join(",", updatedListOfTopics);
        }

        public Result<User> UpdateTopics(Guid userId, List<string> newTopics)
        {
            var user = _cryptoDbContext.Users.Include(existingUser => existingUser.ArticleQueryProfile)
                .FirstOrDefault(targetUser => targetUser.Id == userId);

            if (user == null)
            {
                return Result.Fail<User>($"Could not find user with id {userId}.");
            }

            user.ArticleQueryProfile.Topics = FormNewUniqueSetOfTopics(userId, newTopics);

            _cryptoDbContext.Users.Update(user);

            _cryptoDbContext.SaveChanges();

            return Result.Ok(user);
        }

        public Result<User> GetUserByEmail(string loginEmail)
        {
            var user = _cryptoDbContext.Users.Include(userInDatabase => userInDatabase.ArticleQueryProfile).FirstOrDefault(existingUser =>
                string.Compare(existingUser.Email, loginEmail, StringComparison.InvariantCultureIgnoreCase) == 0);

            return user != null ? Result.Ok(user) : Result.Fail<User>($"User with email \"{loginEmail}\" does not exist.");
        }

        public Result<User> DeleteUserTopics(Guid userId, List<string> topicsToDelete)
        {
            var userInDataBase = _cryptoDbContext.Users.Include(user => user.ArticleQueryProfile)
                .FirstOrDefault(existingUser => existingUser.Id == userId);


            topicsToDelete = topicsToDelete.Select(topic => topic.Trim()).ToList();

            var currentTopics = _cryptoDbContext.Users.Include(userWithTopics => userWithTopics.ArticleQueryProfile)
                .FirstOrDefault(existingUser => existingUser.Id == userId).ArticleQueryProfile.Topics.Split(',').Select(topic => topic.Trim()).ToList();

            var updatedTopics = new List<string>();

            for (int currentTopicToDeleteCounter = 0; currentTopicToDeleteCounter < topicsToDelete.Count; currentTopicToDeleteCounter++)
            {
                var currentTopicToDeleteIndex = currentTopics.FindIndex(existingTopic =>
                    string.Compare(existingTopic, topicsToDelete[currentTopicToDeleteCounter],
                        StringComparison.InvariantCultureIgnoreCase) == 0);

                if (currentTopicToDeleteIndex != -1)
                {
                    currentTopics.RemoveAt(currentTopicToDeleteIndex);
                }

            }

            userInDataBase.ArticleQueryProfile.Topics = string.Join(",", currentTopics);

            _cryptoDbContext.Update(userInDataBase);

            _cryptoDbContext.SaveChanges();

            return Result.Ok(userInDataBase);
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
