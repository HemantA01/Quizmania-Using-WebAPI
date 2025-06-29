using Microsoft.AspNetCore.Mvc;
using Quizmania1.Model.ViewModel;
using QuizMania1.UI.Interface;

namespace QuizMania1.UI.Controllers
{
    public class StateMasterController : Controller
    {
        private readonly IStateMaster _states;
        public StateMasterController(IStateMaster states)
        {
            _states = states;
        }
        /// <summary>
        /// Get request to fetch the list of states from API
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetStatesList()
        {
            try
            {
                var getDetails = await _states.GetStatesListAsync();
                return View(getDetails);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Insert state operation
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> InsertState(StateMasterVM model)
        {
            try
            {
                var getdetails = await _states.AddStates(model);
                return Json(getdetails);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
