using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using KentriosiPhotoContest.Models;
using KentriosiPhotoContest.Models.Enums;
using KentriosiPhotoContest.MVC.Infrastructure.Mapping;
using KentriosiPhotoContest.MVC.Models.ViewModels.Contest;

namespace KentriosiPhotoContest.MVC.Models.ViewModels.Profile
{
    public class ProfileViewModel
        //:IMapFrom<User>,IHaveCustomMappings
    {
        public ProfileInfoViewModel ProfileInfo { get; set; }

        public IEnumerable<ActiveContestsViewModel> ActiveContests { get; set; }

        public IEnumerable<WonnedContestsViewModel> WonnedContests { get; set; }

        public IEnumerable<OwnedContestViewModel> OwnedContensts { get; set; }

        public static Expression<Func<User, ProfileViewModel>> Create
        {
            get
            {
                return u => new ProfileViewModel()
                {
                    ProfileInfo = new ProfileInfoViewModel()
                    {
                        Id = u.Id,
                        UserName = u.UserName,
                        Email = u.Email,
                        RegisteredOn = u.RegisteredOn
                    },
                    ActiveContests = u.ContestsParticipated.Where(c=>c.Status==ContestStatus.Open)
                            .Select(c=> new ActiveContestsViewModel()
                            {
                                Id = c.Id,
                                DeadLineDate = c.DeadLineDate,
                                Description = c.Description,
                                EndDate = c.EndDate,
                                Title = c.Title,
                                DateCreated = c.DateCreated
                            }),
                    OwnedContensts = u.ContestsOwned
                            .Select(c=> new OwnedContestViewModel()
                            {
                                Id = c.Id,
                                DeadLineDate = c.DeadLineDate,
                                Description = c.Description,
                                EndDate = c.EndDate,
                                Title = c.Title,
                                DateCreated = c.DateCreated
                            }),
                    WonnedContests = u.ContestsWon
                            .Select(c=>new WonnedContestsViewModel()
                            {
                                Id = c.Id,
                                DeadLineDate = c.DeadLineDate,
                                Description = c.Description,
                                EndDate = c.EndDate,
                                Title = c.Title,
                                DateCreated = c.DateCreated
                            })
                };
            }
        }

        //public void CreateMappings(IConfiguration configuration)
        //{
        //    configuration.CreateMap<User, ProfileViewModel>()
        //        .ForMember(vm => vm.ContestsParticipatedInCount, opt => opt.MapFrom(u => u.ContestsParticipated.Count))
        //        .ForMember(vm => vm.ContestsWonCount, opt => opt.MapFrom(u => u.ContestsWon.Count))
        //        .ForMember(vm => vm.ActiveContests,
        //            opt => opt.MapFrom(u => u.ContestsParticipated.Where(c => c.Status == ContestStatus.Open)))
        //        .ForMember(vm => vm.PassedContests,
        //            opt => opt.MapFrom(u => u.ContestsParticipated.Where(c => c.Status == ContestStatus.Closed)))
        //        .ForMember(vm => vm.OwnedContensts,
        //        opt => opt.MapFrom(u => u.ContestsOwned));
        //}
    }
}
