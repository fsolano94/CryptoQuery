using CryptoQuery.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoQuery.Api.Dto
{
    public class UserGetDto
    {
        public Guid UserId { get; set; }
        public List<string> Topics { get; set; }
        public string Email { get; set; }
    }
}
