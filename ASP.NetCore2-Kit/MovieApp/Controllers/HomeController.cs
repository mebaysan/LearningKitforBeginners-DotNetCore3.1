using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Data;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int? id)
        {
          var movies = MovieRepository.Movies;
          if (id!=null)
          {
              movies = movies.Where(i => i.CategoryId == id).ToList();
          }
          // ProductRepository.Movies
          // CategoryRepository.Categories
          // MovieCategoryModel model = new MovieCategoryModel();
          // model.Categories = CategoryRepository.Categories;
          // model.Movies = MovieRepository.Movies;
          return View(movies);
        }
        public IActionResult Contact()
        {
          
          return View();
        }
        public IActionResult Details(int id){
          // MovieCategoryModel model = new MovieCategoryModel();
          // model.Categories = CategoryRepository.Categories;
          // model.Movie = MovieRepository.GetById(id);

          return View(MovieRepository.GetById(id));
        }
    }
}