using Dapper;
using Quizmania1.Data.DBContext;
using Quizmania1.Model.ViewModel;
using Quizmania1.Service.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmania1.Service.Service
{
    public class DapperCountryMaster : IDapperCountryMaster
    {
        private readonly DapperContext _context;
        public DapperCountryMaster(DapperContext context)
        {
            _context = context;
        }
        public async Task<List<CountryMasterVM>> GetCountryMasterAsync()
        {
            try
            {
                string procname = "usp_CountryMaster";
                var param = new DynamicParameters();
                param.Add("@Action", 1);
                using (var connection = _context.CreateConnection())
                { 
                    connection.Open();
                    var countries = await connection.QueryAsync<CountryMasterVM>(procname, param, commandType: CommandType.StoredProcedure);
                    return countries.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AddCountryAsync(CountryMasterVM model)
        {
            try
            {
                string procname = "usp_CountryMaster";
                var param = new DynamicParameters();
                param.Add("@CountryName", model.CountryName, DbType.String);
                param.Add("@CountryAbb", model.CountryAbb, DbType.String);
                param.Add("@Action", 2);
                using (var connection = _context.CreateConnection())
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(procname, param, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> UpdateCountryDetailsAsync(CountryMasterVM model)
        {
            try
            {
                string procname = "usp_CountryMaster";
                var param = new DynamicParameters();
                param.Add("@CountryName", model.CountryName, DbType.String);
                param.Add("@CountryAbb", model.CountryAbb, DbType.String);
                param.Add("@CountryId", model.Id, DbType.Int32);
                param.Add("@Action", 3);
                using (var connection = _context.CreateConnection())
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(procname, param, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> UpdateCountryStatusAsync(int? countryId, bool status)
        {
            try
            {
                string procname = "usp_CountryMaster";
                var param = new DynamicParameters();
                param.Add("@CountryId", countryId, DbType.Int32);
                param.Add("@IsActive", status, DbType.Boolean);
                param.Add("@Action", 4);
                using (var connection = _context.CreateConnection())
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(procname, param, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> DeleteCountryAsync(int? countryId)
        {
            try
            {
                string procname = "usp_CountryMaster";
                var param = new DynamicParameters();
                param.Add("@CountryId", countryId, DbType.Int32);
                param.Add("@Action", 5);
                using (var connection = _context.CreateConnection())
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(procname, param, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<CountryMasterVM> GetCountryMasterByIdAsync(int? countryId)
        {
            try
            {
                string procname = "usp_CountryMaster";
                var param = new DynamicParameters();
                param.Add("@CountryId", countryId, DbType.Int32);
                param.Add("@Action", 6);
                using (var connection = _context.CreateConnection())
                {
                    connection.Open();
                    var countries = await connection.QueryFirstOrDefaultAsync<CountryMasterVM>(procname, param, commandType: CommandType.StoredProcedure);
                    return countries;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<CountryMasterVM> FetchCountryMasterByIdAsync(CountryMasterVM model)
        {
            try
            {
                string procname = "usp_CountryMaster";
                var param = new DynamicParameters();
                param.Add("@CountryId", model.Id, DbType.Int32);
                param.Add("@Action", 6);
                using (var connection = _context.CreateConnection())
                {
                    connection.Open();
                    var countries = await connection.QueryFirstOrDefaultAsync<CountryMasterVM>(procname, param, commandType: CommandType.StoredProcedure);
                    return countries;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
