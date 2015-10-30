using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using KentriosiPhotoContest.Models;
using KentriosiPhotoContest.MVC.Models.ViewModels;
using KentriosiPhotoContest.MVC.Models.ViewModels.Profile;
using KentriosiPhotosContests.Services.Contracts;

namespace KentriosiPhotoContest.MVC.Controllers
{
    public class UserController:BaseController
    {
        private IAccountService accountService;
        private IProfileService profileService;

        public UserController(IBaseService baseService,IAccountService accountService,IProfileService profileService) : base(baseService)
        {
            this.accountService = accountService;
            this.profileService = profileService;
        }

        public ActionResult Profile(string username)
        {
            //var userProfile = this.profileService.GetAllUsers().Select(ProfileViewModel.Create);

            var user = this.accountService.GetCurrentApplicationUser();
            Mapper.CreateMap<User, ProfileViewModel>();
            var userProfile = Mapper.Map<ProfileViewModel>(user);

            return View(userProfile);
        }
    }
}
