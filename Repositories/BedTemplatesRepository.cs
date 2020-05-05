using System;
using System.Collections.Generic;
using System.Data;
using GardenBoxer.Models;
using Dapper;

namespace GardenBoxer.Repositories
{
  public class BedTemplatesRepository
  {
    private readonly IDbConnection _db;

    public BedTemplatesRepository(IDbConnection db)
    {
      _db = db;
    }

    // internal IEnumerable<Garden> Get()
    // {
    //   string sql = "SELECT * FROM BedTemplates WHERE isPrivate = 0;";
    //   return _db.Query<Garden>(sql);
    // }

    // internal BedTemplate Create(BedTemplate BedTemplateData)
    // {
    //   string sql = @"
    //         INSERT INTO beds
    //         (name, userId, bedX, bedY, width, height, datePlanted, dateFertilized, gardenId, img)
    //         VALUES
    //         (@Name, @UserId, @BedTemplateX, @BedTemplateY, @Width, @Height, @DatePlanted, @DateFertilized, @GardenId, @Img);
    //         SELECT LAST_INSERT_ID();
    //         ";
    //   BedTemplateData.Id = _db.ExecuteScalar<int>(sql, BedTemplateData);
    //   return BedTemplateData;
    // }
    // internal IEnumerable<BedTemplate> GetBedTemplatesByGardenId(int GardenId, string UserId)
    // {
    //   string sql = "SELECT * FROM beds WHERE (userId = @UserId AND gardenId = @GardenId)";
    //   return _db.Query<BedTemplate>(sql, new { UserId, GardenId });
    // }

    // internal BedTemplate GetById(int Id, string UserId)
    // {
    //   string sql = "SELECT * FROM beds WHERE (id = @Id AND userId = @UserId)";
    //   return _db.QueryFirstOrDefault<BedTemplate>(sql, new { Id, UserId });
    // }
    // internal BedTemplate Edit(BedTemplate EditedBedTemplate)
    // {
    //   string sql = @"
    //     UPDATE beds
    //     SET
    //         name = @Name,
    //         bedX = @BedTemplateX,
    //         bedY = @BedTemplateY,
    //         width = @Width,
    //         height = @Height,
    //         datePlanted = @DatePlanted,
    //         dateFertilized = @DateFertilized
    //     WHERE (id = @Id AND userId = @UserId);
    //     ";
    //   _db.Execute(sql, EditedBedTemplate);
    //   return EditedBedTemplate;
    // }
    // internal bool Delete(int Id, string UserId)
    // {
    //   string sql = "DELETE FROM beds WHERE (id = @Id AND userId = @UserId) LIMIT 1";
    //   int removed = _db.Execute(sql, new { Id });
    //   return removed == 1;
    // }
  }
}