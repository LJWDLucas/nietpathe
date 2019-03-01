using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NietPathe.Models;
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

        [HttpGet("{id}")]
        public JsonResult GetMovieById(string id)
        {
            return Json(_movieRepository.GetMovieById(id).Result);
        }

        [HttpGet("pagination/{skip}")]
        public JsonResult GetPaginatedMovies(int skip)
        {
            return Json(_movieRepository.GetPaginatedMovies(skip).Result);
        }

        [HttpGet("total")] 
        public JsonResult TotalMovies()
        {
            return new JsonResult
                (new { Total = _movieRepository.TotalMovies().Result });
        }

        [HttpPut("update")]
        public JsonResult UpdateMovie(Movie movie)
        {
            return new JsonResult
                (new { Success = _movieRepository.UpdateMovie(movie) });
        }

        [HttpPost("new")]
        public JsonResult CreateMovie(Movie movie)
        {
            return new JsonResult
                (new { Success = _movieRepository.CreateMovie(movie) });

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