﻿using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace ImplicitFlow.Configuration
{
    public static class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Username = "Bob",Password = "password",Subject = "1",
                    Claims = new []
                    {
                        new Claim(Constants.ClaimTypes.GivenName,"firstName"),
                        new Claim(Constants.ClaimTypes.FamilyName,"lastName"),
                        new Claim(Constants.ClaimTypes.Role,"admin")
                    }
                }
            };
        }
    }
}