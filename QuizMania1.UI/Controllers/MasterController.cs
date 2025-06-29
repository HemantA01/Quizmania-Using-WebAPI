using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Quizmania1.Model.ViewModel;
using QuizMania1.UI.Interface;

namespace QuizMania1.UI.Controllers
{
    public class MasterController : Controller
    {
        private readonly ICountryMaster _iCountry;
        public MasterController(ICountryMaster iCountry)
        {
            _iCountry = iCountry;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            try
            {
                
                var getdetails = await _iCountry.GetAllCountries();
                return View(getdetails);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        [HttpPost]
        public async Task<JsonResult> InsertCountry(CountryMasterVM model)
        {
            try
            {
                var getdetails = await _iCountry.InsertCountry(model);
                return Json(getdetails);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        [HttpPut]
        public async Task<JsonResult> UpdateCountry(int? Id, CountryMasterVM model)
        {
            try
            {
                var getdetails = await _iCountry.UpdateCountry(Id, model);
                return Json(getdetails);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        [HttpPatch]
        public async Task<JsonResult> UpdateCountryStatus(int? Id, CountryMasterVM model)
        {
            try
            {
                var getdetails = await _iCountry.UpdateCountryStatus(Id, model);
                return Json(getdetails);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpDelete]
        public async Task<JsonResult> DeleteCountry(int? Id)
        {
            try
            {
                var getdetails = await _iCountry.DeleteCountry(Id);
                return Json(getdetails);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
