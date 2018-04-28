using System;
using System.Collections.Generic;
using System.Text;
using CSharpFunctionalExtensions;
namespace CryptoQuery.Domain.Users
{
    public interface IUserRepository : IRepository<User>
    {
        Result<User> UpdateUserSettings(Guid userId, ArticleQueryProfile newUserSettings);
        Result<User> UpdateEmail(Guid userId, string newEmail);
        Result<User> Update(Guid userId, User item);
        Result UpdatePassword(Guid userId, string password);
        Result<User> UpdateTopics(Guid userId, List<string> topics);
        Result<User> GetUserByEmail(string loginEmail);
        Result<User> DeleteUserTopics(Guid userId, List<string> topicsToDelete);
    }
}
