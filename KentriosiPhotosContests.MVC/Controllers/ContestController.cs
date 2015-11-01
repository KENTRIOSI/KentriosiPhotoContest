using KentriosiPhotoContest.Models;
using KentriosiPhotosContests.Services.Contracts;
using System.Web.Mvc;

namespace KentriosiPhotoContest.MVC.Controllers
{
    public class ContestController : BaseController
    {
        private IContestService contestService;


        public ContestController(IBaseService baseService, IContestService contestService)
            : base(baseService)
        {
            this.contestService = contestService;
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult View(int id)
        {
            Contest contest = this.contestService.returnContest(id);
            var images = contest.Images;
            ViewBag.VotersCount = contest.InvitedVoters.Count;
            ViewBag.ContestersCount = contest.AllowedParticipants.Count;
            ViewBag.Count = images.Count;

            var model = TempData["contest"] = contest;
            return View(model);
        }

    }
}