namespace KentriosiPhotoContest.MVC.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using KentriosiPhotosContests.Services.Contracts;
    using KentriosiPhotoContest.Models;
    using Models;

    public class HomeController : BaseController
    {
        private IContestService contestService;

        public HomeController(IBaseService baseService, IContestService contestService)
            : base(baseService)
        {
            this.contestService = contestService;
        }

        public ActionResult Index(int? id)
        {
            int? page = id ?? 1;
            page = page < 1 ? 1 : page;

            IEnumerable<ContestViewModel> pagedContestsViewModel;

            if (this.Request.IsAjaxRequest())
            {
                pagedContestsViewModel = this.contestService
                    .GetPagedPublicContests(Constants.CONTESTS_PAGE_SIZE, (int)page)
                    .AsQueryable<Contest>()
                    .Project()
                    .To<ContestViewModel>();

                return PartialView("_Contests", pagedContestsViewModel);
            }

            pagedContestsViewModel = this.contestService
                    .GetPagedPublicContests(Constants.CONTESTS_PAGE_SIZE, 1)
                    .AsQueryable<Contest>()
                    .Project()
                    .To<ContestViewModel>();

            return View("Index", pagedContestsViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}