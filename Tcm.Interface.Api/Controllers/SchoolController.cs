using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Persistence.Ef;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tcm.Application.Contract.Schools;
using Tcm.Application.Contract.SchoolTypes;
using Tcm.Interface.Api.Helpers;

namespace Tcm.Interface.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/School")]
    public class SchoolController : Controller
    {

        private ISchoolService _schoolService;
        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]SchoolDto value)
        {
            _schoolService.Add(value);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]SchoolDto value)
        {

            _schoolService.Update(id, value);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get(UserParams userParams)
        {
            var items = _schoolService.GetAll(userParams);
            Response.AddPagination(userParams);

            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var School = _schoolService.Get(id);

            return Ok(School);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _schoolService.Delete(id);

            return Ok();
        }
    }
}
