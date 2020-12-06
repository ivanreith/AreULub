using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AreULub.Models;
using AreULub.Repositories;


namespace AreULub.Controllers
{
    public class ServicesController : Controller
    {
        IServices Repository;
        ServiceContext context { get; set; }
        public ServicesController(IServices s, ServiceContext c)  // repo is s and context is c +++++++++++++
        {       
            context = c;
            Repository = s;
        }
        [HttpGet]
        public IActionResult ServicesIndex()
        {

            List<ServiceModel> service = Repository.service.ToList();

            return View(service);
        }
        [HttpGet]
        public IActionResult Add(ServiceModel service)
        {
            ViewBag.Action = "Add";
            ViewBag.Posters = context.Users.OrderBy(g => g.UserId).ToList();
            return View("Edit", service);// new service creation
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Posters = context.Users.OrderBy(g => g.UserLast).ToList();
            var service = Repository.GetServiceById(id);

            // var service = context.Services.Find(id); not needed once it goes to the repo
            return View(service);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {

            var story = context.Services.Find(id);
            return View(story);
        }


        [HttpPost]
        public IActionResult ServicesIndex(ServiceModel model)
        {
            if (ModelState.IsValid)
            {

                ViewBag.service = model;
                return View(model);
            }
            else
            {
                model = new ServiceModel();
                ViewBag.service = model;
                return View(model);
            }
        }




         /* public IActionResult ServicesIndex() // keep that one once I get data???? 
          {
              return View();
          }*/
       
        
        [HttpPost]
        public IActionResult Edit(ServiceModel service)
        {
            if (ModelState.IsValid)
            {
                if (service.ServiceID == 0)
                {
                    Repository.AddService(service);
                }          
                else
                    Repository.UpdateService(service);

                return RedirectToAction("ServicesIndex", "Services");
            }
            else
            {
                ViewBag.Action = (service.ServiceID == 0) ? "Add" : "Edit";
                ViewBag.Posters = Repository.service.OrderBy(service => service.User.UserLast).ToList();
                return View(service);
            }
        }
      

        [HttpPost]
        public IActionResult Delete(ServiceModel service)
        {
            Repository.DeleteService(service);
            return RedirectToAction("ServicesIndex", "Services");
        }
      
      
   

        // START TAX Page stuff ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        [HttpGet]
        public IActionResult Tax()
        {
            ViewBag.FutureValue = "";
            return View();
        }

        [HttpPost]
        public IActionResult Tax(TaxModel tm)
        {
            if (ModelState.IsValid)
            {
                ViewBag.TotalWithTax = tm.Calculate();
            }
            else
            {
                ViewBag.TotalWithTax = "";
            }

            return View();
        }


    }
}//.ToString("c2")
