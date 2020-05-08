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
      original.bedId = newBedGroup.bedId != 0 ? newBedGroup.bedId : original.bedId;
      original.groupId = newBedGroup.groupId != 0 ? newBedGroup.groupId : original.groupId;
      return _repo.Edit(original);
    }
    public IEnumerable<BedGroup> GetAll(string UserId)
    {
      return _repo.GetAll(UserId);
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