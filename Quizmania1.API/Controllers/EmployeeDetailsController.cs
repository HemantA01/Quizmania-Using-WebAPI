using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizmania1.Model.ViewModel;
using Quizmania1.Service.Interface;
using System.Net;

namespace Quizmania1.API.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetailsController : ControllerBase
    {
        private readonly IEmployeeDetails _empdetails;
        public EmployeeDetailsController(IEmployeeDetails empdetails)
        {
            _empdetails = empdetails;
        }
        [HttpPost, Route("add-emp-details")]
        public async Task<IActionResult> AddEmployeeDetails(EmployeeDetailsVM model)
        {
            try
            {
                var getDetails = await _empdetails.AddEmployeeDetails(model);
                return Ok(getDetails);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet, Route("get-emp-details")]
        public async Task<IActionResult> GetEmployeeDetails()
        {
            try
            {
                var getDetails = await _empdetails.FetchEmployeeDetails();
                return Ok(getDetails);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPut, Route("update-employee-status")]
        public async Task<IActionResult> DeleteEmployee(int? id)
        {
            try
            {
               var getDetails = await _empdetails.DeleteEmployeesAsync(id);
                if (getDetails == true)
                {
                    return StatusCode((int)HttpStatusCode.OK, getDetails);
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.NotFound, getDetails);
                }
                 //return StatusCode((int)HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, null);
                throw;
            }
        }
        [HttpPut, Route("update-employee-details")]
        public async Task<IActionResult> UpdateEmployeeDetails(int? id, EmployeeDetailsVM model)
        {
            try
            {
                var getDetails = await _empdetails.UpdateEmployeeDetailsAsync(id, model);
                if (getDetails == true)
                {
                    return StatusCode((int)HttpStatusCode.OK, getDetails);
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.NotFound, getDetails);
                }
                //return StatusCode((int)HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, null);
                throw;
            }
        }
    }
}
