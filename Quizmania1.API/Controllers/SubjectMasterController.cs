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
    public class SubjectMasterController : ControllerBase
    {
        private readonly ISubjectMaster _subjectMaster;
        public SubjectMasterController(ISubjectMaster subjectMaster) 
        { 
            _subjectMaster = subjectMaster;
        }

        #region Get All Subject
        [HttpGet, Route("GetSubjectList")]
        public async Task<IActionResult> GetAllSubject() 
        {
            try
            {
                var lstSubject = await _subjectMaster.GetSubject();
                return Ok(lstSubject);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Insert Country
        [HttpPost, Route("add-subject")]
        public async Task<IActionResult> InsertSubject(SubjectMasterVM model)
        {
            try
            {
                var id = await _subjectMaster.AddSubject(model);
                return Ok(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Update Subject Details
        [HttpPut, Route("update-subject")]
        public async Task<IActionResult> UpdateSubject(int? Id, SubjectMasterVM model)
        {
            try
            {
                var id = await _subjectMaster.UpdateSubject(Id, model);
                return Ok(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Update Subject Status
        [HttpPatch]
        [Route("update-subjectstatus")]
        public async Task<IActionResult> UpdateSubjectStatus(int? Id, bool status)
        {
            try
            {
                var id = await _subjectMaster.UpdateSubjectStatus(Id, status);
                return Ok(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Delete Subject
        [HttpDelete]
        [Route("remove-subject")]
        public async Task<IActionResult> DeleteSubject(int? Id)
        {
            try
            {
                var id = await _subjectMaster.DeleteSubject(Id);
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
