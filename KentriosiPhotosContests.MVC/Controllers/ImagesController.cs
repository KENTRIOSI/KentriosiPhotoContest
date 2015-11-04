namespace KentriosiPhotoContest.MVC.Controllers
{
    using AutoMapper;

    using KentriosiPhotosContests.Services.Contracts;
    using KentriosiPhotoContest.Models;
    using Models;
    using System.Web.Mvc;
    using KentriosiPhotosContests.Common;

    public class ImagesController : BaseController
    {
        private IImagesService imagesService;
        private IMimeTypeManager mimeTypeManager;

        public ImagesController(IBaseService baseService, IImagesService imagesService, IMimeTypeManager mimeTypeManager)
            : base(baseService)
        {
            this.imagesService = imagesService;
            this.mimeTypeManager = mimeTypeManager;
        }

        public ActionResult ById(int id)
        {
            Image contestImage = this.imagesService.ById(id);
            if (null != contestImage)
            {
                contestImage.MimeType = this.mimeTypeManager.GetMimeType(contestImage.Extension);
                ImageViewModel imageViewModel = Mapper.Map<ImageViewModel>(contestImage);

                return File(imageViewModel.Content, imageViewModel.MimeType);
            }

            return new EmptyResult();
        }
    }
}
