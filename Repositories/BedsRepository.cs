using System;
using System.Collections.Generic;
using System.Data;
using GardenBoxer.Models;
using Dapper;

namespace GardenBoxer.Repositories
{
  public class BedsRepository
  {
    private readonly IDbConnection _db;

    public BedsRepository(IDbConnection db)
    {
      _db = db;
    }

    // internal IEnumerable<Garden> Get()
    // {
    //   string sql = "SELECT * FROM Beds WHERE isPrivate = 0;";
    //   return _db.Query<Garden>(sql);
    // }

    internal Bed Create(Bed BedData)
    {
      string sql = @"
            INSERT INTO beds
            (name, userId, bedX, bedY, width, height, datePlanted, dateFertilized)
            VALUES
            (@Name, @UserId, @BedX, @BedY, @Width, @Height, @DatePlanted, @DateFertilized);
            SELECT LAST_INSERT_ID();
            ";
      BedData.Id = _db.ExecuteScalar<int>(sql, BedData);
      return BedData;
    }
    internal IEnumerable<Bed> GetBedsByGardenId(int GardenId, string UserId)
    {
      string sql = "SELECT * FROM beds WHERE (userId = @UserId AND gardenId = @GardenId)";
      return _db.Query<Bed>(sql, new { UserId, GardenId });
    }

    internal Bed GetById(int Id, string UserId)
    {
      string sql = "SELECT * FROM beds WHERE (id = @Id AND userId = @UserId)";
      return _db.QueryFirstOrDefault<Bed>(sql, new { Id, UserId });
    }
    internal Bed Edit(Bed EditedBed)
    {
      string sql = @"
        UPDATE beds
        SET
            name = @Name,
            bedX = @BedX,
            bedY = @BedY,
            width = @Width,
            height = @Height,
            datePlanted = @DatePlanted,
            dateFertilized = @DateFertilized
        WHERE (id = @Id AND userId = @UserId);
        ";
      _db.Execute(sql, EditedBed);
      return EditedBed;
    }
    internal bool Delete(int Id, string UserId)
    {
      string sql = "DELETE FROM beds WHERE (id = @Id AND userId = @UserId) LIMIT 1";
      int removed = _db.Execute(sql, new { Id });
      return removed == 1;
    }
  }
}