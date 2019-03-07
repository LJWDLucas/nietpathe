using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NietPathe.Models;
using NietPathe.Models.Surveys;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NietPathe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : Controller
    {
        private readonly ISurveyRepository _surveyRepository;

        public SurveyController(ISurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        [HttpGet]
        public JsonResult GetSurveys()
        {
            return Json(_surveyRepository.GetSurveys().Result);
        }

        [HttpGet("{id}")]
        public JsonResult GetSurveys(string id)
        {
            return Json(_surveyRepository.GetSurveyById(id).Result);
        }

        [HttpPost]
        public JsonResult PostSurvey(Survey survey)
        {
            _surveyRepository.CreateSurvey(survey);
            return new JsonResult
            (new { Data = "Success" });
        }

        [HttpDelete("{id}")]
        public JsonResult DeleteSurvey(string id)
        {
            _surveyRepository.DeleteSurvey(id);
            return new JsonResult
            (new { Data = "The deletion request has been received." });
        }

        public JsonResult UpdateSurvey(Survey survey)
        {
            return new JsonResult
                (new { Success = _surveyRepository.UpdateSurvey(survey) });
        }
    }
}
