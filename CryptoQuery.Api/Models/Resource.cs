using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CryptoQuery.Api.Models
{
    // every resource in the api will contain a referential link to itself
    public abstract class Resource
    {
        [JsonProperty(Order = -2)]
        // -2 means property will be at top of all serialized responses
        public string Href { get; set; }
    }
}
