using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizmania1.Model.ViewModel;
using Quizmania1.Service.Interface;

namespace Quizmania1.API.Controllers
{
    [Authorize]
    
    //[Route("api/[controller]")]
    [ApiController]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiVersion(1)]
    [ApiVersion(2)]
    public class CountryMasterController : ControllerBase
    {
        private readonly ICountryMaster _countryMaster;
        public CountryMasterController(ICountryMaster countryMaster) 
        { 
            _countryMaster = countryMaster;
        }

        #region Get All Countries
        [HttpGet]
        [MapToApiVersion(1)]
        [Route("GetAllCountries")]
        public async Task<IActionResult> GetAllCountries() 
        {
            try
            {
                var lstCountries = await _countryMaster.GetCountries();
                return Ok(lstCountries);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Insert Country
        [HttpPost]
        //[MapToApiVersion(2)]
        [MapToApiVersion(1)]
        [Route("add-country")]
        public async Task<IActionResult> InsertCountries(CountryMasterVM model)
        {
            try
            {
                var id = await _countryMaster.AddCountry(model);
                return Ok(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Update Country Details
        [HttpPut]
        [MapToApiVersion(1)]
        [Route("update-country")]
        public async Task<IActionResult> UpdateCountries(int? Id, CountryMasterVM model)
        {
            try
            {
                var id = await _countryMaster.UpdateCountry(Id, model);
                return Ok(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Update Country Status
        [HttpPatch]
        [MapToApiVersion(2)]
        [Route("update-status")]
        public async Task<IActionResult> UpdateCountryStatus(int? Id, CountryMasterVM model)
        {
            try
            {
                var id = await _countryMaster.UpdateCountryStatus(Id, model);
                return Ok(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Delete Countries
        [HttpDelete]
        [MapToApiVersion(2)]
        [Route("remove-country")]
        public async Task<IActionResult> DeleteCountry(int? Id)
        {
            try
            {
                var id = await _countryMaster.DeleteCountry(Id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
