// <copyright file="IEntity.cs" company="10Apps">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>19/04/2019 9:57 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

namespace ProjectDorm.Domain.Database.Entities.Interfaces
{
    /// <summary>
    /// Base entity interface
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets id
        /// </summary>
        int Id { get; set; }
    }
}