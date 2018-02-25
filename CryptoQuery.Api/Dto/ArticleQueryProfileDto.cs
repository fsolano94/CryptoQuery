using System.Collections.Generic;

namespace CryptoQuery.Api.Dto
{
    public class ArticleQueryProfileDto
    {
        public List<string> Topics;
        public int Complexity { get; set; }
        public int Quality { get; set; }
        public int PushToken { get; set; }
        public bool PushEnabled { get; set; }
    }
}