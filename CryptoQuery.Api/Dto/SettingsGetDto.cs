using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoQuery.Api.Dto
{
    public class SettingsGetDto
    {
        public string UserId { get; set; }

        public List<string> Topics;
        public int Complexity { get; set; }
        public int Quality { get; set; }
        public int PushToken { get; set; }
        public bool PushEnabled { get; set; }
    }
}
