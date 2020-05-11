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

// NOTE for managing bed group relationships and data in bedgroups
namespace GardenBoxer.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BedGroupsController : ControllerBase
  {
    private readonly BedGroupsService _bgs;
    private readonly BedsService _bs;
    public BedGroupsController(BedGroupsService bgs, BedsService bs)
    {
      _bgs = bgs;
      _bs = bs;
    }

    [HttpPut("{id}")]
    [Authorize]
    public ActionResult<BedGroup> Edit(int id, [FromBody] BedGroup editedBedGroup)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        editedBedGroup.UserId = userId;
        editedBedGroup.Id = id;
        return Ok(_bgs.Edit(editedBedGroup));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public ActionResult<BedGroup> Post([FromBody] BedGroup newBedGroup)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newBedGroup.UserId = userId;
        Bed bed = _bs.GetById(newBedGroup.BedId, userId);
        newBedGroup.GardenId = bed.GardenId;
        return Ok(_bgs.Create(newBedGroup));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<BedGroup> Delete(int id)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_bgs.Delete(id, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}