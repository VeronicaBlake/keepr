using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using server.Models;

namespace server.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;
        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal IEnumerable<Vault> GetAll()
        {
            throw new NotImplementedException();
        }

        internal Vault GetById(int id)
        {
            throw new NotImplementedException();
        }

        internal Vault Create(Vault newVault)
        {
            throw new NotImplementedException();
        }

        internal Vault Update(Vault v)
        {
            throw new NotImplementedException();
        }

        internal void Remove(int id)
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<Vault> GetByProfileId(string creatorId)
        {
            string sql = "SELECT * FROM vaults WHERE creatorId = @creatorId";
            return _db.Query<Vault>(sql, new { creatorId });
        }
    }
}