using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Persistence.Ef;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tcm.Application.Contract.SchoolEducationSubCourses;
using Tcm.Application.Contract.EducationLevels;
using Tcm.Domain.Interfaces;
using Tcm.Domain.Model;
using Tcm.Interface.Api.Helpers;

namespace Tcm.Interface.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/SchoolEducationSubCourse")]
    public class SchoolEducationSubCourseController : Controller
    {
        private readonly ISchoolEducationSubCourseService _SchoolEducationSubCourseService;
        public SchoolEducationSubCourseController(ISchoolEducationSubCourseService SchoolEducationSubCourseService)
        {
            _SchoolEducationSubCourseService = SchoolEducationSubCourseService;
        }

        [HttpGet]
        public IActionResult Get(int schoolId)
        {
            var items = _SchoolEducationSubCourseService.GetAll( x=> x.SchoolId == schoolId);

            return Ok(items);
        }
    }
}