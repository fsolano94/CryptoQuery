using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using AutoMapper;
using CryptoQuery.Domain.Articles;
using CryptoQuery.Api.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoQuery.Api.Controllers
{
    [Route("api/[controller]")]
    public class ArticlesController : Controller
    {
        IArticleRepository _articleRepository;
        IMapper _mapper;

        public ArticlesController(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var articles = _articleRepository.GetArticles(); // articles is a business object

            // automapper
            var articleDtos =_mapper.Map<IEnumerable<ArticleGetDto>>(articles);

            return Ok(articleDtos);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            if ( id == null )
            {
                return BadRequest($"Invalid Guid id specified: {id}.");
            }

            var article = _articleRepository.GetById(id);

            if ( article == null )
            {
                return NotFound();
            }

            return Ok( _mapper.Map<ArticleGetDto>(article));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]ArticlePostDto articlePostDto)
        {
            Article createdArticle = null;

            try
            {
                var article = _mapper.Map<Article>(articlePostDto);

                createdArticle = _articleRepository.CreateArticle(article);

                if (createdArticle == null)
                {
                    return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                }

            }
            catch (Exception exception)
            {
                throw exception;
            }

            return Ok(createdArticle);
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

           Article articleToDelete = _articleRepository.DeleteById(id);

            if (articleToDelete == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }

            return Ok(articleToDelete);
        }
    }
}
