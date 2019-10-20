// <copyright file="JwtOptions.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>19/04/2019 11:40 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

namespace ProjectDorm.Domain.Options
{
    /// <summary>
    /// Jwt options
    /// </summary>
    public class JwtOptions
    {
        /// <summary>
        /// Gets or sets jwt secret
        /// </summary>
        public string Secret { get; set; }
    }
}