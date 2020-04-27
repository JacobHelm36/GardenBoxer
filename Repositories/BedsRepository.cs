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
      VaultData.Id = _db.ExecuteScalar<int>(sql, BedData);
      return VaultData;
    }
    internal GetBedsByGardenId(int GardenId, string UserId)
    {
      string sql = "SELECT * FROM beds WHERE (userId = @UserId AND gardenId = @GardenId)";
      return _db.Query<IEnumerable<Bed>>(sql);
    }

    internal Keep GetById(int id)
    {
      string sql = "SELECT * FROM beds WHERE id = @Id";
      return _db.QueryFirstOrDefault<Bed>(sql, new { Id = id });
    }
    internal Edit(Bed EditedBed)
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
    }
    internal bool Delete(int id)
    {
      string sql = "DELETE FROM beds WHERE id = @id LIMIT 1";
      int removed = _db.Execute(sql, new { Id });
      return removed == 1;
    }
  }
}