using System.Collections.Generic;
using System.Linq;
using KentriosiPhotoContest.Models;

namespace KentriosiPhotosContests.Services.Contracts
{
    public interface IProfileService
    {
        IQueryable<User> GetAllUsers();
    }
}