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

    internal Keep Create(Garden GardenData)
    {
      throw new NotImplementedException();
    }
  }
}