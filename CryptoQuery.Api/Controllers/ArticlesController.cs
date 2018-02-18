using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CryptoQueryWebAPI.Models;
using System.Net;
using AutoMapper;
using CryptoQuery.Domain.Articles;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoQueryWebAPI.Controllers
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
            var articleDtos =_mapper.Map<IEnumerable<ArticleDto>>(articles);

            return Ok(articleDtos);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]ArticleDto newArticle)
        {
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]ArticleDto article)
        {
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok();  
        }
    }
}
