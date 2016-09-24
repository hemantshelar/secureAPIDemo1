using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.Linq;
using System.Web;

namespace ImplicitFlow.Configuration
{
    public static class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            List<Scope> scopes = new List<Scope>
            {
                new Scope
                {
                    Name = "testScope",
                    DisplayName = "Display Name of scope.",
                    Emphasize = true,
                    Description = "Description of scope",
                    Enabled = true,
                    Claims = new List<ScopeClaim>
                    {
                        //new ScopeClaim(IdentityServer3.Core.Constants.ClaimTypes.GivenName,alwaysInclude: true),
                        new ScopeClaim(IdentityServer3.Core.Constants.ClaimTypes.FamilyName,alwaysInclude: true),
                        new ScopeClaim(IdentityServer3.Core.Constants.ClaimTypes.Role,alwaysInclude: true)
                    },
                    Type = ScopeType.Resource
                }
            };

            scopes.AddRange(StandardScopes.All);
            return scopes;
        }
    }
}