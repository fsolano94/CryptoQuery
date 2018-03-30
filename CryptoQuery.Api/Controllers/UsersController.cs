using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CryptoQuery.Api.Dto;
using CryptoQuery.Domain;
using CryptoQuery.Domain.Users;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoQuery.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("/[controller]")]
    [ApiVersion("1.0")]
    public class UsersController : Controller
    {
        UserService _userService;
        IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="mapper"></param>
        public UsersController(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: api/User
        [HttpGet(Name = nameof(Get))]
        public IActionResult Get()
        {
            var usersOrError = _userService.Get();

            if (usersOrError.IsFailure)
            {
                return BadRequest(usersOrError);
            }

            // automapper
            var userDtos = _mapper.Map<IEnumerable<UserGetDto>>(usersOrError.Value);

            foreach (var user in userDtos)
            {
                user.Href = Url.Link(nameof(Get), null);
                user.Href += $"/{user.Id}";
            }
            
            return Ok(Result.Ok(userDtos));
        }

        //// GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _userService.Get(id);

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(_mapper.Map<UserGetDto>(result.Value));
        }

        //// POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody]UserPostDto userPostDto)
        {
            var user = _mapper.Map<User>(userPostDto);

            user.Role = "StandardUser";

            return Ok(_userService.Create(user));
        }

        [HttpPost("{id}/updatePassword")]
        public IActionResult UpdatePassword([FromRoute(Name = "id")]Guid userId, [FromBody] string newPassword)
        {
            var userOrError = _userService.Get(userId);

            if (userOrError.IsFailure)
            {
                return BadRequest(userOrError);
            }

            userOrError.Value.HashedPassword = newPassword;

            return Ok(_userService.Update(userOrError.Value));
        }

        //// PUT: api/User/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}
