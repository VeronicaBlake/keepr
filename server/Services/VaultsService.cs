using System;
using System.Collections.Generic;
using server.Models;
using server.Repositories;

namespace server.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _vrepo;

        public VaultsService(VaultsRepository vrepo)
        {
            _vrepo = vrepo;
        }
        internal IEnumerable<Vault> GetAll()
        {
            return _vrepo.GetAll();
        }

        internal Vault GetById(int id)
        {
            Vault vault = _vrepo.GetById(id);
            if (vault == null)
            {
                throw new Exception("Invalid Id");
            }
            return vault;
        }

        //Gets the vault from the profile 
        internal IEnumerable<Vault> GetVaultsByProfileId(string id)
        {
            IEnumerable<Vault> vault = _vrepo.GetByProfileId(id);
            if (vault == null)
            {
                throw new Exception("Invalid Id");
            }
            return vault;
        }

        // internal Vault GetKeepByVaultId(int id)
        // {
        //     throw new NotImplementedException();
        // }

        internal Vault Create(Vault newVault)
        {
            Vault vault = _vrepo.Create(newVault);
            return vault;
        }

        internal Vault Update(Vault v, string id)
        {
            Vault vault = _vrepo.GetById(v.Id);

            if (vault == null)
            {
                throw new Exception("Invalid Id");
            }
            if (vault.creatorId != id)
            {
                throw new Exception("You must own this vault to edit it");
            }

            return _vrepo.Update(v);
        }

        internal void RemoveVault(int id, string userId)
        {
            Vault vault = GetById(id);

            if (vault.creatorId != userId)
            {
                throw new Exception("You must own this vault to delete it");
            }
            _vrepo.Remove(id);
        }
    }
}
// GetProfilesVaults, GetAll, GetVautById, 