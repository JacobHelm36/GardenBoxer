using System;
using System.Collections.Generic;
using System.Data;
using GardenBoxer.Models;
using Dapper;

namespace GardenBoxer.Repositories
{
  public class BedGroupsRepository
  {
    private readonly IDbConnection _db;

    public BedGroupsRepository(IDbConnection db)
    {
      _db = db;
    }

    // internal IEnumerable<Garden> Get()
    // {
    //   string sql = "SELECT * FROM BedGroups WHERE isPrivate = 0;";
    //   return _db.Query<Garden>(sql);
    // }

    internal IEnumerable<BedGroupViewModel> GetBedsByGroupId(int GroupId, string UserId)
    {
      string sql = @"
      SELECT 
        b.*,
        FROM bedgroups bg
        INNER JOIN beds b ON b.id = bg.bedId 
        WHERE (bg.userId = @userId AND bg.bedId = @id)";
      return _db.Query<BedGroupViewModel>(sql, new { GroupId, UserId });
    }
    internal BedGroup Create(BedGroup BedGroupData)
    {
      string sql = @"
            INSERT INTO bedgroups
            (bedId, userId, gardenId, groupId)
            VALUES
            (@BedId, @UserId, @GardenId, @GroupId);
            SELECT LAST_INSERT_ID();
            ";
      BedGroupData.Id = _db.ExecuteScalar<int>(sql, BedGroupData);
      return BedGroupData;
    }
    // internal IEnumerable<BedGroup> GetBedGroupsByGardenId(int GardenId, string UserId)
    // {
    //   string sql = "SELECT * FROM bedgroups WHERE (userId = @UserId AND gardenId = @GardenId)";
    //   return _db.Query<BedGroup>(sql, new { UserId, GardenId });
    // }

    internal BedGroup GetById(int Id, string UserId)
    {
      string sql = "SELECT * FROM bedgroups WHERE (id = @Id AND userId = @UserId)";
      return _db.QueryFirstOrDefault<BedGroup>(sql, new { Id, UserId });
    }
    internal BedGroup Edit(BedGroup EditedBedGroup)
    {
      string sql = @"
        UPDATE bedgroups
        SET
            bedId = @BedId,
            groupId = @GroupId,
            gardenId = @GardenId
        WHERE (id = @Id AND userId = @UserId);
        ";
      _db.Execute(sql, EditedBedGroup);
      return EditedBedGroup;
    }
    internal bool Delete(int Id, string UserId)
    {
      string sql = "DELETE FROM bedgroups WHERE (id = @Id AND userId = @UserId) LIMIT 1";
      int removed = _db.Execute(sql, new { Id });
      return removed == 1;
    }
  }
}