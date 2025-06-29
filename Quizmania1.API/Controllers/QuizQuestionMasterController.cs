using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizmania1.Model.ViewModel;
using Quizmania1.Service.Interface;
using System.Net;

namespace Quizmania1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizQuestionMasterController : ControllerBase
    {
        private readonly IQuizQuestionMaster _iquizquesmaster;
        public QuizQuestionMasterController(IQuizQuestionMaster iquizquesmaster) 
        { 
            _iquizquesmaster = iquizquesmaster;
        }
        [HttpPost, Route("insert-questions")]
        public async Task<IActionResult> InsertQuestionAnswer(QuizQuestionMasterVM model)
        {
            try
            {
                var result = await _iquizquesmaster.AddQuestion(model);
                if (result == 1)
                {
                    return Ok((int)HttpStatusCode.OK + " - Question Inserted Successfully!");
                }
                else
                {
                    return BadRequest((int)HttpStatusCode.BadRequest + " - Error occured. Please try again!");
                }
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
