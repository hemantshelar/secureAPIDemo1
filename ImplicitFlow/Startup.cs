using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using IdentityServer3.Core.Configuration;
using ImplicitFlow.Configuration;
using IdentityServer3.Core.Resources;
using IdentityServer3.Core.Models;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using Microsoft.Owin.Security.OpenIdConnect;
using System.Collections.Generic;
using System.Web.Helpers;
using IdentityServer3.Core;
using System.IdentityModel.Tokens;
using IdentityModel.Client;
using System.Security.Claims;
using System.Web.Http;

[assembly: OwinStartup(typeof(ImplicitFlow.Startup))]

namespace ImplicitFlow
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            AntiForgeryConfig.UniqueClaimTypeIdentifier = Constants.ClaimTypes.Subject;
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            app.Map("/identity", appBuilder => {
                appBuilder.UseIdentityServer(new IdentityServer3.Core.Configuration.IdentityServerOptions
                {
                    SiteName = "Site Name",
                    SigningCertificate = LoadCertificate(),
                    RequireSsl = true,
                    Factory = new IdentityServer3.Core.Configuration.IdentityServerServiceFactory()
                    .UseInMemoryClients(Clients.Get())
                    .UseInMemoryUsers(Users.Get())
                    .UseInMemoryScopes(ImplicitFlow.Configuration.Scopes.Get())
                });
            });

            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                Authority = "https://localhost:44302/identity",
                ClientId = "MVC",
                RedirectUri = "https://localhost:44302/",
                ResponseType = "code id_token token",
                SignInAsAuthenticationType = "Cookies",
                Scope = "openid profile testScope",

                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    AuthorizationCodeReceived = async n =>
                    {
                        //var tokenClient = new TokenClient("https://localhost:44302/identity/connect/token", "MVC", "secret");
                        //var accessToken = tokenClient.RequestAuthorizationCodeAsync(n.Code, "https://localhost:44302/").Result;

                        //UserInfoClient client = new UserInfoClient(new Uri("https://localhost:44302/identity/connect/userinfo"), accessToken.AccessToken);
                        //var userInfoResponse = client.GetAsync().Result;

                        ClaimsIdentity i = new ClaimsIdentity(n.AuthenticationTicket.Identity.AuthenticationType,"name","role");
                        //i.AddClaims(userInfoResponse.GetClaimsIdentity().Claims);
                        ////i.AddClaims(n.AuthenticationTicket.Identity.Claims);

                        i.AddClaim(new Claim("access_token",n.ProtocolMessage.AccessToken));
                        n.AuthenticationTicket = new Microsoft.Owin.Security.AuthenticationTicket(i, n.AuthenticationTicket.Properties);
                        Console.WriteLine("test");
                    }
                }
            });

            //app.Map("/secureapi", appBuilder =>
            //{
                
            //});


        }

        private System.Security.Cryptography.X509Certificates.X509Certificate2 LoadCertificate()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Certificate");
            path = Path.Combine(path, "idsrv3test.pfx");
            return new X509Certificate2(path, "idsrv3test");
        }
    }
}
