using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using knights.Models;

namespace knights.Data
{
    public class KnightsRepository
    {
      private readonly IDbConnection _db;
      public KnightsRepository(IDbConnection db)
      {
        _db = db;
      }

      public List<Knight> GetAll()
      {
        var sql = "SELECT * FROM knights";
        return _db.Query<Knight>(sql).ToList();
      }

      public Knight Create(Knight knightData)
      {
        var sql = @"
          INSERT INTO knights(name)
          VALUES(@Name);
          SELECT LAST_INSERT_ID();
        ";

        int id = _db.ExecuteScalar<int>(sql, knightData);
        knightData.Id = id;
        return knightData;
      }
    }
}