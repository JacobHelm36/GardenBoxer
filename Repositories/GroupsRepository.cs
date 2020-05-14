using System;
using System.Collections.Generic;
using System.Data;
using GardenBoxer.Models;
using Dapper;

namespace GardenBoxer.Repositories
{
  public class GroupsRepository
  {
    private readonly IDbConnection _db;

    public GroupsRepository(IDbConnection db)
    {
      _db = db;
    }

    // internal IEnumerable<Garden> Get()
    // {
    //   string sql = "SELECT * FROM Groups WHERE isPrivate = 0;";
    //   return _db.Query<Garden>(sql);
    // }

    internal Group Create(Group GroupData)
    {
      string sql = @"
            INSERT INTO groups
            (name, userId)
            VALUES
            (@Name, @UserId);
            SELECT LAST_INSERT_ID();
            ";
      GroupData.Id = _db.ExecuteScalar<int>(sql, GroupData);
      return GroupData;
    }
    // internal IEnumerable<Group> GetGroupsByGardenId(int GardenId, string UserId)
    // {
    //   string sql = "SELECT * FROM groups WHERE (userId = @UserId AND gardenId = @GardenId)";
    //   return _db.Query<Group>(sql, new { UserId, GardenId });
    // }
    internal IEnumerable<Group> GetAll(string UserId)
    {
      string sql = "SELECT * FROM groups WHERE userId = @UserId";
      return _db.Query<Group>(sql, new { UserId });
    }

    internal Group GetById(int Id, string UserId)
    {
      string sql = "SELECT * FROM groups WHERE (id = @Id AND userId = @UserId)";
      return _db.QueryFirstOrDefault<Group>(sql, new { Id, UserId });
    }
    internal Group Edit(Group EditedGroup)
    {
      string sql = @"
        UPDATE groups
        SET
            name = @Name
        WHERE (id = @Id AND userId = @UserId);
        ";
      _db.Execute(sql, EditedGroup);
      return EditedGroup;
    }
    internal bool Delete(int Id, string UserId)
    {
      string sql = "DELETE FROM groups WHERE (id = @Id AND userId = @UserId) LIMIT 1";
      int removed = _db.Execute(sql, new { Id });
      return removed == 1;
    }
  }
}