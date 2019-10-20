// <copyright file="AuthenticateFilterValidator.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>20/04/2019 7:55 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using FluentValidation;
using ProjectDorm.Api.Filters;

namespace ProjectDorm.Api.Validation
{
    /// <summary>
    /// Validator class for <see cref="AuthenticateFilter"/>
    /// </summary>
    public class AuthenticateFilterValidator : AbstractValidator<AuthenticateFilter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticateFilterValidator" /> class.
        /// </summary>
        public AuthenticateFilterValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("'username' must not be empty");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("'password' must not be empty");
        }
    }
}