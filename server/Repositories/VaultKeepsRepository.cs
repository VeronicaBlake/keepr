using System;
using System.Data;
using Dapper;
using server.Models;

namespace server.Repositories
{
    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;
        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal void DeleteVK(int id)
        {
            string sql = "DELETE * FROM vault_keeps WHERE id = @id";
            _db.Query<VaultKeeps>(sql, new { id });
        }

        internal VaultKeeps Get(int id)
        {
            string sql = "SELECT * FROM vault_keeps WHERE id = @id";
            return _db.QueryFirstOrDefault<VaultKeeps>(sql, new { id });
        }
    }
}
//GetKeepsByVaultId, CreateVaultKeeps, Remove