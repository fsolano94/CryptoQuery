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
    [Route("/api/[controller]")]
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
                return BadRequest(userOrError.Error);
            }

            UserGetDto user = new UserGetDto()
            {
                Topics = userOrError.Value.ArticleQueryProfile.Topics.Split(',').Select(topic => topic.Trim()).ToList(),
                Email = userOrError.Value.Email,
                UserId = userOrError.Value.Id
            };
             
            return Ok(user);
        }

        //// POST: api/User
        [HttpPost(nameof(CreateUser))]
        public IActionResult CreateUser([FromBody]UserPostDto userPostDto)
        {
            var user = new User()
            {
                ArticleQueryProfile = new ArticleQueryProfile()
                {
                    Id = Guid.NewGuid(),
                    Complexity = userPostDto.Complexity,
                    Quality = userPostDto.Quality,
                    Topics = String.Join(",", userPostDto.Topics.Select(topic => topic.Trim()).ToList())
                },
                Id = Guid.NewGuid(),
                Email = userPostDto.Email,
                Role = "StandardUser",
                CreatedAt = DateTime.Now.ToLongDateString(),
                UpdatedAt = "no update",
                PlainTextPassword = userPostDto.Password
            };

            var userOrError = _userService.GetUserByEmail(userPostDto.Email);

            if (userOrError.IsSuccess)
            {
                return BadRequest($"User with {userPostDto.Email} already exists.");
            }

            var createdUser = _userService.Create(user);

            var createdUserDto = new UserGetDto()
            {
                Topics = createdUser.Value.ArticleQueryProfile.Topics.Split(',').Select(topic => topic.Trim()).ToList(),
                Email = createdUser.Value.Email,
                UserId = createdUser.Value.Id
            };

            return Ok(createdUserDto);
        }

        [HttpPatch(nameof(UpdateEmail)+ "/{userId}", Name = nameof(UpdateEmail))]
        public IActionResult UpdateEmail([FromRoute]Guid userId, [FromBody] EmailPostDto emailPostDto)
        {
            var userOrError = _userService.Get(userId);

            if (userOrError.IsFailure)
            {
                return NotFound($"User with id {userId} not found.");
            }

            var newEmail = new EmailPostDto()
            {
                Email = _userService.UpdateEmail(userId, emailPostDto.Email).Value.Email
            };

            return Ok(newEmail);
        }

        [HttpPatch(nameof(UpdateUserTopics) +"/{userId}" )]
        public IActionResult UpdateUserTopics([FromRoute(Name = "userId")]Guid userId, [FromBody]ListOfTopicsDto listOfTopicsDto)
        {
            var userOrError = _userService.Get(userId);

            if (userOrError.IsFailure)
            {
                return NotFound($"User with id {userId} not found.");
            }

            var updatedTopics = _userService.UpdateTopics(userId, listOfTopicsDto.Topics).Value.ArticleQueryProfile.Topics.Split(',').Select(topic => topic.Trim()).ToList();
            
            return Ok(new ListOfTopicsDto(){Topics =  updatedTopics});
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

        [HttpDelete(nameof(DeleteUserTopics) + "/{userId}")]
        public IActionResult DeleteUserTopics([FromRoute]Guid userId ,[FromBody] ListOfTopicsDto topicsToDelete)
        {
            var updatedTopics = _userService.DeleteUserTopics(userId, topicsToDelete.Topics).Value.ArticleQueryProfile.Topics.Split(',').Select(topic => topic.Trim()).ToList();
            return Ok();
        }


        [HttpDelete()]
        public IActionResult Delete([FromBody] DeleteUserDto userToDelete)
        {
            _userService.Delete(userToDelete.userId);
            return Ok();
        }
    }
}
