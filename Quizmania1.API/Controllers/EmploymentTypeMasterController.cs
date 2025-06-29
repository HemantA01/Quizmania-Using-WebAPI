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
    public class EmploymentTypeMasterController : ControllerBase
    {
        private readonly IEmploymentTypeMaster _empTypeMaster;
        public EmploymentTypeMasterController(IEmploymentTypeMaster empTypeMaster) 
        { 
            _empTypeMaster = empTypeMaster;
        }

        #region Get All EmploymentType
        [HttpGet, Route("GetEmploymentTypeList")]
        public async Task<IActionResult> GetAllEmploymentType() 
        {
            try
            {
                var lstEmploymentType = await _empTypeMaster.GetEmploymentType();
                return Ok(lstEmploymentType);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Insert Country
        [HttpPost, Route("add-employmenttype")]
        public async Task<IActionResult> InsertEmploymentType(EmploymentTypeMasterVM model)
        {
            try
            {
                var id = await _empTypeMaster.AddEmploymentType(model);
                return Ok(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Update EmploymentType Details
        [HttpPut, Route("update-emptype")]
        public async Task<IActionResult> UpdateEmploymentType(int? Id, EmploymentTypeMasterVM model)
        {
            try
            {
                var id = await _empTypeMaster.UpdateEmploymentType(Id, model);
                return Ok(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Update EmploymentType Status
        [HttpPatch]
        [Route("update-empstatus")]
        public async Task<IActionResult> UpdateEmploymentTypeStatus(int? Id, EmploymentTypeMasterVM model)
        {
            try
            {
                var id = await _empTypeMaster.UpdateEmploymentTypeStatus(Id, model);
                return Ok(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Delete EmploymentType
        [HttpDelete]
        [Route("remove-emptype")]
        public async Task<IActionResult> DeleteEmploymentType(int? Id)
        {
            try
            {
                var id = await _empTypeMaster.DeleteEmploymentType(Id);
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
