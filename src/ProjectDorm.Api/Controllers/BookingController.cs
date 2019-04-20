// <copyright file="BookingController.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>19/04/2019 10:41 PM</date>
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
using ProjectDorm.Infrastructure.Providers.Interfaces;

namespace ProjectDorm.Api.Controllers
{
    /// <summary>
    /// Booking controller
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/v1/booking")]
    public class BookingController : Controller
    {
        private readonly IBookingProvider _bookingProvider;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingController" /> class.
        /// </summary>
        public BookingController(IBookingProvider bookingProvider, IMapper mapper)
        {
            _bookingProvider = bookingProvider;
            _mapper = mapper;
        }

        /// <summary>
        /// Method for getting all bookings
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/v1/booking/all
        ///
        /// </remarks>
        /// <param name="filter">Filter model</param>
        /// <returns>List of bookings</returns>
        /// <response code="200">Returns list of bookings</response>
        /// <response code="204">Returns if there are no bookings</response>
        /// <response code="500">Returns if there is system error</response>
        [HttpGet("all")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllBookings([FromQuery]PagingFilter filter)
        {
            var result = await _bookingProvider.GetBookingsAsync(filter.Page, filter.Size);

            if (result?.Result == null || !result.Result.Any())
            {
                return NoContent();
            }

            return Ok(_mapper.Map<PagedResult<BookingDto>>(result));
        }

        /// <summary>
        /// Method for getting all bookings
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/v1/booking/add
        ///
        /// </remarks>
        /// <param name="filter">Filter model</param>
        /// <returns>List of bookings</returns>
        /// <response code="200">Returns if room was booked</response>
        /// <response code="400">Returns if there are validation errors</response>
        /// <response code="500">Returns if there is system error</response>
        [HttpPost("add")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> AddBooking([FromQuery]AddBookingFilter filter)
        {
            var result = await _bookingProvider.AddBookingAsync(filter.RoomId, filter.StartDate, filter.EndDate);
            return Ok(_mapper.Map<BookingDto>(result));
        }
    }
}