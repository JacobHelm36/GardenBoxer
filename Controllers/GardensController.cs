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
    private readonly GardensService _gs;
    private readonly BedsService _bs;
    public GardensController(GardensService gs, BedsService bs)
    {
      _gs = gs;
      _bs = bs;
    }
    [HttpGet]
    [Authorize]
    public ActionResult<IEnumerable<Garden>> Get()
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_gs.Get(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{Id}")]
    [Authorize]
    public ActionResult<Garden> GetById(int Id)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_gs.GetById(Id, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }

    [HttpGet("{gardenId}/beds")]
    [Authorize]
    public ActionResult<IEnumerable<Bed>> GetBedsByGardenId(int gardenId)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_bs.GetBedsByGardenId(gardenId, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public ActionResult<Garden> Edit(int id, [FromBody] Garden editedGarden)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        editedGarden.UserId = userId;
        return Ok(_gs.Edit(editedGarden));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    [Authorize]
    public ActionResult<Garden> Post([FromBody] Garden newGarden)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newGarden.UserId = userId;
        return Ok(_gs.Create(newGarden));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<Garden> Delete(int id)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_gs.Delete(id, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}