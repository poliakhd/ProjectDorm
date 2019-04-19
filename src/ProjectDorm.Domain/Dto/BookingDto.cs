// <copyright file="BookingDto.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>19/04/2019 10:08 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using System;

namespace ProjectDorm.Domain.Dto
{
    public class BookingDto
    {
        /// <summary>
        /// Gets or sets booking room id
        /// </summary>
        public int RoomId { get; set; }

        /// <summary>
        /// Gets or sets booking start date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets booking end date
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}