﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoQuery.Api.Dto
{
    public class ArticleQueryProfileUpdateDto
    {
        public List<string> Topics { get; set; }
        public int Complexity { get; set; }
        public int Quality { get; set; }
        public bool PushEnabled { get; set; }
    }
}
