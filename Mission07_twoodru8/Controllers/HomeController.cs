using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission07_twoodru8.Models;
using System.Diagnostics;
using System.Linq;

namespace Mission06_twoodru8.Controllers
{
    public class HomeController : Controller
    {
        
        //instanciating the dbcontext and having a get and set
        private MovieFormDBContext _dbContext { get; set; }

        public HomeController(MovieFormDBContext databaseContext)
        {
            _dbContext = databaseContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }
        //the original get request for the movie form
        [HttpGet]
        public IActionResult MovieForm()
        {
            //if it is an add a movie, then this will be false so that the hidden movieid form field is not put in the form
            ViewBag.IsEdit = false;
            ViewBag.Categories = _dbContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(MovieFormModel m)
        {
            //if the model is validated, then we will add it and save the changes and send them to the confirmation screen
            if (ModelState.IsValid)
            {
                _dbContext.Add(m);
                _dbContext.SaveChanges();
                return View("Confirmation", m);
            }//else, we will throw them back to the view and display the error.
            else
            {
                ViewBag.IsEdit = false;
                ViewBag.Categories = _dbContext.Categories.ToList();
                return View();
            }

        }
        public IActionResult MovieList()
        {
            var movies = _dbContext.Responses //include is joining
                .Include(x => x.Categories)
                .OrderBy(x => x.Title)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.IsEdit = true;
            ViewBag.Categories = _dbContext.Categories.ToList();

            var movie = _dbContext.Responses
                .Single(x => x.MovieId == id);

            return View("MovieForm", movie);
        }

        [HttpPost]
        public IActionResult Edit(int id, MovieFormModel m)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Update(m);
                _dbContext.SaveChanges();
                //restarts an action that we already have
                return RedirectToAction("MovieList");
            }//else, we will throw them back to the view and display the error.
            else
            {
                //if it is an edit, then this will be true so that the hidden movieid form field is put in the form
                ViewBag.IsEdit = true;
                ViewBag.Categories = _dbContext.Categories.ToList();

                var movie = _dbContext.Responses
                    .Single(x => x.MovieId == id);

                return View("MovieForm", movie);
            }
            
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _dbContext.Responses.Single(x => x.MovieId == id);

            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(MovieFormModel m)
        {
            _dbContext.Responses.Remove(m);
            _dbContext.SaveChanges();

            return RedirectToAction("MovieList");
        }


    }
}