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
      return _repo.Get(userId);
    }

    public Garden Create(Garden newGarden)
    {
      return _repo.Create(newGarden);
    }
    public Garden GetById(int Id, string UserId)
    {
      return _repo.GetById(Id, UserId);
    }

    public Garden Edit(Garden newdGarden, string userId)
    {
      Garden original = GetById(newdGarden.Id);
      original.UserId = userId;
      original.Name = editedGarden.Name != null ? newGarden.Name : original.Name;
      original.Description = newdGarden.Description != null ? newdGarden.Description : original.Description;
      original.Width = newdGarden.Width != null ? newdGarden.Width : original.Width;
      original.Height = newdGarden.Height != null ? newdGarden.Height : original.Height;
      return _repo.Edit(original);
    }
    public Garden Delete(int id, string userId)
    {
      return _repo.Delete(id, userId);
    }
  }
}