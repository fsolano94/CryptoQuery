using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CryptoQuery.Domain.Users
{
    public class ArticleQueryProfile
    {
        public Guid Id { get; set; }
        [NotMapped]
        public List<string> Topics { get; set; }
        public int Complexity { get; set; }
        public int Quality { get; set; }
        public int PushToken { get; set; }
        public bool PushEnabled { get; set; }
    }
}
