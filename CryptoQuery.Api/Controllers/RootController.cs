using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoQuery.Api.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("/")]
    public class RootController : Controller
    {
        // GET: api/Root
        [HttpGet(Name = nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var response = new
            {
                location = Url.Link(nameof(GetRoot), null),
                
                articles = new
                {
                    location = Url.Link(nameof(ArticlesController.GetAllArticles), null)
                }
            };

            return Ok(response);
        }

        //// GET: api/Root/5
        //[HttpGet("{id}", Name = nameof(Get))]
        //public IActionResult Get(int id)
        //{
        //    throw new NotImplementedException();
        //}
        
        //// POST: api/Root
        //[HttpPost]
        //public IActionResult Post([FromBody]string value)
        //{
        //    throw new NotImplementedException();
        //}
        
        //// PUT: api/Root/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody]string value)
        //{
        //    throw new NotImplementedException();
        //}
        
        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
