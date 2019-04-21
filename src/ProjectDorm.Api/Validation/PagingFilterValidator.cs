// <copyright file="GetBookingsFilterValidator.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>20/04/2019 7:24 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using FluentValidation;
using ProjectDorm.Api.Filters.Base;

namespace ProjectDorm.Api.Validation
{
    /// <summary>
    /// Validator class for <see cref="PagingFilter"/>
    /// </summary>
    public class PagingFilterValidator : AbstractValidator<PagingFilter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagingFilterValidator" /> class.
        /// </summary>
        public PagingFilterValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Page number cannot be less than '1'");

            RuleFor(x => x.Size)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Page size cannot be less than '1'");
        }
    }
}