using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Collections.Generic;
using System.IdentityModel.Tokens;

[assembly: OwinStartup(typeof(MyWebAPI.Startup1))]

namespace MyWebAPI
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServer3.AccessTokenValidation.IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://localhost:44302/identity",
                RequiredScopes = new List<string>
                {
                    "testScope"
                }
            });



            HttpConfiguration configuration = new HttpConfiguration();
            configuration.Routes.MapHttpRoute("DefaultRoute","api/{controller}/{id}",new  {id = RouteParameter.Optional});

            app.UseWebApi(configuration);


           
           

            
            //HttpConfiguration configuration = new HttpConfiguration();
            
            //configuration.Routes.MapHttpRoute(name: "DefaultAPIRoute", routeTemplate: "api/{controller}/{id}", defaults: new { id = RouteParameter.Optional });

            //app.UseWebApi(configuration);

            //app.UseIdentityServerBearerTokenAuthentication(new IdentityServer3.AccessTokenValidation.IdentityServerBearerTokenAuthenticationOptions
            //{
            //    Authority = "https://localhost:44302/identity",
            //    RequiredScopes = new List<string>
            //    {
            //        "testScope"
            //    }
            //});
            
           
        }
    }
}
