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
    public class SPCountryMasterController : ControllerBase
    {
        private readonly IDapperCountryMaster _iCountry;
        public SPCountryMasterController(IDapperCountryMaster iCountry)
        {
            _iCountry = iCountry;
        }
        [HttpGet, Route("get-allcountries-sp")]
        public async Task<IActionResult> GetAllCountries() 
        {
            try
            {
                var getallcountries = await _iCountry.GetCountryMasterAsync();
                return Ok(getallcountries);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost, Route("insert-countries-sp")]
        public async Task<IActionResult> InsertCountry(CountryMasterVM model)
        {
            try
            {
                var result = await _iCountry.AddCountryAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut, Route("update-countrydetails-sp")]
        public async Task<IActionResult> UpdateCountryDetails(CountryMasterVM model)
        {
            try
            {
                var result = await _iCountry.UpdateCountryDetailsAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPatch, Route("update-countrystatus-sp")]
        public async Task<IActionResult> UpdateCountryStatus(int? countryId, bool status)
        {
            try
            {
                var result = await _iCountry.UpdateCountryStatusAsync(countryId, status);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpDelete, Route("delete-country-sp")]
        public async Task<IActionResult> DeleteCountry(int? countryId)
        {
            try
            {
                var result = await _iCountry.DeleteCountryAsync(countryId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet, Route("get-countrybyid-sp")]
        public async Task<IActionResult> GetCountryById(int? countryId)
        {
            try
            {
                var result = await _iCountry.GetCountryMasterByIdAsync(countryId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet, Route("fetch-countrybyid-sp")]
        public async Task<IActionResult> FetchCountryById(CountryMasterVM model)
        {
            try
            {
                var result = await _iCountry.FetchCountryMasterByIdAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
