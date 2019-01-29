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

        [HttpGet]
        public IActionResult Get()
        {

            var items = _provinceService.GetAll(x=> true);

            return Ok(items);
        }

        [HttpGet("{id}/cities")]
        public IActionResult GetCities(short id)
        {

            var items = _provinceService.GetAllCities(id);

            return Ok(items);
        }


        [HttpGet("{id}/cities/{cityId}/regions")]
        public IActionResult GetRegionsByCityId(int cityId)
        {

            var items = _provinceService.GetAllRegions(cityId);

            return Ok(items);
        }

    }
    }
