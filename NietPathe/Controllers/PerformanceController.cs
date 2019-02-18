using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NietPathe.Models.Performances;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NietPathe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceController : Controller
    {
        private readonly IPerformanceRepository _performanceRepository;

        public PerformanceController(IPerformanceRepository performanceRepository)
        {
            _performanceRepository = performanceRepository;
        }

        // Performances by performance id.
        [HttpGet("{id}")]
        public JsonResult GetById(string id)
        {
            var data = _performanceRepository.GetPerformance(id).Result;
            return Json(data);
        }

        // Performances by movie id.
        [HttpGet("movie/{id}")]
        public JsonResult GetPerformancesByMovieId(string id)
        {
            var data = _performanceRepository.GetPerformancesByMovieId(id).Result;
            return Json(data);
        }

        [HttpGet("fromDate/{date}")]
        public JsonResult GetPerformanceIdsByDate(string date)
        {
            var data = _performanceRepository.GetPerformancesByDate(date).Result;
            return Json(data);
        }

        [HttpPost("{id}/seat")]
        public JsonResult BookPerformanceSeat([FromBody] PerformanceChair chair, string id)
        {
            _performanceRepository.BookPerformanceSeat(chair, id);
            return new JsonResult
            (new { Data = "Success" });
        }
    }
}