using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CryptoQuery.Api.Controllers
{
    [Produces("application/json")]
    [Route("/Authenticate")]
    public class AuthenticateController : Controller
    {
        [AllowAnonymous]
        [ProducesResponseType(typeof(AuthenticatePostDto), 200)]
        [HttpPost]
        public IActionResult CreateToken([FromBody]LoginModel login)
        {
            var authResult = Authenticate(login);

            if (authResult.IsFailure)
            {
                return Unauthorized();
            }

            return Ok(new AuthenticatePostDto { Token = BuildToken(authResult.Value) });
        }
        private string BuildToken(string role)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KeyStore.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Role, role)
            };
            var token = new JwtSecurityToken(KeyStore.Issuer,
                KeyStore.Issuer,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds,
                claims: claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Result<string> Authenticate(LoginModel login)
        {
            if (login.Username == "test" && login.Password == "testPassword")
            {
                return Result.Ok("StandardUser");
            }

            if (login.Username == "api" && login.Password == "apiPassword")
            {
                return Result.Ok("ApiUser");
            }

            return Result.Fail<string>("Login failed");
        }

        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

    }

}