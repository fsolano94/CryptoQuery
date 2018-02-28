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
    }
}
