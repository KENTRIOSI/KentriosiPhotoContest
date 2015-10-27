namespace KentriosiPhotoContest.MVC.Models
{
    using KentriosiPhotoContest.Models;
    using Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class ImageViewModel : IMapFrom<Image>
    {
        public int Id { get; set; }

        public string Url { get; set; }
    }
}
