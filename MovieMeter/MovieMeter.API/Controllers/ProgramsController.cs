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
    [Route("api/v1/Programs")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProgramsController : ApiController
    {
        private IMovieMeterService _service;

        public ProgramsController(IMovieMeterService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                throw new Exception();
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        
        [HttpGet]
        public async Task<IHttpActionResult> Get(string id)
        {
            try
            {
                var result = await _service.GetProgram(id);
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
