using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoQuery.Api.Dto
{
    public class ArticleQueryProfilePostDto
    {
        [NotMapped]
        public List<string> Topics { get; set; }
    }
}