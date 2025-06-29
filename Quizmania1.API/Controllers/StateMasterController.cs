using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizmania1.Model.ViewModel;
using Quizmania1.Service.Interface;

namespace Quizmania1.API.Controllers
{
    [Authorize]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    [ApiVersion(3)]
    [ApiVersion(4)]
    public class StateMasterController : ControllerBase
    {
        private readonly IStateMaster _state;
        public StateMasterController(IStateMaster state)
        {
            _state = state;
        }

        #region Get State Country List
        [HttpGet, Route("get-state-countrylist")]
        //[MapToApiVersion(3.1)]
        [MapToApiVersion(3)]
        public async Task<IActionResult> GetCountryList()
        {
            try
            {
                CountryStateVM model = new CountryStateVM();
                model.countryMasterList = await _state.GetCountryList();
                model.countryStateMasterList = await _state.GetCountryStateList();
                return Ok(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Add State
        [HttpPost, Route("insert-state")]
        //[MapToApiVersion(3.2)]
        [MapToApiVersion(4)]
        public async Task<IActionResult> InsertState(StateMasterVM model)
        {
            try
            {
                var getDetails = await _state.AddState(model);
                return Ok(getDetails);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Get State Details By Id
        [HttpGet, Route("get-state-byid")]
        //[MapToApiVersion(3.1)]
        [MapToApiVersion(3)]
        public async Task<IActionResult> GetStateDetailById(int? Id)
        {
            try
            {
                var getDetails = await _state.GetStateById(Id);
                return Ok(getDetails);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Update state
        [HttpPut, Route("update-state")]
        //[MapToApiVersion(3.2)]
        [MapToApiVersion(4)]
        public async Task<IActionResult> UpdateStateDetails(int? Id, StateMasterVM model)
        {
            try
            {
                var getResult = await _state.UpdateState(Id, model);
                return Ok(getResult);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Update State Status
        [HttpPatch, Route("update-status")]
        //[MapToApiVersion(3.2)]
        [MapToApiVersion(4)]
        public async Task<IActionResult> UpdateStateStatus(StateMasterVM model)
        {
            try
            {
                var getResult = await _state.UpdateStateStatus(model);
                return Ok(getResult);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Get State List
        [HttpGet, Route("get-state-list")]
        //[ApiVersion(3.1)]
        [MapToApiVersion(3)]
        public async Task<IActionResult> GetStatesList()
        {
            try
            {
                var getdetails = await _state.GetCountryStateList();
                return Ok(getdetails);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

    }
}
