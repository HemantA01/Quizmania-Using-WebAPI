using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizmania1.Model.ViewModel;
using Quizmania1.Service.Interface;

namespace Quizmania1.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SPStateMasterController : ControllerBase
    {
        private readonly IDapperStateMaster _state;
        public SPStateMasterController(IDapperStateMaster state)
        {
            _state= state;
        }
        [HttpGet, Route("get-countries-state-sp")]
        public async Task<IActionResult> GetAllStates() 
        {
            try
            {
                CountryStateVM model = new();
                model.countryStateMasterList = await _state.GetAllStatesList();
                model.countryMasterList = await _state.GetActiveCountries();
                return Ok(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet, Route("get-states-list")]
        public async Task<IActionResult> GetStatesList()
        {
            try
            {
                CountryStateMasterVM model = new();
                var getdetail = await _state.GetAllStatesList();
                return Ok(getdetail);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
