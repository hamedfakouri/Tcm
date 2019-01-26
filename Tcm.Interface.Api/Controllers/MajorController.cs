using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Persistence.Ef;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Tcm.Application.Contract.Majors;
using Tcm.Domain.Interfaces;
using Tcm.Domain.Model;
using Tcm.Interface.Api.Helpers;

namespace Tcm.Interface.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Major")]
    public class MajorController : Controller
    {

        private IMajorService _MajorService;
        public MajorController(IMajorService MajorService)
        {
            _MajorService = MajorService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Major value)
        {

            _MajorService.Add(value);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(short id, [FromBody]Major value)
        {

            _MajorService.Update(id, value);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get(UserParams userParams)
        {
            var items = _MajorService.GetAll(userParams);
            Response.AddPagination(userParams);

            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult Get(short id)
        {

            var Major = _MajorService.Get(id);

            return Ok(Major);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(short id)
        {

            _MajorService.Delete(id);

            return Ok();
        }
    }
}