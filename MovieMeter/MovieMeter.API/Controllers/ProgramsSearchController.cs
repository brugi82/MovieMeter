using MovieMeter.Model;
using MovieMeter.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MovieMeter.API.Controllers
{
    [Route("api/v1/Programs/Search")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProgramsSearchController : ApiController
    {
        private IMovieMeterService _service;

        public ProgramsSearchController(IMovieMeterService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Get([FromBody]ProgramQuery query, int count = 25)
        {
            try
            {
                var result = await _service.GetAllPrograms(query, count);
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
