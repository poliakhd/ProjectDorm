// <copyright file="UserServiceTests.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>20/04/2019 9:04 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ProjectDorm.Domain.Database.Entities;
using ProjectDorm.Domain.Options;
using ProjectDorm.Infrastructure.Services;
using Xunit;

namespace ProjectDorm.Infrastructure.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async void Authenticate_UserNotExists_ReturnsNull()
        {
            var fakeUserManager = A.Fake<UserManager<AppUserEntity>>();

            A.CallTo(() => fakeUserManager.FindByNameAsync(A<string>._))
                .Returns((AppUserEntity)null);

            var fakeUserService = new UserService(fakeUserManager, A.Fake<IOptions<JwtOptions>>());

            var result = await fakeUserService.AuthenticateAsync("test", "test");

            result.Should().BeNull();
        }

        [Fact]
        public async void Authenticate_PasswordNotValid_ReturnsNull()
        {
            var fakeUserManager = A.Fake<UserManager<AppUserEntity>>();

            A.CallTo(() => fakeUserManager.CheckPasswordAsync(A<AppUserEntity>._, A<string>._))
                .Returns(false);

            var fakeUserService = new UserService(fakeUserManager, A.Fake<IOptions<JwtOptions>>());

            var result = await fakeUserService.AuthenticateAsync("test", "test");

            result.Should().BeNull();
        }
    }
}