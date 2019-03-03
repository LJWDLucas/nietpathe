using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Attributes;
using NietPathe.Models;
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

        [HttpGet("hall/{id}")]
        public JsonResult GetPerformancesByHallId(string id)
        {
            var data = _performanceRepository.GetPerformancesByHallId(id).Result;
            return Json(data);
        }

        [HttpPost("date")]
        public JsonResult GetPerformancesByDate([FromBody] PerformanceDate date)
        {
            var data = _performanceRepository.GetPerformancesByDate(date.Date).Result;
            return Json(data);
        }

        [HttpPost("create")]
        public JsonResult CreatePerformance([FromBody] Performance performance)
        {
            _performanceRepository.CreatePerformance(performance);
            return new JsonResult
            (new { Data = "Success" });
        }

        [HttpPost("beforeDate")]
        public JsonResult GetPerformancesBeforeDate([FromBody] PerformanceDate date)
        {
            var data = _performanceRepository.GetPerformancesBeforeDate(date.Date).Result;
            return Json(data);
        }

        [HttpPost("afterDate")]
        public JsonResult GetPerformancesAfterDate([FromBody] PerformanceDate date)
        {
            var data = _performanceRepository.GetPerformancesAfterDate(date.Date).Result;
            return Json(data);
        }

        [HttpPost("{id}/seat")]
        public JsonResult BookPerformanceSeat([FromBody] PerformanceChair chair, string id)
        {
            _performanceRepository.BookPerformanceSeat(chair, id);
            return new JsonResult
            (new { Data = "Success" });
        }

        public class PerformanceDate
        {

            [BsonElement("date")]
            private DateTime date;

            [BsonIgnore]
            public DateTime Date
            {
                get
                {
                    return date;
                }
                set
                {
                    date = Convert.ToDateTime(value);
                }
            }
        }
    }
}