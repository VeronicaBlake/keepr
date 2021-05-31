using System;
using System.Collections.Generic;
using server.Models;

namespace server.Services
{
    public class VaultsService
    {
        internal IEnumerable<Vault> GetVaultByProfileId(string id1, string id2)
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<Vault> GetKeepByProfileId(string id1, string id2)
        {
            throw new NotImplementedException();
        }
    }
}
//CreateVault(only if logged in), GetProfilesVaults, GetAll, GetVautById, Update/Edit, Remove