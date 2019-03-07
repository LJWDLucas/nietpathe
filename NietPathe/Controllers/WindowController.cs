using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NietPathe.Models.Movies;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NietPathe.Controllers
{
    [Route("[controller]")]
    public class WindowController : Controller
    {
        // GET: /<controller>/
        private readonly IMovieRepository _movieRepository;

        public WindowController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_movieRepository.GetActiveMoviesWithLimit(25).Result);
        }
    }
}
