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

    [HttpGet("{GardenId}/beds")]
    [Authorize]
    public ActionResult<IEnumerable<Bed>> GetBedsByGardenId(int GardenId)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_bs.GetBedsByGardenId(GardenId, userId));
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
    public ActionResult<Bed> Post([FromBody] Bed newBed)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newBed.UserId = userId;
        return Ok(_bs.Create(newBed));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<Bed> Delete(int id)
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