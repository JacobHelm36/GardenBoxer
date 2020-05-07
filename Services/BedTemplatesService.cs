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

    public BedTemplate Create(BedTemplate newBedTemplate)
    {
      return _repo.Create(newBedTemplate);
    }

    // public IEnumerable<BedTemplate> GetBedTemplatesByGardenId(int GardenId, string userId)
    // {
    //   return _repo.GetBedTemplatesByGardenId(GardenId, userId);
    // }
    public BedTemplate GetById(int BedTemplateId, string UserId)
    {
      return _repo.GetById(BedTemplateId, UserId);
    }

    public BedTemplate Edit(BedTemplate newBedTemplate, string userId)
    {
      BedTemplate original = GetById(newBedTemplate.Id, userId);
      original.UserId = userId;
      original.Name = newBedTemplate.Name != null ? newBedTemplate.Name : original.Name;
      original.Width = newBedTemplate.Width != 0 ? newBedTemplate.Width : original.Width;
      original.Height = newBedTemplate.Height != 0 ? newBedTemplate.Height : original.Height;
      original.Img = newBedTemplate.Img != null ? newBedTemplate.Img : original.Img;
      return _repo.Edit(original);
    }

    public string Delete(int id, string userId)
    {
      if (_repo.Delete(id, userId))
      {
        return "Deleted";
      }
      throw new Exception("That BedTemplate doesn't exist");
    }
  }
}