// <copyright file="FilterModel.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>21/04/2019 7:23 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

namespace ProjectDorm.Domain.Models
{
    /// <summary>
    /// Paging model
    /// </summary>
    public class PagingModel
    {
        /// <summary>
        /// Gets or sets page number
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets size number
        /// </summary>
        public int Size { get; set; }
    }
}