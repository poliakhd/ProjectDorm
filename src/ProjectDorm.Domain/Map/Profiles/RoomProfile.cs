// <copyright file="RoomProfile.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>20/04/2019 8:52 PM</date>
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
    /// Room map profile
    /// </summary>
    public class RoomProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomProfile" /> class.
        /// </summary>
        public RoomProfile()
        {
            CreateMap<RoomEntity, RoomDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Size, y => y.MapFrom(z => z.Size));

            CreateMap<PagedResult<RoomEntity>, PagedResult<RoomDto>>()
                .ForMember(x => x.Result, y => y.MapFrom(z => z.Result));
        }
    }
}