using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Core;
using Framework.Persistence.Ef;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Tcm.Application.Contract.SchoolTypes;
using Tcm.Domain.Interfaces;
using Tcm.Domain.Model;
using Tcm.Interface.Api.Helpers;

namespace Tcm.Interface.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/SchoolType")]
    public class SchoolTypeController : Controller
    {

        private ISchoolTypeService _schoolTypeService;
        public SchoolTypeController(ISchoolTypeService schoolTypeService)
        {
            _schoolTypeService = schoolTypeService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]SchoolType value)
        {

            _schoolTypeService.Add(value);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(short id, [FromBody]SchoolType value)
        {

            _schoolTypeService.Update(id, value);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get(UserParams userParams)
        {
            var items = _schoolTypeService.GetAll(userParams);
            userParams.Count = _schoolTypeService.GetAll(x => true).Count;
            Response.AddPagination(userParams);

            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult Get(short id)
        {

            var SchoolType = _schoolTypeService.Get(id);

            return Ok(SchoolType);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(short id)
        {

            _schoolTypeService.Delete(id);

            return Ok();
        }
    }
}