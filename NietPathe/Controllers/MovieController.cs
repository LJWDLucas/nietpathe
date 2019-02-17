using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NietPathe.Models.Movies;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NietPathe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        //[HttpGet("{title}")]
        //public JsonResult GetByTitle(string title)
        //{
        //    var data = _movieRepository.GetMovieByTitle(title).Result;
        //    return Json(data);
        //}

        [HttpGet()]
        public JsonResult GetMovies()
        {
            return Json(_movieRepository.GetMovies().Result);
        }

        [HttpGet("active/{limit}")]
        public JsonResult GetActiveMoviesWithLimit(int limit)
        {
            return Json(_movieRepository.GetActiveMoviesWithLimit(limit).Result);
        }

        //[HttpGet]
        //public IActionResult GetProducts()
        //{
        //    return View(_movieRepository.GetMovies().Result);
        //}

        //         [HttpPost]
        //         public IActionResult CreateProduct([FromBody] Product product)
        //         {
        //             _productRepository.CreateProduct(product);
        //             return new ObjectResult("Done");
        //         }
        //     }
        // }

    }
}