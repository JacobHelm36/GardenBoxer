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
  public class BedTemplatesController : ControllerBase
  {
    private readonly BedTemplatesService _bts;
    public BedTemplatesController(BedTemplatesService bts)
    {
      _bts = bts;
    }

    [HttpPut("{id}")]
    [Authorize]
    public ActionResult<BedTemplate> Edit(int id, [FromBody] BedTemplate editedBedTemplate)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        editedBedTemplate.UserId = userId;
        return Ok(_bts.Edit(editedBedTemplate, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public ActionResult<BedTemplate> Post([FromBody] BedTemplate newBedTemplate)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newBedTemplate.UserId = userId;
        return Ok(_bts.Create(newBedTemplate));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<BedTemplate> Delete(int id)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_bts.Delete(id, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}