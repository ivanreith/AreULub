using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AreULub.Models;
using Microsoft.EntityFrameworkCore;

namespace AreULub.Controllers
{
    public class HomeController : Controller
    {
      /*  private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/
        private ServiceContext context { get; set; }
        public HomeController(ServiceContext ctx)
        {
            context = ctx;
        }
        /* public IActionResult ServicesIndex()
         {
             var services = context.Services.Include(m => m.User)
                 .OrderBy(m => m.ServiceName).ToList();
             return View(services);
         }
      
        public async Task<IActionResult> ServicesIndex(string searchString)
        {
            /* Start of plain version
            List<ServiceModel> service = Repository.service.ToList();

            return View(service);
           end of plain version 
            var servicesFiltered = from s in context.Services select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                servicesFiltered = servicesFiltered.Where(s => s.ServiceName.Contains(searchString));
                return View(await servicesFiltered.ToListAsync());
            }
            return View(await servicesFiltered.ToListAsync());
        }
*/

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult About()
        {
            return View();
        }
      
        public IActionResult FeedBackIndex()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new User { UserLast = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
