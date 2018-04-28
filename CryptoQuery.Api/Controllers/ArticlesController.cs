using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using AutoMapper;
using CryptoQuery.Domain.Articles;
using CryptoQuery.Api.Dto;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoQuery.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("/api/[controller]")]
   // [ApiVersion("1.0")]
    public class ArticlesController : Controller
    {
        ArticleService _articleService;
        IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleService"></param>
        /// <param name="mapper"></param>
        public ArticlesController(ArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }

        [HttpPost(nameof(GetArticlesByTopics))]
        [Authorize(Roles = "Administrator")]
        public IActionResult GetArticlesByTopics([FromBody] TopicsDto topicsDto)
        {
           var articlesOrError = _articleService.GetArticlesByTopics(topicsDto.Topics, topicsDto.offset, topicsDto.limit);

            if (articlesOrError.IsFailure)
            {
                return Ok(new List<string>());
            }

            var articles = articlesOrError.Value.Select(article => new GetArticlePartiallyDto()
            {
                Author = article.Author,
                Id = article.Id,
                Link = article.Link,
                Topics = article.Topics.Split(',').Select(topic => topic.Trim()).ToList(),
                Complexity = article.Complexity,
                Quality = article.Quality,
                PublishedAt = article.PublishedAt.ToString(),
                Description = article.Description,
                ImageUrl = article.ImageUrl,
                Title = article.Title
            });


            return Ok(articles);
        }

        //// GET api/values/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator, StandardUser")]
        public IActionResult Get(Guid id)
        {
            var result = _articleService.Get(id);

            if (result.IsFailure)
            {
                return BadRequest(result);
            }


            return Ok(_mapper.Map<ArticleGetDto>(result.Value));
        }

        [HttpPost(Name =nameof(PostRange))]
        [Authorize(Roles = "Administrator")]
        public IActionResult PostRange([FromBody]ArticlePostDtoCollection articlePostDtoCollection)
        {
            var articles = _mapper.Map<IEnumerable<Article>>(articlePostDtoCollection.Articles);

            return Ok(_articleService.Create(articles));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(Guid id)
        {
            _articleService.Delete(id);

            return Ok(Result.Ok());
        }
    }
}
