using System;
using System.Collections.Generic;
using System.Data;
using GardenBoxer.Models;
using Dapper;

namespace GardenBoxer.Repositories
{
  public class GardensRepository
  {
    private readonly IDbConnection _db;

    public GardensRepository(IDbConnection db)
    {
      _db = db;
    }

    // internal IEnumerable<Garden> Get()
    // {
    //   string sql = "SELECT * FROM Gardens WHERE isPrivate = 0;";
    //   return _db.Query<Garden>(sql);
    // }

    internal Garden Create(Garden GardenData)
    {
      string sql = @"
            INSERT INTO gardens
            (name, userId, width, height, description)
            VALUES
            (@Name, @UserId, @Width, @Height, @Description);
            SELECT LAST_INSERT_ID();
            ";
      GardenData.Id = _db.ExecuteScalar<int>(sql, GardenData);
      return GardenData;
    }
    internal Garden Edit(Garden EditedGarden)
    {
      string sql = @"
        UPDATE gardens
        SET
            name = @Name,
            description = @Description,
            width = @Width,
            height = @Height
        WHERE (id = @Id AND userId = @UserId);
        ";
      _db.Execute(sql, EditedGarden);
      return EditedGarden;
    }
    internal Garden GetById(int Id, string UserId)
    {
      string sql = "SELECT * FROM gardens WHERE (id = @Id AND userId = @UserId)";
      return _db.QueryFirstOrDefault<Garden>(sql, new { Id, UserId });
    }
    internal IEnumerable<Garden> GetGardens(string UserId)
    {
      string sql = "SELECT * FROM gardens WHERE userId = @UserId";
      return _db.Query<Garden>(sql, new { UserId });
    }
    internal bool Delete(int Id, string UserId)
    {
      string sql = "DELETE FROM gardens WHERE (id = @Id AND userId = @UserId) LIMIT 1";
      int deleted = _db.Execute(sql, new { Id, UserId });
      return deleted == 1;
    }
  }
}