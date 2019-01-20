using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Tcm.Application.Contract.EducationLevels;
using Tcm.Domain.Interfaces;
using Tcm.Domain.Model;
using Tcm.Interface.Api.Helpers;

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

        [HttpPut]
        public IActionResult Put(short Id,[FromBody]EducationLevelDto value)
        {

            _educationLevelService.Update(Id,value);

            return Ok();
        }

        [HttpGet]
 
        public IActionResult Get(UserParams userParams)
        {
            var items = _educationLevelService.GetAll(userParams);
            userParams.Count = _educationLevelService.GetAll(x=> true).Count;           
            Response.AddPagination(userParams);

            return Ok(items);
        }

        [HttpGet]
        public IActionResult Get(short id)
        {

          var educationLevelDto =  _educationLevelService.Get(id);

            return Ok(educationLevelDto);
        }

        [HttpGet]
        public IActionResult Delete(short id)
        {

             _educationLevelService.Delete(id);

            return Ok();
        }
    }
    }