using System;
using System.Collections.Generic;
using System.Data;
using GardenBoxer.Models;
using GardenBoxer.Repositories;

namespace GardenBoxer.Services
{
  public class BedTemplatesService
  {
    private readonly BedTemplatesRepository _repo;
    public BedTemplatesService(BedTemplatesRepository repo)
    {
      _repo = repo;
    }

    // public BedTemplate Create(BedTemplate newBedTemplate)
    // {
    //   return _repo.Create(newBedTemplate);
    // }

    // public IEnumerable<BedTemplate> GetBedTemplatesByGardenId(int GardenId, string userId)
    // {
    //   return _repo.GetBedTemplatesByGardenId(GardenId, userId);
    // }
    // public BedTemplate GetById(int BedTemplateId, string UserId)
    // {
    //   return _repo.GetById(BedTemplateId, UserId);
    // }

    // public BedTemplate Edit(BedTemplate newdBedTemplate, string userId)
    // {
    //   BedTemplate original = GetById(newdBedTemplate.Id, userId);
    //   original.UserId = userId;
    //   original.Name = newdBedTemplate.Name != null ? newdBedTemplate.Name : original.Name;
    //   original.DateFertilized = newdBedTemplate.DateFertilized != null ? newdBedTemplate.DateFertilized : original.DateFertilized;
    //   original.Width = newdBedTemplate.Width != 0 ? newdBedTemplate.Width : original.Width;
    //   original.Height = newdBedTemplate.BedTemplateX != 0 ? newdBedTemplate.BedTemplateX : original.BedTemplateX;
    //   original.BedTemplateX = newdBedTemplate.Height != 0 ? newdBedTemplate.Height : original.Height;
    //   original.BedTemplateY = newdBedTemplate.BedTemplateY != 0 ? newdBedTemplate.BedTemplateY : original.BedTemplateY;
    //   original.DatePlanted = newdBedTemplate.DatePlanted != null ? newdBedTemplate.DatePlanted : original.DatePlanted;
    //   return _repo.Edit(original);
    // }

    // public string Delete(int id, string userId)
    // {
    //   if(_repo.Delete(id, userId))
    //   {
    //     return "Deleted";
    //   }
    //     throw new Exception("That BedTemplate doesn't exist");
    // }
  }
}