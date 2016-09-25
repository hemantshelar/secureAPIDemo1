using Core;
using Core.VM;
using Product.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        IUnitOfWork productUow = null;

        public ValuesController(IUnitOfWork productUow)
        {
            this.productUow = productUow;

        }
        // GET: api/Values
        //public IHttpActionResult Get()
        //{

        //    try
        //    {
        //        var r = productUow.Customers.Get();
        //        var result = r.Where(rr => rr.Id > 0).Select(n => new 
        //        {
        //            IdVal = n.Id,
        //            TEstName = n.Name

        //        }).ToList();
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    return NotFound();

        //}


        //public IEnumerable<object> Get()
        //{
        //    try
        //    {
        //        var r = productUow.Customers.Get();
        //        var result = r.Where(rr => rr.Id > 0).Select(n => new
        //        {
        //            IdVal = n.Id,
        //            TEstName = n.Name

        //        }).ToList();
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    return null;
        //}


        public IHttpActionResult Get()
        {
            var r = productUow.Customers.Get();
            var result = r.Where(rr => rr.Id > 0).Select(n => new CustomerVM
            {
                ID = n.Id,
                Name = n.Name
            }).ToList();
            return Ok(result);
        }

        // GET: api/Values/5
        //[Authorize]
        public IHttpActionResult Get(int id)
        {
            return NotFound();
        }

        // POST: api/Values
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Values/5
        public void Delete(int id)
        {
        }
    }
}
