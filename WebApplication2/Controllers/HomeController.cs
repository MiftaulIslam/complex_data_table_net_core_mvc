using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication2.Data;
using WebApplication2.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context,ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Test test)
        {
            if (test.RegionalOffice != null)
            {
                if (test.DscCtgAarray == null && test.DscCtgBarray == null && test.UscCtgBarray == null)
                {
                    test.DscCtgAarray = new List<string>();
                    test.DscCtgBarray = new List<string>();
                    test.UscCtgBarray = new List<string>();
                }
                string[] DscCtgA = test.DscCtgA.Split(' ');
                string[] DscCtgB = test.DscCtgB.Split(' ');
                string[] UscCtgB = test.UscCtgB.Split(' ');

                foreach (var item in DscCtgA)
                {
                    test.DscCtgAarray.Add(item);
                }
                foreach (var item in DscCtgB)
                {
                    test.DscCtgBarray.Add(item);
                }
                foreach (var item in UscCtgB)
                {
                    test.UscCtgBarray.Add(item);
                }

                _context.tests.Add(test);
                _context.SaveChanges();
                return View();
            }
            return View();
        }



        public IActionResult UpdateItem(int id)
        {
            var item = _context.tests.Find(id);

            return View(item);
        }

        [HttpPost]
        public IActionResult ConfirmUpdateItem(Test test)
        {
            var item = _context.tests.Find(test.Id);

            if (item != null )
            {
                // Clear existing lists
                item.DscCtgAarray.Clear();
                item.DscCtgBarray.Clear();
                item.UscCtgBarray.Clear();

                // Split and store new data into arrays
                
                    string[] DscCtgA = test.DscCtgA.Split(' ');
                    foreach (var ctg in DscCtgA)
                    {
                        item.DscCtgAarray.Add(ctg);
                    }
                

                
                    string[] DscCtgB = test.DscCtgB.Split(' ');
                    foreach (var ctg in DscCtgB)
                    {
                        item.DscCtgBarray.Add(ctg);
                    }
                

                
                    string[] UscCtgB = test.UscCtgB.Split(' ');
                    foreach (var ctg in UscCtgB)
                    {
                        item.UscCtgBarray.Add(ctg);
                    }
                item.DscCtgA = test.DscCtgA;
                item.DscCtgB = test.DscCtgB;
                item.UscCtgB = test.UscCtgB;
                _context.tests.Update(item);
                // Save changes to the database
                _context.SaveChanges();
            }

            // Redirect to some action after updating
            return Json("Success");
        }

        public IActionResult View()
        {
            var items = _context.tests.ToList();
            return View(items);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var item = _context.tests.Find(id);
            _context.tests.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("View");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
