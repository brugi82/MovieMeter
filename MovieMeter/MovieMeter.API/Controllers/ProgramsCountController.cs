using MovieMeter.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MovieMeter.API.Controllers
{
    [Route("api/v1/Programs/Count")]
    public class ProgramsCountController : ApiController
    {
        private IMovieMeterService _service;

        public ProgramsCountController(IMovieMeterService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var count = await _service.GetActiveProgramCount();
                return Ok(count);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
