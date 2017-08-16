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
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await _service.GetAllPrograms();
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post()
        {
            try
            {

                await _service.HarvestMovieData();
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
