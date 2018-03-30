using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
    [Route("/[controller]")]
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
                expires: DateTime.Now.AddYears(1),
                signingCredentials: creds,
                claims: claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Result<string> Authenticate(LoginModel login)
        {
            var userOrNull = _userService.GetUserByUserName(login.Username);

            if ( userOrNull == null)
            {
                return Result.Fail<string>($"username '{login.Username}' not found.");
            }

            if ( userOrNull.HashedPassword == login.Password )
            {
                return (userOrNull.Role == "Administrator") ? Result.Ok("Administrator") : Result.Ok("StandardUser");
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