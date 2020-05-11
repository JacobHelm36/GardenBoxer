using System;
using System.Collections.Generic;
using System.Data;
using GardenBoxer.Models;
using GardenBoxer.Repositories;

namespace GardenBoxer.Services
{
  public class BedGroupsService
  {
    private readonly BedGroupRepository _repo;
    public BedGroupsService(BedGroupRepository repo)
    {
      _repo = repo;
    }
    public BedGroup Create(BedGroup newBedGroup)
    {
      return _repo.Create(newBedGroup);
    }
    public IEnumerable<BedGroupViewModel> GetBedsByGroupId(int GroupId, string UserId)
    {
      return _repo.GetBedsByGroupId(GroupId, UserId);
    }
    public BedGroup GetById(int BedGroupId, string UserId)
    {
      return _repo.GetById(BedGroupId, UserId);
    }
    public BedGroup Edit(BedGroup newBedGroup)
    {
      BedGroup original = GetById(newBedGroup.Id, newBedGroup.UserId);
      original.BedId = newBedGroup.BedId != 0 ? newBedGroup.BedId : original.BedId;
      original.GroupId = newBedGroup.GroupId != 0 ? newBedGroup.GroupId : original.GroupId;
      original.GardenId = newBedGroup.GardenId != 0 ? newBedGroup.GardenId : original.GardenId;
      return _repo.Edit(original);
    }
    public string Delete(int id, string userId)
    {
      if (_repo.Delete(id, userId))
      {
        return "Deleted";
      }
      throw new Exception("That BedGroup doesn't exist");
    }
  }
}