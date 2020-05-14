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

    internal BedTemplate Create(BedTemplate BedTemplateData)
    {
      string sql = @"
            INSERT INTO bedtemplates
            (name, userId, width, height, img)
            VALUES
            (@Name, @UserId, @Width, @Height, @Img);
            SELECT LAST_INSERT_ID();
            ";
      BedTemplateData.Id = _db.ExecuteScalar<int>(sql, BedTemplateData);
      return BedTemplateData;
    }
    // internal IEnumerable<BedTemplate> GetBedTemplatesByGardenId(int GardenId, string UserId)
    // {
    //   string sql = "SELECT * FROM bedtemplates WHERE (userId = @UserId AND gardenId = @GardenId)";
    //   return _db.Query<BedTemplate>(sql, new { UserId, GardenId });
    // }
    internal IEnumerable<BedTemplate> GetAll(string UserId)
    {
      string sql = "SELECT * FROM bedtemplates WHERE userId = @UserId";
      return _db.Query<BedTemplate>(sql, new { UserId });
    }

    internal BedTemplate GetById(int Id, string UserId)
    {
      string sql = "SELECT * FROM bedtemplates WHERE (id = @Id AND userId = @UserId)";
      return _db.QueryFirstOrDefault<BedTemplate>(sql, new { Id, UserId });
    }
    internal BedTemplate Edit(BedTemplate EditedBedTemplate)
    {
      string sql = @"
        UPDATE bedtemplates
        SET
            name = @Name,
            width = @Width,
            height = @Height,
            img = @Img,
        WHERE (id = @Id AND userId = @UserId);
        ";
      _db.Execute(sql, EditedBedTemplate);
      return EditedBedTemplate;
    }
    internal bool Delete(int Id, string UserId)
    {
      string sql = "DELETE FROM bedtemplates WHERE (id = @Id AND userId = @UserId) LIMIT 1";
      int removed = _db.Execute(sql, new { Id });
      return removed == 1;
    }
  }
}