using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWebAPI.Controllers
{
    public class ManageUserController : ApiController
    {
        IUnitOfWork productUow = null;
        public ManageUserController(IUnitOfWork productUow)
        {
            this.productUow = productUow;
        } 
        // GET: api/ManageUser
        public IEnumerable<string> Get()
        {
            return new string[] { "manage user1", "Manage user 2" };
        }

        // GET: api/ManageUser/5
        [Authorize(Roles="admin")]
        public string Get(int id)
        {
            return "Only accessible to admin.";
        }

        // POST: api/ManageUser
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ManageUser/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ManageUser/5
        public void Delete(int id)
        {
        }
    }
}
