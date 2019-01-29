using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Persistence.Ef;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Tcm.Application.Contract.EducationSubCourses;
using Tcm.Domain.Interfaces;
using Tcm.Domain.Model;
using Tcm.Interface.Api.Helpers;

namespace Tcm.Interface.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/EducationSubCourse")]
    public class EducationSubCourseController : Controller
    {

        private IEducationSubCourseService _EducationSubCourseService;
        public EducationSubCourseController(IEducationSubCourseService EducationSubCourseService)
        {
            _EducationSubCourseService = EducationSubCourseService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]EducationSubCourse value)
        {

            _EducationSubCourseService.Add(value);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(short id, [FromBody]EducationSubCourse value)
        {

            _EducationSubCourseService.Update(id, value);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get(UserParams userParams)
        {
            var items = _EducationSubCourseService.GetAll(userParams);
            Response.AddPagination(userParams);

            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult Get(short id)
        {

            var EducationSubCourseDto = _EducationSubCourseService.Get(id);

            return Ok(EducationSubCourseDto);
        }


        [HttpGet("educationCourse/{educationCourseId}")]
        public IActionResult GetByEducationCourseId(short educationCourseId)
        {
            var items = _EducationSubCourseService.GetAll(x => x.EducationCourseId == educationCourseId);

            return Ok(items);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(short id)
        {

            _EducationSubCourseService.Delete(id);

            return Ok();
        }
    }
}