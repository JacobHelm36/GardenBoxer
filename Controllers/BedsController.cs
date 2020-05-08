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
  public class BedsController : ControllerBase
  {
    private readonly BedsService _bs;
    public BedsController(BedsService bs)
    {
      _bs = bs;
    }

    [HttpPut("{id}")]
    [Authorize]
    public ActionResult<Bed> Edit(int id, [FromBody] Bed editedBed)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        editedBed.UserId = userId;
        editedBed.Id = id;
        return Ok(_bs.Edit(editedBed));
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
    [Authorize]
    public ActionResult<Bed> Delete(int id)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_bs.Delete(id, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}