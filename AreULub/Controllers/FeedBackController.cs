using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AreULub.Models;

namespace AreULub.Controllers
{
    public class FeedBackController : Controller
    {
      

        public IActionResult FeedBackIndex()
        {
            return View();
        }
        public IActionResult LeaveComment()
        {
            ViewBag.comment = null;
            return View();
        }

        [HttpPost]
        public IActionResult FeedBackIndex(QuickReview model)
        {

            return View(model);

        }
        [HttpPost]
        public IActionResult LeaveComment(CommentsModel model)
        {
            if (ModelState.IsValid)
            {

                ViewBag.comment = model;
                return View(model);
            }
            else
            {
                model = new CommentsModel();
                ViewBag.comment = model;
                return View(model);
            }
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new  User { UserLast = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
