using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NietPathe.Models;
using NietPathe.Models.Movies;
using NietPathe.Models.Performances;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NietPathe.Controllers
{
    [Route("[controller]")]
    public class WindowController : Controller
    {
        // GET: /<controller>/
        private readonly IMovieRepository _movieRepository;
        private readonly IPerformanceRepository _performanceRepository;

        public WindowController(IMovieRepository movieRepository, IPerformanceRepository performanceRepository)
        {
            _movieRepository = movieRepository;
            _performanceRepository = performanceRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_movieRepository.GetActiveMoviesWithLimit(25).Result);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie([FromRoute]string id)
        {
            ViewModelMoviePerformance model = new ViewModelMoviePerformance
            {
                movie = _movieRepository.GetMovieById(id).Result,
                performances = _performanceRepository.GetPerformancesByMovieId(id).Result
            };
            return View(model);
        }
    }

}
