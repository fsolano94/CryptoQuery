using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CryptoQueryWebAPI.ModelsWithHardCodedData;
using CryptoQueryWebAPI.Models;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoQueryWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ArticlesController : Controller
    {
        private Articles _articles = new Articles();

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            if ( _articles.ArticlesList != null )
            {
                return Ok(_articles.ArticlesList);
            }
            return NotFound("There are currently no articles.");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var article = _articles.ArticlesList.FirstOrDefault(articleInList => articleInList.Id == id);

            if ( article != null )
            {
                return Ok(article);
            }

            return NotFound($"Article with id {id} was not found.");
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]ArticleDto newArticle)
        {
            var articleExists = _articles.ArticlesList.Exists(articleInList => articleInList.Equals(newArticle));

            if (!articleExists)
            {
                _articles.ArticlesList.Add(newArticle);
                return Ok(newArticle);
            }

            return new StatusCodeResult((int)HttpStatusCode.Conflict);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]ArticleDto article)
        {
            var articleIndex = _articles.ArticlesList.FindIndex(articleInList => articleInList.Equals(article));

            if (articleIndex != -1)
            {
                _articles.ArticlesList[articleIndex] = article;
                return Ok(article);
            }

            return NotFound($"Could not find an article with the provided id {id}.");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var article = _articles.ArticlesList.First(articleInList => articleInList.Id == id);

            if (article != null)
            {
                _articles.ArticlesList.Remove(article);
                return Ok(article);
            }

            return NotFound($"Could not find an article with id {id}.");
        }
    }
}
