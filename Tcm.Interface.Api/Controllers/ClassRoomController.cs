using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Persistence.Ef;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tcm.Application.Contract.ClassRooms;
using Tcm.Application.Contract.EducationLevels;
using Tcm.Domain.Interfaces;
using Tcm.Domain.Model;
using Tcm.Interface.Api.Helpers;

namespace Tcm.Interface.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/ClassRoom")]
    public class ClassRoomController : Controller
    {

        private readonly IClassRoomService _classRoomService;

        public ClassRoomController(IClassRoomService classRoomService)
        {
            _classRoomService = classRoomService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]ClassRoomAddDto value)
        {
            _classRoomService.Add(value);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(short id, [FromBody]ClassRoomDto value)
        {
            _classRoomService.Update(id, value);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get(UserParams userParams)
        {
            var items = _classRoomService.GetAll(userParams);
            Response.AddPagination(userParams);

            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult Get(short id)
        {
            var educationLevelDto = _classRoomService.Get(id);

            return Ok(educationLevelDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(short id)
        {
            _classRoomService.Delete(id);

            return Ok();
        }
    }
}