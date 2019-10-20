// <copyright file="JwtTokenProfile.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>20/04/2019 6:57 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using AutoMapper;
using ProjectDorm.Domain.Dto;
using ProjectDorm.Domain.Models;

namespace ProjectDorm.Domain.Map.Profiles
{
    /// <summary>
    /// Jwt map profile
    /// </summary>
    public class JwtTokenProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JwtTokenProfile" /> class.
        /// </summary>
        public JwtTokenProfile()
        {
            CreateMap<TokenUserModel, TokenUserDto>();
        }
    }
}