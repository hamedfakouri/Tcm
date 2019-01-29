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
    [Route("api/SchoolSubType")]
    public class SchoolSubTypeController : Controller
    {

        private ISchoolSubTypeService _schoolSubTypeService;
        public SchoolSubTypeController(ISchoolSubTypeService schoolSubTypeService)
        {
            _schoolSubTypeService = schoolSubTypeService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]SchoolSubType value)
        {

            _schoolSubTypeService.Add(value);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(short id, [FromBody]SchoolSubType value)
        {

            _schoolSubTypeService.Update(id, value);

            return Ok();
        }

        [HttpGet("schoolType/{schoolTypeId}")]
        public IActionResult GetBySchoolId(short schoolTypeId)
        {
            var items = _schoolSubTypeService.GetAll(x=> x.SchoolTypeId == schoolTypeId);

            return Ok(items);
        }

        [HttpGet]
        public IActionResult Get(UserParams userParams)
        {
            var items = _schoolSubTypeService.GetAll(userParams);
            Response.AddPagination(userParams);

            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult Get(short id)
        {

            var schoolSubTypeDto = _schoolSubTypeService.Get(id);

            return Ok(schoolSubTypeDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(short id)
        {

            _schoolSubTypeService.Delete(id);

            return Ok();
        }
    }
}