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
using Microsoft.EntityFrameworkCore.Internal;

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

        //// GET api/values/5
        [HttpGet(nameof(GetUserById) + "/{userId}", Name = nameof(GetUserById))]
        public IActionResult GetUserById([FromRoute(Name = "userId")]Guid id)
        {
            var userOrError = _userService.Get(id);

            if (userOrError.IsFailure)
            {
                return BadRequest(userOrError);
            }

            var user = _mapper.Map<UserGetDto>(userOrError.Value);

            user.Href = Url.Link(nameof(GetUserById), id);

            return Ok(user);
        }

        //// POST: api/User
        [HttpPost(nameof(CreateUser))]
        public IActionResult CreateUser([FromBody]UserPostDto userPostDto)
        {
            var user = _mapper.Map<User>(userPostDto);

            user.Role = "StandardUser";

            return Ok(_userService.Create(user));
        }

        [HttpPatch(nameof(UpdateUserName)+ "/{userId}", Name = nameof(UpdateUserName))]
        public IActionResult UpdateUserName([FromRoute(Name = "{userId}")]Guid userId, [FromBody]UserNameDto userNameDto)
        {
            var userOrError = _userService.Get(userId);

            if (userOrError.IsFailure)
            {
                return NotFound($"User with id {userId} not found.");
            }

            return Ok(_userService.UpdateUserName(userId, userNameDto.UserName));

        }

        [HttpPatch(nameof(UpdateEmail)+ "/{userId}", Name = nameof(UpdateEmail))]
        public IActionResult UpdateEmail([FromRoute]Guid userId, [FromBody] EmailPostDto emailPostDto)
        {
            var userOrError = _userService.Get(userId);

            if (userOrError.IsFailure)
            {
                return NotFound($"User with id {userId} not found.");
            }

            return Ok(_userService.UpdateEmail(userId, emailPostDto.Email));
        }

        [HttpPut(nameof(UpdateUser)+ "/{userId}", Name = nameof(UpdateUser))]
        public IActionResult UpdateUser([FromRoute(Name = "userId")]Guid userId, [FromBody]UpdateUserDto userWithInformationToBeUpdated)
        {
            var userOrError = _userService.Get(userId);

            if (userOrError.IsFailure)
            {
                return NotFound($"User with id {userId} not found.");
            }

            var user = new User()
            {
                Email = userWithInformationToBeUpdated.Email,
                UserName = userWithInformationToBeUpdated.UserName,
                ArticleQueryProfile = new ArticleQueryProfile()
                {
                    //Complexity = userWithInformationToBeUpdated.Complexity,
                    //PushEnabled = userWithInformationToBeUpdated.PushEnabled,
                    //Quality = userWithInformationToBeUpdated.Quality,
                    Topics = string.Join(',', userWithInformationToBeUpdated.Topics)
                }
            };

            return Ok(_userService.Update(userId, user));
        }

        [HttpPatch(nameof(AddNewTopics)+ "/{userId}", Name = nameof(AddNewTopics))]
        public IActionResult AddNewTopics([FromRoute(Name = "userId")]Guid userId,[FromBody] TopicsDto topicsDto)
        {
            var userOrError = _userService.Get(userId);

            if (userOrError.IsFailure)
            {
                return NotFound($"User with id {userId} not found.");
            }

            return Ok(_userService.UpdateTopics(userId, topicsDto.Topics));
        }

        [HttpPatch(nameof(UpdateUserSettings)+"/{userId}" )]
        public IActionResult UpdateUserSettings([FromRoute(Name = "userId")]Guid userId, [FromBody]ArticleQueryProfileUpdateDto articleQueryProfileUpdateDto)
        {
            var userOrError = _userService.Get(userId);

            if (userOrError.IsFailure)
            {
                return NotFound($"User with id {userId} not found.");
            }

            var newUserSettings = new ArticleQueryProfile()
            {
                PushEnabled = articleQueryProfileUpdateDto.PushEnabled,
                Complexity = articleQueryProfileUpdateDto.Complexity,
                Quality = articleQueryProfileUpdateDto.Quality,
                Topics = articleQueryProfileUpdateDto.Topics.Join(",")
            };

            return Ok(_userService.UpdateUserSettings( userId, newUserSettings));
        }

        [HttpPatch(nameof(UpdatePassword)+"/{userId}")]
        public IActionResult UpdatePassword([FromRoute]Guid userId, [FromBody] PasswordDto passwordDto)
        {
            var userOrError = _userService.Get(userId);

            if (userOrError.IsFailure)
            {
                return BadRequest(userOrError);
            }

            return Ok(_userService.Update(userId, passwordDto.Password));
        }


        [HttpDelete("{userId}")]
        public IActionResult Delete(Guid id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}
