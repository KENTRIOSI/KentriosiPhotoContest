using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using KentriosiPhotoContest.Models;
using KentriosiPhotoContest.Models.Enums;
using KentriosiPhotoContest.MVC.Infrastructure.Mapping;

namespace KentriosiPhotoContest.MVC.Models.ViewModels.Profile
{
    public class ProfileViewModel
        :IMapFrom<User>,IHaveCustomMappings
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public DateTime RegisteredOn { get; set; }

        public int ContestsParticipatedIn { get; set; }

        public int ContestsWon { get; set; }

        public IQueryable<ProfileContestsViewModel> ActiveContests { get; set; }

        public IQueryable<ProfileContestsViewModel> PassedContests { get; set; }

        public IQueryable<ProfileViewModel> OwnedContensts { get; set; } 

        //public static Expression<Func<User, ProfileViewModel>> Create
        //{
        //    get
        //    {
        //        return u => new ProfileViewModel()
        //        {
        //            UserName = u.UserName,
        //            ContestsWon = u.ContestsWon.Count,
        //            ContestsParticipatedIn = u.ContestsParticipated.Count,
        //            Email = u.Email,
        //            RegisteredOn = u.RegisteredOn,
        //            ActiveContests = u.ContestsParticipated
        //                .Where(c => c.Status == ContestStatus.Open)
        //                .Select(c => new ProfilePageContestsViewModel()
        //                {
        //                    DateCreated = c.DateCreated,
        //                    DeadLineDate = c.DeadLineDate.Value,
        //                    Description = c.Description,
        //                    EndDate = c.EndDate.Value,
        //                    //Status = c.Status.ToString(),
        //                    Title = c.Title
        //                }).OrderByDescending(c => c.DateCreated).AsQueryable(),
        //            PassedContests = u.ContestsParticipated
        //                .Where(c => c.Status == ContestStatus.Closed)
        //                .Select(c => new ProfilePageContestsViewModel()
        //                {
        //                    DateCreated = c.DateCreated,
        //                    DeadLineDate = c.DeadLineDate.Value,
        //                    Description = c.Description,
        //                    EndDate = c.EndDate.Value,
        //                    //Status = c.Status.ToString(),
        //                    Title = c.Title
        //                }).OrderByDescending(c => c.DateCreated).AsQueryable(),
        //        };
        //    }
        //}

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<User, ProfileViewModel>()
                .ForMember(vm => vm.ContestsParticipatedIn, opt => opt.MapFrom(u => u.ContestsParticipated.Count))
                .ForMember(vm => vm.ContestsWon, opt => opt.MapFrom(u => u.ContestsWon.Count))
                .ForMember(vm => vm.ActiveContests,
                    opt => opt.MapFrom(u => u.ContestsParticipated.Where(c => c.Status == ContestStatus.Open)))
                .ForMember(vm => vm.ContestsParticipatedIn,
                    opt => opt.MapFrom(u => u.ContestsParticipated.Where(c => c.Status == ContestStatus.Closed)))
                .ForMember(vm => vm.OwnedContensts,
                opt => opt.MapFrom(u => u.ContestsOwned));
        }
    }
}
