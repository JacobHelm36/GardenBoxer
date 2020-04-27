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
    public IEnumerable<Bed> Get()
    {
      return _repo.Get();
    }

    public Bed Create(Bed newBed)
    {
      return _repo.Create(newBed);
    }

    public IEnumerable<Bed> GetBedsByGardenId(int GardenId, string userId)
    {
      return _repo.GetBedsByGardenId(GardenId, userId);
    }

    public Bed Edit(Bed newdBed, string userId)
    {
      Bed original = GetById(newdBed.Id);
      original.UserId = userId;
      original.Name = editedBed.Name != null ? newBed.Name : original.Name;
      original.DateFertilized = newdBed.DateFertilized != null ? newdBed.DateFertilized : original.DateFertilized;
      original.Width = newdBed.Width != null ? newdBed.Width : original.Width;
      original.Height = newdBed.BedX != null ? newdBed.BedX : original.BedX;
      original.BedX = newdBed.Height != null ? newdBed.Height : original.Height;
      original.BedY = newdBed.BedY != null ? newdBed.BedY : original.BedY;
      original.DatePlanted = newdBed.DatePlanted != null ? newdBed.DatePlanted : original.DatePlanted;
      return _repo.Edit(original);
    }

    public BedsRepository Delete(int id, string userId)
    {
      return _repo.Delete(id, userId);
    }
  }
}