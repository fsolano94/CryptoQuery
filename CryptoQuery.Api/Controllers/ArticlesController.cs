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
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    public class ArticlesController : Controller
    {
        ArticleService _articleService;
        IMapper _mapper;

        public ArticlesController(ArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }

        // GET: api/values
        [HttpGet(Name = nameof(GetAllArticles))]
        public IActionResult GetAllArticles()
        {
            var articlesOrError = _articleService.GetArticles(); // articles is a business object

            if (articlesOrError.IsFailure)
            {
                return BadRequest(articlesOrError);
            }

            // automapper
            var articleDtos =_mapper.Map<IEnumerable<ArticleGetDto>>(articlesOrError.Value);


            return Ok(Result.Ok(articleDtos));
        }

        // GET api/values/5
        [HttpGet("{id}", Name = nameof(GetAritcleWithId))]
        public IActionResult GetAritcleWithId(Guid id)
        {
            if ( id == null )
            {
                return BadRequest(Result.Fail<ArticleGetDto>($"Invalid Guid id specified: {id}."));
            }

            var result = _articleService.GetById(id);

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok( _mapper.Map<ArticleGetDto>(result.Value));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]ArticlePostDto articlePostDto)
        {
            Article createdArticle = null;

            try
            {
                var article = _mapper.Map<Article>(articlePostDto);

                var result = _articleService.CreateArticle(article);

                createdArticle = result.Value;

                if (createdArticle == null)
                {
                    return BadRequest(createdArticle);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return CreatedAtRoute("Get", new { id = createdArticle.Id}, createdArticle);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]ArticlePostDto article)
        {
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if ( id == null  )
            {
                return BadRequest($"Invalid id specified: {id}.");
            }

            var result = _articleService.DeleteById(id);

            Article articleToDelete = result.Value;

            if (articleToDelete == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }

            return Ok(articleToDelete);
        }
    }
}
