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

        // GET: api/values
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var articlesOrError = _articleService.Get(); 

            if (articlesOrError.IsFailure)
            {
                return BadRequest(articlesOrError);
            }

            // automapper
            var articleDtos =_mapper.Map<IEnumerable<ArticleGetDto>>(articlesOrError.Value);

            return Ok(Result.Ok(articleDtos));
        }

        //// GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            if (id == null)
            {
                return BadRequest(Result.Fail<ArticleGetDto>($"Invalid Guid id specified: {id}."));
            }

            var result = _articleService.Get(id);

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(_mapper.Map<ArticleGetDto>(result.Value));
        }

        //// POST api/values
        //[HttpPost]
        //public IActionResult Post([FromBody]ArticlePostDto articlePostDto)
        //{
        //    Article createdArticle = null;

        //    var article = _mapper.Map<Article>(articlePostDto);

        //    var result = _articleService.Create(article);

        //    createdArticle = result.Value;

        //    if (createdArticle == null)
        //    {
        //        return BadRequest(createdArticle);
        //    }

        //    return CreatedAtRoute("Get", new { id = createdArticle.Id }, createdArticle);
        //}

        [HttpPost]
        public IActionResult PostRange([FromBody]IEnumerable<ArticlePostDto> articlePostDtoCollection)
        {
            var articles = _mapper.Map<IEnumerable<Article>>(articlePostDtoCollection);

            return Ok(_articleService.Create(articles));
        }


        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public IActionResult Put(string id, [FromBody]ArticlePostDto article)
        //{
        //    return Ok();
        //}

        //// DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return BadRequest($"Invalid id specified: {id}.");
            }

            _articleService.Delete(id);

            return Ok(Result.Ok());
        }
    }
}
