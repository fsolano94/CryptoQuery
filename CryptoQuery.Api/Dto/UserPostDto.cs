using CryptoQuery.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoQuery.Api.Dto
{
    public class UserPostDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string> Topics { get; set; }
        public int Complexity { get; set; }
        public int Quality { get; set; }
    }
}
