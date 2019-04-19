// <copyright file="UserController.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>19/04/2019 11:45 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectDorm.Domain.Dto;
using ProjectDorm.Infrastructure.Services.Interfaces;

namespace ProjectDorm.Api.Controllers
{
    /// <summary>
    /// User controller
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController" /> class.
        /// </summary>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Method for Authenticate user
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /user/authenticate
        ///
        /// </remarks>
        /// <returns>List of bookings</returns>
        /// <response code="200">Returns if authenticated</response>
        /// <response code="400">Returns if has validation errors</response>
        /// <response code="404">Returns if user to authenticate not found</response>
        /// <response code="500">Returns if there is system error</response>
        /// <param name="model"><see cref="LoginDto"/> model</param>
        /// <returns><see cref="LoggedUserDto"/> model</returns>
        [HttpPost("authenticate")]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Authenticate([FromBody]LoginDto model)
        {
            var result = await _userService.AuthenticateAsync(model.UserName, model.Password);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Method for testing token access
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /user/test
        ///
        /// </remarks>
        /// <returns>List of bookings</returns>
        /// <response code="200">Returns if authorized</response>
        /// <response code="500">Returns if there is system error</response>
        /// <returns></returns>
        [HttpGet("test")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult TestAuthentication()
        {
            return Ok();
        }
    }
}