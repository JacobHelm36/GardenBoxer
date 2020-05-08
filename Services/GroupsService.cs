using System;
using System.Collections.Generic;
using System.Data;
using GardenBoxer.Models;
using GardenBoxer.Repositories;

namespace GardenBoxer.Services
{
  public class GroupsService
  {
    private readonly GroupsRepository _repo;
    public GroupsService(GroupsRepository repo)
    {
      _repo = repo;
    }

    public Group Create(Group newGroup)
    {
      return _repo.Create(newGroup);
    }

    // public IEnumerable<Group> GetGroupsByGardenId(int GardenId, string userId)
    // {
    //   return _repo.GetGroupsByGardenId(GardenId, userId);
    // }
    public Group GetById(int GroupId, string UserId)
    {
      return _repo.GetById(GroupId, UserId);
    }

    public Group Edit(Group newGroup)
    {
      Group original = GetById(newGroup.Id, newGroup.UserId);
      original.Name = newGroup.Name != null ? newGroup.Name : original.Name;
      return _repo.Edit(original);
    }
    public IEnumerable<Group> GetAll(string UserId)
    {
      return _repo.GetAll(UserId);
    }

    public string Delete(int id, string userId)
    {
      if (_repo.Delete(id, userId))
      {
        return "Deleted";
      }
      throw new Exception("That Group doesn't exist");
    }
  }
}