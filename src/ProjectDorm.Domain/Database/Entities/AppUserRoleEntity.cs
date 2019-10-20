// <copyright file="AppUserRoleEntity.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>19/04/2019 10:27 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using Microsoft.AspNetCore.Identity;

namespace ProjectDorm.Domain.Database.Entities
{
    /// <summary>
    /// Dorm app user role
    /// </summary>
    public class AppUserRoleEntity : IdentityRole<int>
    {
        
    }
}