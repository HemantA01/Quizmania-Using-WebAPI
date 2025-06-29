using Microsoft.EntityFrameworkCore;
using Quizmania1.Data.DBContext;
using Quizmania1.Data.DBModel;
using Quizmania1.Model.ViewModel;
using Quizmania1.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmania1.Service.Service
{
    public class SubjectMaster : ISubjectMaster
    {
		private readonly ApplicationDBContext _dbContext;
		public SubjectMaster(ApplicationDBContext dbContext)
		{
			_dbContext= dbContext;
		}

        #region Get List of Subjects
        public async Task<List<SubjectMasterVM>> GetSubject()
        {
            try
            {
                var lstSubject = await _dbContext.tblSubjectMaster.Select(x => new SubjectMasterVM
                {
                    Id = x.Id,
                    Subject = x.Subject,
                    IsActive = x.IsActive
                }).ToListAsync();
                return lstSubject;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Add Subject
        public async Task<int> AddSubject(SubjectMasterVM model)
		{
			int i = -1;
			try
			{
				if (model.Id == 0)
				{
                    var ifExists = await _dbContext.tblSubjectMaster.Where(x => x.Subject == model.Subject).FirstOrDefaultAsync();
					if (ifExists == null)
					{
						TblSubjectMaster subjectMaster = new TblSubjectMaster();
						subjectMaster.Id = model.Id;
						subjectMaster.Subject = model.Subject;
						subjectMaster.IsActive = true;
						_dbContext.tblSubjectMaster.Add(subjectMaster);
						i = await _dbContext.SaveChangesAsync();
					}
					else
					{
						i = 0;
					}
				}
				return i;
			}
			catch (Exception ex)
			{
				throw;
			}
		}
		#endregion

		#region Update Subject Details
		public async Task<int> UpdateSubject(int? Id, SubjectMasterVM model)
		{
			int i = 0;
			try
			{
                var ifExists = await _dbContext.tblSubjectMaster.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (ifExists != null)
                {
                    if (ifExists.Subject == model.Subject && ifExists.IsActive==model.IsActive)
                    {
                        i = -2;
                    }
                    else
                    {
                        ifExists.Subject = model.Subject;
                        ifExists.IsActive = model.IsActive;
                        i = await _dbContext.SaveChangesAsync();
                    }
                }
				return i;
            }
			catch (Exception ex)
			{
				throw;
			}
		}
        #endregion

        #region Update Employment Status
        public async Task<int> UpdateSubjectStatus(int? Id, bool status)
        {
            int i = 0;
            try
            {
                var ifExists = await _dbContext.tblSubjectMaster.Where(x => x.Id == Id).FirstOrDefaultAsync();
				if (ifExists != null)
				{
					ifExists.IsActive = status;
					i = await _dbContext.SaveChangesAsync();
				}
				else
				{
					i = -2;
				}
                return i;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
		#endregion

		#region Delete Subject
		public async Task<int> DeleteSubject(int? Id)
		{
            int i = 0;
            try
            {
                var ifExists = await _dbContext.tblSubjectMaster.Where(x => x.Id == Id).FirstOrDefaultAsync();
                if (ifExists != null)
                {
                    _dbContext.tblSubjectMaster.Remove(ifExists);
                    i = await _dbContext.SaveChangesAsync();
                }
                else
                {
                    i = -2;
                }
                return i;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
