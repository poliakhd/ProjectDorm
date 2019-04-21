// <copyright file="GetAvailableRoomDatesFilterValidator.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>21/04/2019 4:36 PM</date>
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
    /// Validator class for <see cref="GetAvailableRoomDatesFilter"/>
    /// </summary>
    public class GetAvailableRoomDatesFilterValidator : AbstractValidator<GetAvailableRoomDatesFilter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAvailableRoomDatesFilterValidator" /> class.
        /// </summary>
        public GetAvailableRoomDatesFilterValidator(ILinqProvider linqProvider)
        {
            RuleFor(x => x.Id)
                .Must(x => linqProvider.Query<RoomEntity>().Any(y => y.Id == x))
                .WithMessage("There is not such room with provided id");
        }
    }
}