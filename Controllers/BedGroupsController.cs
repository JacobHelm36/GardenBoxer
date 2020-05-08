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

// namespace GardenBoxer.Controllers
// {
//   [ApiController]
//   [Route("api/[controller]")]
//   public class GroupsController : ControllerBase
//   {
//     // private readonly GroupsService _bgs;
//     // public GroupsController(GroupsService bgs)
//     // {
//     //   _bgs = bgs;
//     // }

//     [HttpGet]
//     [Authorize]
//     public ActionResult<IEnumerable<Group>> GetAll()
//     {
//       try
//       {
//         string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
//         editedGroup.UserId = userId;
//         editedGroup.Id = id;
//         return Ok(_bgs.Edit(editedGroup));
//       }
//       catch (Exception e)
//       {
//         return BadRequest(e.Message);
//       }
//     }

//     [HttpPut("{id}")]
//     [Authorize]
//     public ActionResult<Group> Edit(int id, [FromBody] Group editedGroup)
//     {
//       try
//       {
//         string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
//         editedGroup.UserId = userId;
//         editedGroup.Id = id;
//         return Ok(_bgs.Edit(editedGroup));
//       }
//       catch (Exception e)
//       {
//         return BadRequest(e.Message);
//       }
//     }

//     [HttpPost]
//     [Authorize]
//     public ActionResult<Group> Post([FromBody] Group newGroup)
//     {
//       try
//       {
//         var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
//         newGroup.UserId = userId;
//         return Ok(_bgs.Create(newGroup));
//       }
//       catch (Exception e)
//       {
//         return BadRequest(e.Message);
//       }
//     }

//     [HttpDelete("{id}")]
//     [Authorize]
//     public ActionResult<Group> Delete(int id)
//     {
//       try
//       {
//         string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
//         return Ok(_bgs.Delete(id, userId));
//       }
//       catch (Exception e)
//       {
//         return BadRequest(e.Message);
//       }
//     }

//   }
// }