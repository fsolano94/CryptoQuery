using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoQuery.Domain.Settings
{
    public class ArticleQueryProfile
    {
        public Guid Id { get; set; }
        public List<string> Topics;
        public int Complexity { get; set; }
        public int Quality { get; set; }
        public int PushToken { get; set; }
        public bool PushEnabled { get; set; }
    }
}
