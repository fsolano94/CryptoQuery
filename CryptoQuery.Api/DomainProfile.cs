using AutoMapper;
using CryptoQuery.Api.Dto;
using CryptoQuery.Domain.Articles;
using CryptoQuery.Domain.Users;
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

            CreateMap<Guid, string>().ConvertUsing(source =>
                {
                    return source.ToString();
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

            CreateMap<UserGetDto, User>().ReverseMap();

            CreateMap<UserPostDto, User>().ReverseMap();

            CreateMap<ArticleQueryProfileGetDto, ArticleQueryProfile>().ReverseMap();

            CreateMap<ArticleQueryProfilePostDto, ArticleQueryProfile>().ReverseMap();
        }
    }
}
