using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using restPhil.Models;

namespace restPhil.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CoreSellerController : ControllerBase
    {
        private readonly RestSettings _settings;
        public CoreSellerController(IOptions<RestSettings> settingsOptions)
        {
            _settings = settingsOptions.Value;
        }
        // GET: api/CoreSeller
        [HttpPost]
        public IEnumerable<CoreSellersList> Get([FromBody] LocationsRequest request)
        {
            using (IDbConnection db = new SqlConnection(_settings.ConnectionString))
            {
                string readSp = "zRest_GetCoreSeller";

                DynamicParameters parameter = new DynamicParameters();

                parameter.Add("@ZipCode", request.ZipCode);
                parameter.Add("@Lat", request.lat);
                parameter.Add("@Lng", request.lng);
                parameter.Add("@Range", request.range);
                parameter.Add("@RangeUnits", request.RangeUnits);

               return db.Query<CoreSellersList>(readSp, parameter, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        // GET: api/CoreSeller/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }


        // PUT: api/CoreSeller/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
