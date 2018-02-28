using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoQuery.Api.Dto
{
    public class ArticleQueryProfilePostDto
    {
        [NotMapped]
        public List<string> Topics { get; set; }
        public int Complexity { get; set; }
        public int Quality { get; set; }
        public int PushToken { get; set; }
        public bool PushEnabled { get; set; }
    }
}