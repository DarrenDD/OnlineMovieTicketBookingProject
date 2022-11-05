using FileUploadControl;
using Microsoft.AspNetCore.Mvc;
using OnlineMovieTicketBookingProject.Data;
using OnlineMovieTicketBookingProject.Models;
using OnlineMovieTicketBookingProject.Views.ViewModels;

namespace OnlineMovieTicketBookingProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        private UploadInterface _upload;
        public AdminController(ApplicationDbContext context, UploadInterface upload)
        {
            _context = context;
            _upload = upload;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IList<IFormFile> files, MovieDetailViewModel vmodel, MovieDetails movie)
        {
            movie.Movie_Name = vmodel.Name;
            movie.Movie_Description = vmodel.Descritpion;
            movie.DateAndTime = vmodel.DateOfMovie;
            foreach (var item in files)
            {
                movie.MoviePicture = "~/uploads/" + item.FileName.Trim();
            }
            _upload.uploadFileMultiple(files);
            _context.MovieDetails.Add(movie);
            _context.SaveChanges();
            TempData["Success"] = "Movie has been Saved!";
            return RedirectToAction("Create", "Admin");
            
        }
    }
}
