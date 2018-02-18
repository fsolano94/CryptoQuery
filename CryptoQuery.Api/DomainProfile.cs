using AutoMapper;
using CryptoQuery.Domain.Articles;
using CryptoQueryWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoQuery.Api
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<ArticleDto, Article>();
            CreateMap<Article, ArticleDto>();
        }
    }
}
