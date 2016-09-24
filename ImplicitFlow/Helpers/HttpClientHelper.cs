using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web;

namespace ImplicitFlow.Helpers
{
    public class HttpClientHelper
    {
        public HttpClient GetHttpClient()
        {
            ClaimsPrincipal principal = HttpContext.Current.User as ClaimsPrincipal;
            var accessTokenClaim = principal.Claims.Where(c => c.Type.Equals("access_token")).SingleOrDefault();
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:61569/api/");
            client.SetBearerToken(accessTokenClaim.Value);

            return client;            
        }


        public void TestApi()
        {
            HttpClient client = this.GetHttpClient();
            var r1 = client.GetAsync("values").Result;
            var r2 = client.GetAsync("values/4").Result;

            var r3 = client.GetAsync("ManageUser").Result;
            var r4 = client.GetAsync("ManageUser/4").Result;
            Console.WriteLine("ok");
        }

    }
}