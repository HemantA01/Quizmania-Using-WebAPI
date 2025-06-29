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
    public class UserRegistrationController : ControllerBase
    {
        private readonly IUserRegistration _iuserRegistration;
        public UserRegistrationController(IUserRegistration iuserRegistration)
        {
            _iuserRegistration= iuserRegistration;
        }
        [HttpGet, Route("getlist-countries-state")]
        public async Task<IActionResult> GetCountriesStateList() 
        {
            try
            {
                UserRegistrationControlsVM model = new UserRegistrationControlsVM();
                model.countryMasterList = await _iuserRegistration.GetCountries();
                model.stateMasterList = await _iuserRegistration.GetStates();
                model.empTypeMasterList = await _iuserRegistration.GetEmpTypeMaster();
                model.subjectMasterList = await _iuserRegistration.GetSubjects();
                return Ok(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost, Route("user-register-update")]
        public async Task<IActionResult> AddUpdateUserDetails(UserRegistrationVM model)
        {
            try
            {
                var getOutput = await _iuserRegistration.NewUserRegistration(model);
                return Ok(getOutput);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet, Route("alluser-details")]
        public async Task<IActionResult> UserDetails()
        {
            try
            {
                var getdetails = await _iuserRegistration.GetUser();
                return Ok(getdetails);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
