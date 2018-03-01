using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CryptoQuery.Api.Dto;
using CryptoQuery.Domain.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoQuery.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("[controller]")]
    //[ApiVersion("1.0")]
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
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userService.Get());
        }

        //// GET: api/User/5
        //[HttpGet("{id}")]
        //public IActionResult Get(Guid userId)
        //{
        //    return Ok(_userService.Get(userId));
        //}

        //// POST: api/User
        [HttpPost]
        public IActionResult PostRange([FromBody]IEnumerable<UserPostDto> userPostDtos)
        {
            var users = _mapper.Map<IEnumerable<User>>(userPostDtos);

            return Ok(_userService.Create(users));
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
