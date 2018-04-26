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
    [Route("/[controller]")]
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
                return BadRequest(articlesOrError.Error);
            }

            return Ok(articlesOrError.Value);
        }

        // GET: api/values
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetArticlesBySettings))]
        [Authorize(Roles = "Administrator, StandardUser")]
        public IActionResult GetArticlesBySettings([FromBody] ArticleQueryProfilePostDto settings)
        {
            var articlesOrError = _articleService.Get();

            if (articlesOrError.IsFailure)
            {
                return BadRequest(articlesOrError.Error);
            }

            // automapper
            var articleDtos = _mapper.Map<IEnumerable<ArticleGetDto>>(articlesOrError.Value);

            return Ok(Result.Ok(articleDtos));
        }

        // GET: api/values
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetAllArticles))]
        [Authorize(Roles = "Administrator, StandardUser")]
        public IActionResult GetAllArticles()
        {
            var articlesOrError = _articleService.Get(); 

            if (articlesOrError.IsFailure)
            {
                return BadRequest(articlesOrError);
            }
            
            // automapper
            var articleDtos =_mapper.Map<IEnumerable<GetArticlePartiallyDto>>(articlesOrError.Value);

            return Ok(Result.Ok(articleDtos));
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
