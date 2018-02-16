using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoQueryWebAPI.Models
{
    public class SettingsDto
    {
        public string Id { get; set; }
        public int UserId { get; set; }

        public List<string> Topics;
        public int Complexity { get; set; }
        public int Quality { get; set; }
        public int PushToken { get; set; }
        public bool PushEnabled { get; set; }
    }
}
