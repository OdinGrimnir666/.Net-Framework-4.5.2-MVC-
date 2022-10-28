using Fram_4._5._2.Models;
using Fram_4._5._2.Repository;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Fram_4._5._2.Controllers
{
    public class HomeController : Controller
    {
        IUserRepository _repository;
        public HomeController(IUserRepository repository)
        {
            _repository = repository;
        }



        [Authorize]
        [HttpGet]
        public async Task<PartialViewResult> ConferenceGrid()
        {
            ViewBag.IdentityId = User.Identity.GetUserName();
            //var context = new ApplicationDbContext();
            return PartialView("ConferenceGrid", await _repository.GetUserAsync().ConfigureAwait(false));
        }

        [Authorize]
        [HttpGet]
        public ViewResult Conference()
        {
            ViewBag.Message = "Who came to the conference";

            return View();
        }


        public ActionResult Index()
        {
            ViewBag.Message = "Who came to the conference";

            return RedirectToAction("Conference", "Home");
        }

    }
}