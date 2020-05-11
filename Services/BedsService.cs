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

    public Bed Edit(Bed newBed)
    {
      Bed original = GetById(newBed.Id, newBed.UserId);
      original.Name = newBed.Name != null ? newBed.Name : original.Name;
      original.Description = newBed.Description != null ? newBed.Description : original.Description;
      original.DateFertilized = newBed.DateFertilized != null ? newBed.DateFertilized : original.DateFertilized;
      original.Width = newBed.Width != 0 ? newBed.Width : original.Width;
      original.Height = newBed.BedX != 0 ? newBed.BedX : original.BedX;
      original.BedX = newBed.Height != 0 ? newBed.Height : original.Height;
      original.BedY = newBed.BedY != 0 ? newBed.BedY : original.BedY;
      original.DatePlanted = newBed.DatePlanted != null ? newBed.DatePlanted : original.DatePlanted;
      original.Img = newBed.Img != null ? newBed.Img : original.Img;
      return _repo.Edit(original);
    }
    public BedGroupViewModel EditBedsByGroupId(BedGroupViewModel newBed)
    {
      if(newBed.DatePlanted != null && newBed.DateFertilized != null && newBed.Name != null && newBed.Height != 0 && newBed.Width != 0 && newBed.Img != null && newBed.Description != null)
      {
        return _repo.EditBedsInGroup(newBed);
      }
      throw new Exception("Some properties are null");
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