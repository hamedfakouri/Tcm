using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Persistence.Ef;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tcm.Application.Contract.Provinces;
using Tcm.Interface.Api.Helpers;

namespace Tcm.Interface.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Province")]
    public class ProvinceController : Controller
    {
            private IProvinceService _provinceService;
            
            public ProvinceController(IProvinceService provinceService)
            {
            this._provinceService = provinceService;
            }

            [HttpPost]
            public IActionResult Post([FromBody]ProvinceDto value)
            {

                _provinceService.Add(value);

                return Ok();
            }

            [HttpPut("{id}")]
            public IActionResult Put(short id, [FromBody]ProvinceDto value)
            {

            _provinceService.Update(id, value);

                return Ok();
            }

            [HttpGet]
            public IActionResult Get(UserParams userParams)
            {
                var items = _provinceService.GetAll(userParams);
                Response.AddPagination(userParams);

                return Ok(items);
            }

            [HttpGet("{id}")]
            public IActionResult Get(short id)
            {

                var educationCourseDto = _provinceService.Get(id);

                return Ok(educationCourseDto);
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(short id)
            {

            _provinceService.Delete(id);

                return Ok();
            }
        }
    
}
