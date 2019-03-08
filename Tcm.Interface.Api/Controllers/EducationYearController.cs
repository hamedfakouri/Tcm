using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Persistence.Ef;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Tcm.Application.Contract.EducationYears;
using Tcm.Domain.Interfaces;
using Tcm.Domain.Model;
using Tcm.Interface.Api.Helpers;

namespace Tcm.Interface.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/EducationYear")]
    public class EducationYearController : Controller
    {

        private IEducationYearService _educationYearService;
        public EducationYearController(IEducationYearService educationYearService)
        {
            _educationYearService = educationYearService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]EducationYearDto value)
        {

            _educationYearService.Add(value);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(short id, [FromBody]EducationYearDto value)
        {

            _educationYearService.Update(id, value);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get(UserParams userParams)
        {
            var items = _educationYearService.GetAll(userParams);
            Response.AddPagination(userParams);

            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult Get(short id)
        {

            var educationYearDto = _educationYearService.Get(id);

            return Ok(educationYearDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(short id)
        {

            _educationYearService.Delete(id);

            return Ok();
        }
    }
}