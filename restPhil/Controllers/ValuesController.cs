using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace restPhil.Controllers
{
    /// <summary>
    /// Values controller.
    /// </summary>
    [ApiVersion("1")]
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [MapToApiVersion("1")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values
        [HttpGet,MapToApiVersion("2")]
        public ActionResult<IEnumerable<string>> Getv2()
        {
            return new string[] { "value1 this is v2", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [MapToApiVersion("1")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [MapToApiVersion("1")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [MapToApiVersion("1")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [MapToApiVersion("1")]
        public void Delete(int id)
        {
        }
    }
}
