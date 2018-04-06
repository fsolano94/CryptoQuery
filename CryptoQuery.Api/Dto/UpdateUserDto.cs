using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoQuery.Api.Dto
{
    public class UpdateUserDto
    {
        public List<string> Topics { get; set; }
        public int Complexity { get; set; }
        public int Quality { get; set; }
        public bool PushEnabled { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}