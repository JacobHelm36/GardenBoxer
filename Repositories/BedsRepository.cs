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

    internal Keep Create(Garden GardenData)
    {
      throw new NotImplementedException();
    }
  }
}