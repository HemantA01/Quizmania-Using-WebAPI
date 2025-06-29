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
    public class StateMaster : IStateMaster
    {
        private readonly ApplicationDBContext _dbContext;
        public StateMaster(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Get StateCountry List
        public async Task<List<CountryStateMasterVM>> GetCountryStateList()
        {
            try
            {
                var getStateDetails = await (from cnt in _dbContext.tblCountryMaster
                                             join state in _dbContext.tblStateMaster on cnt.Id equals state.CountryId
                                             select new CountryStateMasterVM {
                                                 StateId = state.Id,
                                                 CountryId = state.CountryId,
                                                 StateName= state.StateName,
                                                 CountryName = cnt.CountryName +" ("+cnt.CountryAbb+")",
                                                 IsActive = state.IsActive,
                                             }).ToListAsync();
                return getStateDetails; 
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Get Country List
        public async Task<List<CountryMasterVM>> GetCountryList()
        {
            try
            {
                var getCountryList = await _dbContext.tblCountryMaster.Where(x => x.IsActive == true).Select(x => new CountryMasterVM
                {
                    Id = x.Id,
                    CountryName= x.CountryName,
                    CountryAbb= x.CountryAbb,
                    IsActive = x.IsActive
                }).ToListAsync();
                return getCountryList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Add State
        public async Task<int> AddState(StateMasterVM model)
        {
            try
            {
                int i = 0;
                var ifCountryExists = await _dbContext.tblCountryMaster.Where(x=>x.Id==model.CountryId &&x.IsActive==true).FirstOrDefaultAsync();
                if (ifCountryExists == null)
                {
                    i = -2;
                }
                else 
                {
                    var ifStateExists = await _dbContext.tblStateMaster.Where(x => x.CountryId == model.CountryId && x.StateName == model.StateName).FirstOrDefaultAsync();
                    if (ifStateExists != null)
                    {
                        i = -3;
                    }
                    else
                    {
                        TblStateMaster state = new TblStateMaster();
                        state.CountryId= model.CountryId;
                        state.StateName = model.StateName.ToUpper();
                        state.IsActive = true;
                        _dbContext.tblStateMaster.Add(state);
                        i = await _dbContext.SaveChangesAsync();
                    }
                }
                return i;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Get State Details based on id
        public async Task<StateMasterVM> GetStateById(int? Id)
        {
            try
            {
                var getStateDetail = await _dbContext.tblStateMaster.Where(x => x.Id == Id).Select(m => new StateMasterVM
                {
                    Id = m.Id,
                    CountryId= m.CountryId,
                    StateName = m.StateName,
                    IsActive = m.IsActive
                }).FirstOrDefaultAsync();
                return getStateDetail;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Update particular State Details
        public async Task<int> UpdateState(int? Id, StateMasterVM model)
        {
            try
            {
                int result = -1;
                var ifCountryExists = await _dbContext.tblCountryMaster.Where(x=>x.Id==model.CountryId && x.IsActive==true).FirstOrDefaultAsync();
                if (ifCountryExists != null)
                {
                    var getState = await _dbContext.tblStateMaster.Where(xz => xz.Id == model.Id).FirstOrDefaultAsync();
                    if (getState != null)
                    {
                        getState.CountryId = model.CountryId;
                        getState.StateName = model.StateName.ToUpper();
                        getState.IsActive = model.IsActive;
                        result = await _dbContext.SaveChangesAsync();
                    }
                }
                else
                {
                    result = -2;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
        #endregion

        #region Update particular State Status
        public async Task<int> UpdateStateStatus(StateMasterVM model)
        {
            try
            {
                int result = 0;
                var getState = await _dbContext.tblStateMaster.Where(xz => xz.Id == model.Id).FirstOrDefaultAsync();
                if (getState != null)
                {
                    getState.IsActive = model.IsActive;
                    result = await _dbContext.SaveChangesAsync();
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
