﻿using Microsoft.AspNetCore.Mvc;

namespace GymManagementPL.Controllers
{
    public class MemberController : Controller
    {
        public ActionResult Index(int id)
        {
            return View();
        }
        public ActionResult GetMemers()
        {
            return View();
        }
        public ActionResult CreateMember()
        {
            return View();
        }
    }
}
