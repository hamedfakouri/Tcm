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
        public IActionResult Post([FromBody]SchoolSubTypeDto value)
        {

            _schoolSubTypeService.Add(value);

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(short Id, [FromBody]SchoolSubTypeDto value)
        {

            _schoolSubTypeService.Update(Id, value);

            return Ok();
        }

        [HttpGet]

        public IActionResult Get(UserParams userParams)
        {
            var items = _schoolSubTypeService.GetAll(userParams);
            userParams.Count = _schoolSubTypeService.GetAll(x => true).Count;
            Response.AddPagination(userParams);

            return Ok(items);
        }

        [HttpGet]
        public IActionResult Get(short id)
        {

            var schoolSubTypeDto = _schoolSubTypeService.Get(id);

            return Ok(schoolSubTypeDto);
        }

        [HttpGet]
        public IActionResult Delete(short id)
        {

            _schoolSubTypeService.Delete(id);

            return Ok();
        }
    }
}