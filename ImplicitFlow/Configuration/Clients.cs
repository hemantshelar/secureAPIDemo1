using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImplicitFlow.Configuration
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[] 
            {
                new Client
                { 
                    ClientId = "MVC",
                    ClientName = "MVC Client Name",
                    RedirectUris = new List<string>
                    {
                        "https://localhost:44302/"
                    },
                    Flow = Flows.Hybrid,
                    AllowAccessToAllScopes = true,
                    ClientSecrets  = new List<Secret>{
                        new Secret("secret".Sha256())
                    }
                }
            };
        }
    }
}