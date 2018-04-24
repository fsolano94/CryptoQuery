using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoQuery.Api.Dto
{
    public class TopicsDto
    {
        public List<string> Topics { get; set; }
        public int MaximumNumberOfTopicsToRetrieve { get; set; }
        public int NumberOfArticlesToSkipInTheDatabase { get; set; }
    }
}
