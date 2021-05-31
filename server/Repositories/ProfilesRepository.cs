
using System.Data;
using Dapper;
using server.Models;

namespace server.Repositories
{
    public class ProfilesRepository
    {
        private readonly IDbConnection _db;

        public ProfilesRepository(IDbConnection db)
        {
            _db = db;
        }
        internal Profile GetById(string id)
        {
            string sql = "SELECT * FROM Profiles WHERE id = @id";
            return _db.QueryFirstOrDefault<Profile>(sql, new { id });
        }

        internal Profile Create(Profile newProfile)
        {
            string sql = @"
            INSERT INTO Profiles
              (name, picture, email, id)
            VALUES
              (@Name, @Picture, @Email, @Id)";
            _db.Execute(sql, newProfile);
            return newProfile;
        }
    }
}