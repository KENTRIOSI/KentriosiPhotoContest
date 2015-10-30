using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using KentriosiPhotoContest.Data;
using KentriosiPhotoContest.Models;
using KentriosiPhotosContests.Services.Contracts;

namespace KentriosiPhotosContests.Services
{
    public class ProfileService:BaseService,IProfileService
    {
        public ProfileService(IKentriosiPhotoData kentriosiPhotoData) : base(kentriosiPhotoData)
        {
        }

        public IQueryable<User> GetAllUsers()
        {
            return this.Data.Users.All();
        }
    }
}
