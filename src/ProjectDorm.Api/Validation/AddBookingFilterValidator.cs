// <copyright file="AddBookingFilterValidator.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>20/04/2019 7:57 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using System.Linq;
using FluentValidation;
using ProjectDorm.Api.Filters;
using ProjectDorm.Domain.Database.Entities;
using ProjectDorm.Domain.Database.Providers.Interfaces;

namespace ProjectDorm.Api.Validation
{
    /// <summary>
    /// Validator class for <see cref="AddBookingFilter"/>
    /// </summary>
    public class AddBookingFilterValidator : AbstractValidator<AddBookingFilter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddBookingFilterValidator" /> class.
        /// </summary>
        public AddBookingFilterValidator(ILinqProvider linqProvider)
        {
            RuleFor(x => x.StartDate)
                .LessThanOrEqualTo(x => x.EndDate)
                .WithMessage("'startdDate' cannot be greater that 'endDate'");


            RuleFor(x => x.EndDate)
                .GreaterThanOrEqualTo(x => x.StartDate)
                .WithMessage("'endDate' cannot be less that 'startDate'");

            RuleFor(x => x)
                .Must(y =>
                {
                    var bookingsDates = linqProvider.Query<BookingEntity>()
                        .Where(x=>x.RoomId == y.RoomId)
                        .Select(x => new {x.StartDate, x.EndDate})
                        .ToList();

                    foreach (var booking in bookingsDates)
                    {
                        if(y.StartDate < booking.EndDate.AddDays(1) && y.EndDate > booking.StartDate) {
                            return false;
                        }
                    }

                    return true;
                })
                .WithMessage("There is overlapping with existing bookings, please re-check yours request dates");
        }
    }
}