using System;
using System.Collections.Generic;
using System.Text;
using CSharpFunctionalExtensions;
namespace CryptoQuery.Domain.Users
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByUserName(string userName);

        Result UpdateUserSettings(Guid userId, ArticleQueryProfile newUserSettings);
        Result UpdateEmail(Guid userId, string newEmail);
        Result UpdateUserName(Guid userId, string userName);
        Result<User> Update(Guid userId, User item);
        Result UpdatePassword(Guid userId, string password);
        Result UpdateTopics(Guid userId, List<string> topics);
    }
}
