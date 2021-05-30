using System;
using System.Collections.Generic;
using server.Models;
using server.Repositories;

namespace server.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _krepo;

        public KeepsService(KeepsRepository krepo)
        {
            _krepo = krepo;
        }
        internal IEnumerable<Keep> GetAll()
        {
            return _krepo.GetAll();
        }

        internal Keep GetById(int id)
        {
            Keep keep = _krepo.GetById(id);
            if (keep == null)
            {
                throw new Exception("Invalid Id");
            }
            return keep;
        }

        internal Keep Create(Keep newKeep)
        {
            Keep keep = _krepo.Create(newKeep);
            return keep;
        }


        internal Keep Update(Keep k, string id)
        {
            Keep keep = _krepo.GetById(k.Id);

            if (keep == null)
            {
                throw new Exception("Invalid Id");
            }
            if (keep.CreatorId != id)
            {
                throw new Exception("You must own this keep to edit it");
            }

            return _krepo.Update(k);
        }
        internal void Remove(int id, string userId)
        {
            Keep keep = GetById(id);

            if (keep.CreatorId != userId)
            {
                throw new Exception("You must own this keep to delete it");
            }
            _krepo.Remove(id);
        }
    }
}