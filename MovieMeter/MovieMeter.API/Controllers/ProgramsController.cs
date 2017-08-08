using MovieMeter.Repository.Contracts;
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
        private IMovieMeterRepository _repository;

        public ProgramsController(IMovieMeterRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await _repository.GetAllPrograms();
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


                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
