namespace KentriosiPhotoContest.MVC.Controllers
{
    using System.Web.Mvc;
    using KentriosiPhotosContests.Services.Contracts;

    public abstract class BaseController : Controller
    {
        IBaseService baseService;

        public BaseController(IBaseService baseService)
        {
            this.baseService = baseService;
        }
    }
}
