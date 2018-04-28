using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CryptoQuery.Domain.Users
{
    public class ArticleQueryProfile
    {
        public Guid Id { get; set; }
        public string Topics { get; set; }
        public int Complexity { get; set; }
        public int Quality { get; set; }
    }
}
