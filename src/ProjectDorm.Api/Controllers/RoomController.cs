// <copyright file="RoomController.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>20/04/2019 7:44 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectDorm.Api.Filters;
using ProjectDorm.Api.Filters.Base;
using ProjectDorm.Common.Models.Paging;
using ProjectDorm.Domain.Dto;
using ProjectDorm.Domain.Models;
using ProjectDorm.Infrastructure.Providers.Interfaces;

namespace ProjectDorm.Api.Controllers
{
    /// <summary>
    /// Room controller
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/v1/room")]
    public class RoomController : Controller
    {
        private readonly IRoomProvider _roomProvider;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomController" /> class.
        /// </summary>
        public RoomController(IRoomProvider roomProvider, IMapper mapper)
        {
            _roomProvider = roomProvider;
            _mapper = mapper;
        }

        /// <summary>
        /// Method for getting all rooms
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/v1/room/all
        ///
        /// </remarks>
        /// <param name="filter">Filter model</param>
        /// <returns>List of rooms</returns>
        /// <response code="200">Returns list of rooms</response>
        /// <response code="204">Returns if there are no rooms</response>
        /// <response code="400">Returns if there are validation errors</response>
        /// <response code="500">Returns if there is system error</response>
        [HttpGet("all")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllRooms([FromQuery]PagingFilter filter)
        {
            var result = await _roomProvider.GetRoomsAsync(
                new PagingModel
                {
                    Page = filter.Page,
                    Size = filter.Size
                });

            if (result?.Result == null || !result.Result.Any())
            {
                return NoContent();
            }

            return Ok(_mapper.Map<PagedResult<RoomDto>>(result));
        }

        /// <summary>
        /// Method for getting all available dates for room
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/v1/room/{id}/available
        ///
        /// </remarks>
        /// <param name="filter">Filter model</param>
        /// <returns>List of available dates for room</returns>
        /// <response code="200">Returns list of available dates for room</response>
        /// <response code="400">Returns if there are validation errors</response>
        /// <response code="500">Returns if there is system error</response>
        [HttpGet("{id}/available")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAvailableRoomDates([FromQuery]GetAvailableRoomDatesFilter filter)
        {
            var result = await _roomProvider.GetAvailableRoomDates(filter.Id);
            return Ok(result);
        }

        /// <summary>
        /// Method for getting all available rooms for specified date
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET api/v1/room/all/available
        /// 
        /// </remarks>
        /// <param name="filter">Filter model</param>
        /// <param name="pagingFilter">Paging filter model</param>
        /// <returns>List of available rooms</returns>
        /// <response code="200">Returns list of available rooms</response>
        /// <response code="400">Returns if there are validation errors</response>
        /// <response code="500">Returns if there is system error</response>
        [HttpGet("all/available")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAvailableRooms([FromQuery]GetAvailableRoomsFilter filter, [FromQuery]PagingFilter pagingFilter)
        {
            var result = await _roomProvider.GetAvailableRooms(
                filter.StartDate, 
                filter.EndDate, 
                new PagingModel
                {
                    Page = pagingFilter.Page,
                    Size = pagingFilter.Size
                });

            return Ok(_mapper.Map<PagedResult<RoomDto>>(result));
        }
    }
}