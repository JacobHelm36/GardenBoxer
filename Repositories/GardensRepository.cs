using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
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