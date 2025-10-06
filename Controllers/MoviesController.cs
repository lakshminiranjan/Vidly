using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random


        //Type      -       Helper Method                           Type      -       Helper Method
        //ViewResult    -   View()                     RedirectToRouteResult    -   RedirectToAction()      EmptyResult  - no helper method.
        //PartialViewResult-PartialView()              JsonResult    -   Json() 
        //ContentResult    -   Content()               FileResult    -   File()
        //RedirectResult    -   Redirect()             HttpNotFoundResult    -   HttpNotFound() 
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            //ViewData["Movie"] = movie;->Dont use ViewData or ViewBag
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new Vidly.ViewModels.RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);//-MostImportant
            //return new ViewResult();
            //return Content("Hello World!");
            //return HttpNotFound();-MostImportant
            //return new EmptyResult();-MostImportant
            //return RedirectToAction("Index", "Home",new { page = 1, sortBy = "name" });
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        //movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if(!pageIndex.HasValue)
                pageIndex = 1;

            if(String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

    }
}