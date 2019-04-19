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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectDorm.Infrastructure.Providers.Interfaces;

namespace ProjectDorm.Api.Controllers
{
    /// <summary>
    /// Booking controller
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BookingController : Controller
    {
        private readonly IBookingProvider _bookingProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingController" /> class.
        /// </summary>
        public BookingController(IBookingProvider bookingProvider)
        {
            _bookingProvider = bookingProvider;
        }

        /// <summary>
        /// Method for getting all bookings
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /all
        ///
        /// </remarks>
        /// <returns>List of bookings</returns>
        /// <response code="200">Returns list of bookings</response>
        /// <response code="204">Returns if there are no bookings</response>
        /// <response code="500">Returns if there is system error</response>
        [HttpGet("all")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllBookings()
        {
            var result = await _bookingProvider.GetBookingsAsync();

            if (result == null || !result.Any())
            {
                return NoContent();
            }

            return Ok(result);
        }
    }
}