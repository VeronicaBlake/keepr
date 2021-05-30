using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using server.Models;

namespace server.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;
        public KeepsRepository(IDbConnection db)
        {
            _db = db;
            //we just have one db, so that name can stay for all repos
        }
        internal IEnumerable<Keep> GetAll()
        {
            string sql = "SELECT * FROM keeps";
            return _db.Query<Keep>(sql);
            //Query is returning a collection (*)
        }

        internal Keep GetById(int id)
        {
            string sql = "SELECT * FROM keep WHERE id = @id";
            //   Query first or default returns a single item or null 
            //   (though if it's null that should be caught in service?)
            return _db.QueryFirstOrDefault<Keep>(sql, new { id });
        }

        internal Keep Create(Keep newKeep)
        {
            string sql = @"
        INSERT INTO keeps
        (name, description, img, )
        VALUES
        (@Name, @Description, @Img);
        SELECT LAST_INSERT_ID()";
            //these are the things without default in the model

            newKeep.Id = _db.ExecuteScalar<int>(sql, newKeep);
            //Scalar is for two things happening in on sql statement (insert into and select last)
            return newKeep;
        }

        internal Keep Update(Keep k)
        {
            string sql = @"
            UPDATE keep 
            SET 
                name = @Name,
                location = @Location
            WHERE id = @Id;
            ";
            _db.Execute(sql, k);
            return k;
        }

        internal void Remove(int id)
        {
            string sql = "DELETE FROM keeps WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }
    }
}