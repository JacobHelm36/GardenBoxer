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
    public Garden Delete(int id, string userId)
    {
      return _repo.Delete(id, userId);
    }
  }
}