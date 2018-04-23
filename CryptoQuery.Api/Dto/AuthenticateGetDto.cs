using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoQuery.Api.Models;

namespace CryptoQuery.Api.Dto
{
    public class AuthenticateGetDto
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
