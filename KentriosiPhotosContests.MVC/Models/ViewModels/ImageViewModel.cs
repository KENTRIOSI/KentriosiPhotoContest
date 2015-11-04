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

        public byte[] Content { get; set; }

        public string MimeType { get; set; }

        public string Extension { get; set; }

        public string Path { get; set; }
    }
}
