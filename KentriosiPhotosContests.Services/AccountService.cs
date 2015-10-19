namespace KentriosiPhotosContests.Services
{
    using System.Web;

    using Microsoft.AspNet.Identity;

    using KentriosiPhotoContest.Models;
    using KentriosiPhotoContest.Data;
    using Contracts;

    public class AccountService : BaseService, IAccountService
    {
        public AccountService(IKentriosiPhotoData kentriosiPhotoData)
           : base(kentriosiPhotoData)
        {
        }

        public User GetCurrentApplicationUser()
        {
            var principalId = HttpContext.Current.User.Identity.GetUserId();
            var user = this.Data.Users.Find(principalId);
            return user;
        }
    }
}
