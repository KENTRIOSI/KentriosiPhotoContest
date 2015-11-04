namespace KentriosiPhotosContests.Services
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using KentriosiPhotoContest.Data;
    using KentriosiPhotoContest.Models;
    using Common;
    using System.IO;

    public class ImagesService : BaseService, IImagesService
    {
        IDropboxRepository dropboxRepository;

        public ImagesService(IKentriosiPhotoData kentriosiPhotoData, IDropboxRepository dropboxRepository)
            : base(kentriosiPhotoData)
        {
            this.dropboxRepository = dropboxRepository;
        }

        public Image ById(int id)
        {
            Image contestImage = this.Data.Images.Find(id);
            if (null != contestImage)
            {
                string imagePath = Constants.DROPBOX_BASE_PATH + contestImage.Id.ToString() + "." + contestImage.Extension;

                contestImage = this.dropboxRepository.Download(imagePath);

            }

            return contestImage;
        }
    }
}
