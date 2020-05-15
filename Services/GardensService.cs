using System;
using System.Collections.Generic;
using System.Data;
using GardenBoxer.Models;
using GardenBoxer.Repositories;

namespace GardenBoxer.Services
{
  public class GardensService
  {
    private readonly GardensRepository _repo;
    public GardensService(GardensRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Garden> Get(string userId)
    {
      return _repo.GetGardens(userId);
    }

    public Garden Create(Garden newGarden)
    {
      return _repo.Create(newGarden);
    }
    internal Garden GetById(int Id, string UserId)
    {
      return _repo.GetById(Id, UserId);
    }

    internal Garden Edit(Garden newGarden)
    {
      Garden original = GetById(newGarden.Id, newGarden.UserId);
      original.UserId = newGarden.UserId != null ? newGarden.UserId : original.UserId;
      original.Name = newGarden.Name != null ? newGarden.Name : original.Name;
      original.Description = newGarden.Description != null ? newGarden.Description : original.Description;
      original.Width = newGarden.Width != 0 ? newGarden.Width : original.Width;
      original.Height = newGarden.Height != 0 ? newGarden.Height : original.Height;
      original.BackGround = newGarden.BackGround != null ? newGarden.BackGround : original.BackGround;
      return _repo.Edit(original);
    }
    public string Delete(int id, string userId)
    {
      if(_repo.Delete(id, userId))
      {
      return "Deleted";
      }
        throw new Exception("That Garden doesn't exist");
    }
  }
}