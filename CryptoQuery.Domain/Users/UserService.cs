using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoQuery.Domain.Users
{
    public class UserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Result<User> Create(User user)
        {
            return _userRepository.Create(user);
        }

        public Result<IEnumerable<User>> Get()
        {
            return _userRepository.Get();
        }

        public Result<User> Get(Guid id)
        {
            return _userRepository.Get(id);
        }

        public void Delete(Guid id)
        {
            _userRepository.Delete(id);
        }

        public Result<User> Update(Guid userId, User item)
        {
            return _userRepository.Update(userId, item);
        }

        public Result<User> UpdateUserSettings(Guid userId, ArticleQueryProfile newUserSettings)
        {
            return _userRepository.UpdateUserSettings(userId, newUserSettings);
        }

        public Result<User> UpdateEmail(Guid userId, string newEmail)
        {
            return _userRepository.UpdateEmail(userId,newEmail);
        }

        public Result Update(User value)
        {
            return _userRepository.Update(value);
        }

        public Result Update(Guid userId, string password)
        {
            return _userRepository.UpdatePassword(userId, password);
        }

        public Result<User> UpdateTopics(Guid userId, List<string> topics)
        {
            return _userRepository.UpdateTopics(userId, topics);
        }

        public Result<User> GetUserByEmail(string loginEmail)
        {
            return _userRepository.GetUserByEmail(loginEmail);
        }

        public Result<User> DeleteUserTopics(Guid userId, List<string> topicsToDelete)
        {
            return _userRepository.DeleteUserTopics(userId, topicsToDelete);
        }
    }
}
