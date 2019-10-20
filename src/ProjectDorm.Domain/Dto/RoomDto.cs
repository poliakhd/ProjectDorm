// <copyright file="RoomDto.cs" company="">
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

namespace ProjectDorm.Domain.Dto
{
    /// <summary>
    /// Room data transfer object
    /// </summary>
    public class RoomDto
    {
        /// <summary>
        /// Gets or sets room id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets room size
        /// </summary>
        public int Size { get; set; }
    }
}