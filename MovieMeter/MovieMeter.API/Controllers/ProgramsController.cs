using MovieMeter.Model;
using MovieMeter.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MovieMeter.API.Controllers
{
    [Route("api/v1/Programs")]
    public class ProgramsController : ApiController
    {
        private IMovieMeterService _service;

        public ProgramsController(IMovieMeterService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get([FromUri]ProgramQuery query)
        {
            try
            {
                var result = await _service.GetAllPrograms(query);
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(string programId)
        {
            try
            {
                var result = await _service.GetProgram(programId);
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put([FromBody]Program program)
        {
            try
            {

                await _service.UpdateProgram(program);
            }
            catch (Exception)
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}
