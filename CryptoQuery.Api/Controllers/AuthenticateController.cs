using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CryptoQuery.Api.Dto;
using CryptoQuery.Domain;
using CryptoQuery.Domain.Users;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CryptoQuery.Api.Controllers
{
    [Produces("application/json")]
    [Route("/api/[controller]")]
    [ApiVersion("1.0")]
    public class AuthenticateController : Controller
    {
        private UserService _userService;
        private IMapper _mapper;
        public AuthenticateController(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [ProducesResponseType(typeof(AuthenticatePostDto), 200)]
        [HttpPost(Name = nameof(CreateToken))]
        public IActionResult CreateToken([FromBody]LoginModel login)
        {
            var authResult = Authenticate(login);

            var user = _userService.GetUserByEmail(login.email);

            if (authResult.IsFailure)
            {
                return Unauthorized();
            }

            return Ok(new AuthenticateGetDto { Id = user.Value.Id, Email = user.Value.Email, Token = BuildToken(authResult.Value), Topics = user.Value.ArticleQueryProfile.Topics.Split(',').Select(topic => topic.Trim()).ToList() });
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
                expires: DateTime.Now.AddYears(1),
                signingCredentials: creds,
                claims: claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Result<string> Authenticate(LoginModel login)
        {
            var userOrError = _userService.GetUserByEmail(login.email);

            if (userOrError.IsFailure)
            {
                return Result.Fail<string>(userOrError.Error);
            }

            if ( string.Compare(userOrError.Value.PlainTextPassword, login.Password, StringComparison.InvariantCultureIgnoreCase) == 0 )
            {
                return (userOrError.Value.Role == "Administrator") ? Result.Ok("Administrator") : Result.Ok("StandardUser");
            }
        
            return Result.Fail<string>("Incorrect password.");
        }

        public class LoginModel
        {
            public string email { get; set; }
            public string Password { get; set; }
        }

    }

}