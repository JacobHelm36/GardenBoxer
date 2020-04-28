using System;
using System.Collections.Generic;
using System.Data;
using GardenBoxer.Models;
using GardenBoxer.Repositories;

namespace GardenBoxer.Services
{
  public class BedsService
  {
    private readonly BedsRepository _repo;
    public BedsService(BedsRepository repo)
    {
      _repo = repo;
    }

    public Bed Create(Bed newBed)
    {
      return _repo.Create(newBed);
    }

    public IEnumerable<Bed> GetBedsByGardenId(int GardenId, string userId)
    {
      return _repo.GetBedsByGardenId(GardenId, userId);
    }
    public Bed GetById(int BedId, string UserId)
    {
      return _repo.GetById(BedId, UserId);
    }

    public Bed Edit(Bed newdBed, string userId)
    {
      Bed original = GetById(newdBed.Id, userId);
      original.UserId = userId;
      original.Name = newdBed.Name != null ? newdBed.Name : original.Name;
      original.DateFertilized = newdBed.DateFertilized != null ? newdBed.DateFertilized : original.DateFertilized;
      original.Width = newdBed.Width != 0 ? newdBed.Width : original.Width;
      original.Height = newdBed.BedX != 0 ? newdBed.BedX : original.BedX;
      original.BedX = newdBed.Height != 0 ? newdBed.Height : original.Height;
      original.BedY = newdBed.BedY != 0 ? newdBed.BedY : original.BedY;
      original.DatePlanted = newdBed.DatePlanted != null ? newdBed.DatePlanted : original.DatePlanted;
      return _repo.Edit(original);
    }

    public string Delete(int id, string userId)
    {
      if(_repo.Delete(id, userId))
      {
        return "Deleted";
      }
        throw new Exception("That Bed doesn't exist");
    }
  }
}