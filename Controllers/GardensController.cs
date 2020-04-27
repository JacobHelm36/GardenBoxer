using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GardenBoxer.Models;
using GardenBoxer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GardenBoxer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GardensController : ControllerBase
    {
        private readonly GardensService _ks;
        public GardensController(GardensService ks)
        {
            _ks = ks;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Garden>> Get()
        {
            try
            {
                return Ok(_ks.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            };
        }

        [HttpPost]
        [Authorize]
        public ActionResult<Garden> Post([FromBody] Garden newGarden)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                newGarden.UserId = userId;
                return Ok(_ks.Create(newGarden));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}