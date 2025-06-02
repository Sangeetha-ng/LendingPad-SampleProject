using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User Get(Guid id);
        IEnumerable<User> Get(UserTypes? userType = null, string name = null, string email = null);
        void DeleteAll();
        IEnumerable<User> GetUsersByTag(string tag);
    }
}