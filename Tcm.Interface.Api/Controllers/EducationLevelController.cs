using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Tcm.Application.Contract.EducationLevels;
using Tcm.Domain.Interfaces;
using Tcm.Domain.Model;

namespace Tcm.Interface.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/EducationLevel")]
    public class EducationLevelController : Controller
    {

        private IEducationLevelService _educationLevelService;
        public EducationLevelController(IEducationLevelService educationLevelService)
        {
            _educationLevelService = educationLevelService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]EducationLevelAddDto value)
        {

            _educationLevelService.Add(value);

            return Ok(); 
        }

        [HttpGet]
        public IActionResult Get(short id)
        {

          var educationLevelDto =  _educationLevelService.Get(id);

            return Ok(educationLevelDto);
        }
    }
    }