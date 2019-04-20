// <copyright file="BookingProfile.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>20/04/2019 7:49 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using AutoMapper;
using ProjectDorm.Common.Models.Paging;
using ProjectDorm.Domain.Database.Entities;
using ProjectDorm.Domain.Dto;

namespace ProjectDorm.Domain.Map.Profiles
{
    /// <summary>
    /// Booking map profile
    /// </summary>
    public class BookingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookingProfile" /> class.
        /// </summary>
        public BookingProfile()
        {
            CreateMap<BookingEntity, BookingDto>()
                .ForMember(x => x.RoomId, y => y.MapFrom(z => z.RoomId))
                .ForMember(x => x.StartDate, y => y.MapFrom(z => z.EndDate))
                .ForMember(x => x.EndDate, y => y.MapFrom(z => z.EndDate));

            CreateMap<PagedResult<BookingEntity>, PagedResult<BookingDto>>()
                .ForMember(x => x.Result, y => y.MapFrom(z => z.Result));
        }
    }
}