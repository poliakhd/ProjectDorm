// <copyright file="IUserService.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>19/04/2019 11:32 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using System.Threading.Tasks;
using ProjectDorm.Domain.Dto;

namespace ProjectDorm.Infrastructure.Services.Interfaces
{
    /// <summary>
    /// User service interface
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Asynchronous method for authenticate user
        /// </summary>
        /// <param name="userName">Username</param>
        /// <param name="password">Password</param>
        /// <returns><see cref="LoggedUserDto"/> instance</returns>
        Task<LoggedUserDto> AuthenticateAsync(string userName, string password);
    }
}