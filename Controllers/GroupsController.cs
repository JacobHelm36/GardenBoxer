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
// NOTE for managing individual groups

namespace GardenBoxer.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class GroupsController : ControllerBase
  {
    private readonly GroupsService _gs;
    private readonly BedGroupsService _bgs;
    public GroupsController(GroupsService gs, BedGroupsService bgs)
    {
      _gs = gs;
      _bgs = bgs;
    }

    [HttpGet]
    [Authorize]
    public ActionResult<IEnumerable<Group>> GetAll()
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_gs.GetAll(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{groupId}/beds")]
    [Authorize]
    public ActionResult<IEnumerable<BedGroupViewModel>> GetBedsByGroupId(int groupId)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_bgs.GetBedsByGroupId(groupId, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public ActionResult<Group> Edit(int id, [FromBody] Group editedGroup)
    {
      try
      {
        editedGroup.Id = id;
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        editedGroup.UserId = userId;
        return Ok(_gs.Edit(editedGroup));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public ActionResult<Group> Post([FromBody] Group newGroup)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newGroup.UserId = userId;
        return Ok(_gs.Create(newGroup));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<Group> Delete(int id)
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