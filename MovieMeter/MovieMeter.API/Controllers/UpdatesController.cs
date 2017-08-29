using MovieMeter.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MovieMeter.API.Controllers
{
    [Route("api/v1/Updates")]
    public class UpdatesController : ApiController
    {
        private IMovieMeterService _service;

        public UpdatesController(IMovieMeterService service)
        {
            _service = service;
        }


    }
}
