using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CryptoQuery.Domain.Users
{
    public class User 
    {
        public Guid Id { get; set; }
        public ArticleQueryProfile ArticleQueryProfile { get; set; }
        public string Role { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; } 
    }
}
