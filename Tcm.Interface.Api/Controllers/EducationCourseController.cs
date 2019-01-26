using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Persistence.Ef;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Tcm.Application.Contract.EducationCourses;
using Tcm.Domain.Interfaces;
using Tcm.Domain.Model;
using Tcm.Interface.Api.Helpers;

namespace Tcm.Interface.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/EducationCourse")]
    public class EducationCourseController : Controller
    {

        private IEducationCourseService _educationCourseService;
        public EducationCourseController(IEducationCourseService educationCourseService)
        {
            _educationCourseService = educationCourseService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]EducationCourse value)
        {

            _educationCourseService.Add(value);

            return Ok(); 
        }

        [HttpPut("{id}")]
        public IActionResult Put( short id,[FromBody]EducationCourse value)
        {

            _educationCourseService.Update(id,value);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get(UserParams userParams)
        {
            var items = _educationCourseService.GetAll(userParams);
            Response.AddPagination(userParams);

            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult Get(short id)
        {

          var educationCourseDto =  _educationCourseService.Get(id);

            return Ok(educationCourseDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(short id)
        {

             _educationCourseService.Delete(id);

            return Ok();
        }
    }
    }