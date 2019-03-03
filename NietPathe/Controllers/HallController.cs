using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NietPathe.Models.Halls;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NietPathe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallController : Controller
    {
        private readonly IHallRepository _hallRepository;

        public HallController(IHallRepository hallRepository)
        {
            _hallRepository = hallRepository;
        }

        [HttpGet("{id}")]
        public JsonResult GetHallById(string id)
        {
            return Json(_hallRepository.GetHallbyId(id).Result);
        }

        public JsonResult GetAllHalls()
        {
            return Json(_hallRepository.GetAllHalls().Result);
        }
    }
}
