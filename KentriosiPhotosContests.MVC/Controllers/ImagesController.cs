namespace KentriosiPhotoContest.MVC.Controllers
{
    using AutoMapper;

    using KentriosiPhotosContests.Services.Contracts;
    using KentriosiPhotoContest.Models;
    using Models;

    public class ImagesController : BaseController
    {
        private IImagesService imagesService;

        public ImagesController(IBaseService baseService, IImagesService imagesService)
            : base(baseService)
        {
            this.imagesService = imagesService;
        }

        public ImageViewModel ById(int id)
        {
            Image contestImage = this.imagesService.ById(id);
            if (null != contestImage)
            {
                ImageViewModel imageViewModel = Mapper.Map<ImageViewModel>(contestImage);

                return imageViewModel;
            }

            return null;
        }
    }
}
