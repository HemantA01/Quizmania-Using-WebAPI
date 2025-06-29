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
    public class CountryMaster : ICountryMaster
    {
		private readonly ApplicationDBContext _dbContext;
		public CountryMaster(ApplicationDBContext dbContext)
		{
			_dbContext= dbContext;
		}
        public async Task<List<CountryMasterVM>> GetCountries()
        {
			try
			{
				var lstCountries = await _dbContext.tblCountryMaster.Select(x => new CountryMasterVM
				{
					Id = x.Id,
					CountryName = x.CountryName,
					CountryAbb = x.CountryAbb,
					IsActive = x.IsActive
				}).ToListAsync();
				return lstCountries;
			}
			catch (Exception ex)
			{
				throw;
			}
        }

		#region Add Countries
		public async Task<int> AddCountry(CountryMasterVM model)
		{
			int i = -1;
			try
			{
				
				if (model.Id == 0)
				{
                    var ifExists = await _dbContext.tblCountryMaster.Where(x => x.CountryName == model.CountryName).FirstOrDefaultAsync();
					if (ifExists == null)
					{
						TblCountryMaster countryMaster = new TblCountryMaster();
						countryMaster.Id = model.Id;
						countryMaster.CountryName = model.CountryName.ToUpper();
						countryMaster.CountryAbb = model.CountryAbb.ToUpper();
						countryMaster.IsActive = true;
						_dbContext.tblCountryMaster.Add(countryMaster);
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

		#region Update Country Details
		public async Task<int> UpdateCountry(int? Id, CountryMasterVM model)
		{
			int i = 0;
			try
			{
                var ifExists = await _dbContext.tblCountryMaster.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (ifExists != null)
                {
                    if (ifExists.CountryName.Trim().ToLower() == model.CountryName.Trim().ToLower() && ifExists.CountryAbb.Trim().ToLower()==model.CountryAbb.Trim().ToLower())
                    {
                        i = 0;
                    }
                    else
                    {
                        ifExists.CountryName = model.CountryName.ToUpper();
                        ifExists.CountryAbb = model.CountryAbb.ToUpper();
                        //ifExists.IsActive = model.IsActive;
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

        #region Update Country Status to Active/Inactive
        public async Task<int> UpdateCountryStatus(int? Id, CountryMasterVM model)
        {
            int i = -1;
            try
            {
                var ifExists = await _dbContext.tblCountryMaster.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
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

		#region Delete country
		public async Task<bool> DeleteCountry(int? Id)
		{
            bool result = false;
            try
            {
                var ifExists = await _dbContext.tblCountryMaster.Where(x => x.Id == Id).FirstOrDefaultAsync();
                if (ifExists != null)
                {
                    _dbContext.tblCountryMaster.Remove(ifExists);
                    await _dbContext.SaveChangesAsync();
					result = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
