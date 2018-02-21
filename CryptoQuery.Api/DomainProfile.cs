using AutoMapper;
using CryptoQuery.Api.Dto;
using CryptoQuery.Domain.Articles;
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
            CreateMap<string, Guid>().ConvertUsing(source =>
                {
                    Guid newGuid;
                    Guid.TryParse(source, out newGuid);
                    return newGuid;
                }
            );

            CreateMap<string, DateTime>().ConvertUsing(source =>

                    {
                        DateTime dateTime;
                        DateTime.TryParse(source, out dateTime);
                        return dateTime;
                    }
                );

            CreateMap<DateTime, string>().ConvertUsing(
                    source =>
                    source.ToLongDateString()
                );

            CreateMap<ArticleGetDto, Article>().ReverseMap();

            CreateMap<ArticlePostDto, Article>().ReverseMap();
        }
    }
}
