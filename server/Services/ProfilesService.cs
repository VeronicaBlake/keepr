using server.Models;
using server.Repositories;

namespace server.Services
{
    public class ProfilesService
    {
        private readonly ProfilesRepository _pr;
        public ProfilesService(ProfilesRepository pr)
        {
            _pr = pr;
        }
        internal Profile GetOrCreateProfile(Profile userInfo)
        {
            Profile profile = _pr.GetById(userInfo.Id);
            if (profile == null)
            {
                return _pr.Create(userInfo);
            }
            return profile;
        }

        internal Profile GetProfileById(string id)
        {
            return _pr.GetById(id);
        }
    }
}
