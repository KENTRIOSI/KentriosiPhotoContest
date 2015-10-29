namespace KentriosiPhotoContest.MVC.Models
{
    using KentriosiPhotoContest.Models;
    using Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;

    public class ContestViewModel : IMapFrom<Contest>, IHaveCustomMappings
    {
        public int? ContestImageId { get; set; }

        public string ContestImageUrl { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Contest, ContestViewModel>()
                .ForMember(cvm => cvm.ContestImageUrl, opt => opt.MapFrom(c => c.ContestImage.Path))
                .ReverseMap();
        }
    }
}
