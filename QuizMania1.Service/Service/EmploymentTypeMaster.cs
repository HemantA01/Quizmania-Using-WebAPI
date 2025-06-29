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
    public class EmploymentTypeMaster : IEmploymentTypeMaster
    {
		private readonly ApplicationDBContext _dbContext;
		public EmploymentTypeMaster(ApplicationDBContext dbContext)
		{
			_dbContext= dbContext;
		}
        public async Task<List<EmploymentTypeMasterVM>> GetEmploymentType()
        {
			try
			{
				var lstEmploymentType = await _dbContext.tblEmploymentTypeMaster.Select(x => new EmploymentTypeMasterVM
				{
					Id = x.Id,
					EmploymentType= x.EmploymentType,
					IsActive = x.IsActive
				}).ToListAsync();
				return lstEmploymentType;
			}
			catch (Exception ex)
			{
				throw;
			}
        }

		#region Add EmploymentType
		public async Task<int> AddEmploymentType(EmploymentTypeMasterVM model)
		{
			int i = -1;
			try
			{
				
				if (model.Id == 0)
				{
                    var ifExists = await _dbContext.tblEmploymentTypeMaster.Where(x => x.EmploymentType == model.EmploymentType).FirstOrDefaultAsync();
					if (ifExists == null)
					{
						TblEmploymentTypeMaster empTypeMaster = new TblEmploymentTypeMaster();
						empTypeMaster.Id = model.Id;
						empTypeMaster.EmploymentType = model.EmploymentType;
						empTypeMaster.IsActive = true;
						_dbContext.tblEmploymentTypeMaster.Add(empTypeMaster);
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

		#region Update EmploymentType Details
		public async Task<int> UpdateEmploymentType(int? Id, EmploymentTypeMasterVM model)
		{
			int i = 0;
			try
			{
                var ifExists = await _dbContext.tblEmploymentTypeMaster.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (ifExists != null)
                {
                    if (ifExists.EmploymentType == model.EmploymentType && ifExists.IsActive==model.IsActive)
                    {
                        i = -2;
                    }
                    else
                    {
                        ifExists.EmploymentType = model.EmploymentType;
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
        public async Task<int> UpdateEmploymentTypeStatus(int? Id, EmploymentTypeMasterVM model)
        {
            int i = 0;
            try
            {
                var ifExists = await _dbContext.tblEmploymentTypeMaster.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
				if (ifExists != null)
				{
					ifExists.IsActive = model.IsActive;
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

		#region Delete EmploymentType
		public async Task<int> DeleteEmploymentType(int? Id)
		{
            int i = 0;
            try
            {
                var ifExists = await _dbContext.tblEmploymentTypeMaster.Where(x => x.Id == Id).FirstOrDefaultAsync();
                if (ifExists != null)
                {
                    _dbContext.tblEmploymentTypeMaster.Remove(ifExists);
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
