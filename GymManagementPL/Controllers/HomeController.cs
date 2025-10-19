using GymManagementBLL.Services.Interfaces;
using GymManagementDAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementPL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnalyticService _analyticService;

        public HomeController(IAnalyticService analyticService)
        {
            _analyticService = analyticService;
        }

        public ActionResult Index()
        {
            var Data = _analyticService.GetAnalyticViewModel();
            return View(Data);
        }

        #region Action Return Types
        public ActionResult Trainers()
        {
            var Trainers = new List<Trainer>()
            {
                new Trainer() { Name = "Ahmed", Phone = "0111122254"},
                new Trainer() { Name = "Aya", Phone = "01254866"},
            };
            return Json(Trainers);
        }
        public ActionResult Redirect()
        {
            return Redirect("https://www.netflix.com/eg-en");
        }
        public ActionResult Content()
        {
            return Content("<h1>Welcome to Gym Management System</h1>", "text/html");
        }

        public ActionResult DownloadFile()
        {
            var FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "css", "site.css");
            var FileBytes = System.IO.File.ReadAllBytes(FilePath);
            return File(FileBytes, "text/css", "DownloadSite.css");
        }

        public ActionResult EmptyAction()
        {
            return new EmptyResult();
        } 
        #endregion
    } 
}
