using System;
using server.Models;
using server.Repositories;

namespace server.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _vkrepo;

        public VaultKeepsService(VaultKeepsRepository vkrepo)
        {
            _vkrepo = vkrepo;
        }

        internal object Create(VaultKeeps newVaultKeep)
        {
            throw new NotImplementedException();
        }

        internal object GetVaultKeeps(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteVaultKeeps(int id, string userId)
        {
            VaultKeeps found = _vkrepo.Get(id);
            if (found.creatorId != userId)
            {
                throw new Exception("You must own a vault to remove a keep");
            }
            _vkrepo.DeleteVK(id);
        }
    }
}
