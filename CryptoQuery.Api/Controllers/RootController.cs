using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoQuery.Api.Controllers
{
    [Produces("application/json")]
    [Route("/")]
    [ApiVersion("1.0")]
    public class RootController : Controller
    {
        [HttpGet(Name = nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var response = new
            {
                href = Url.Link(nameof(GetRoot), null),

                authenticate = new
                {
                    href = Url.Link(nameof(AuthenticateController.CreateToken), null)
                },
                articles = new
                {
                    href = Url.Link(nameof(ArticlesController.GetAllArticles), null)
                }
            };
            return Ok(response);
        }
    }
}