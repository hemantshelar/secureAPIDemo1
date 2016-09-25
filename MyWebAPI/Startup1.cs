using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using Microsoft.Practices.Unity;
using Unity.WebApi;
using Core.Models;
using Core;
using Product.DataContext;
using System.Net.Http.Headers;

[assembly: OwinStartup(typeof(MyWebAPI.Startup1))]

namespace MyWebAPI
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {


            // http://plnkr.co/edit/SLtXoyZ1mYG8xatovGEm?p=preview
            //Plnkr.co link for AngularJS app.

            //JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();
            //// For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            //app.UseIdentityServerBearerTokenAuthentication(new IdentityServer3.AccessTokenValidation.IdentityServerBearerTokenAuthenticationOptions
            //{
            //    Authority = "https://localhost:44302/identity",
            //    RequiredScopes = new List<string>
            //    {
            //        "testScope"
            //    }
            //});



            HttpConfiguration configuration = new HttpConfiguration();

            //Install-Package Microsoft.AspNet.WebApi.Cors
            configuration.EnableCors();
            
            configuration.Routes.MapHttpRoute("DefaultRoute","api/{controller}/{id}",new  {id = RouteParameter.Optional});

            var container = new UnityContainer();
            container.RegisterType<IUnitOfWork, ProductUOW>();
            container.RegisterType<ProductContext, ProductContext>();
            configuration.DependencyResolver = new UnityDependencyResolver(container);

            MediaTypeHeaderValue val = null;
            foreach (var item in configuration.Formatters.XmlFormatter.SupportedMediaTypes)
            {
                if (item.MediaType == "application/xml")
                {
                    val = item;
                    break;
                }                
            }


            configuration.Formatters.XmlFormatter.SupportedMediaTypes.Remove(val);

            
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
