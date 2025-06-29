using Dapper;
using Quizmania1.Data.DBContext;
using Quizmania1.Model.ViewModel;
using Quizmania1.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmania1.Service.Service
{
    public class DapperStateMaster : IDapperStateMaster
    {
        private readonly DapperContext _dContext;
        public DapperStateMaster(DapperContext dContext) 
        {
            _dContext = dContext;
        }
        public async Task<List<CountryStateMasterVM>> GetAllStatesList()
        {
            try
            {
                string procName = "usp_StateMaster";
                var param = new DynamicParameters();
                param.Add("@Action", 1);
                using (var connection = _dContext.CreateConnection())
                {
                    connection.Open();
                    var getstatedetails = await connection.QueryAsync<CountryStateMasterVM>(procName, param, commandType: System.Data.CommandType.StoredProcedure);
                    return getstatedetails.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<CountryMasterVM>> GetActiveCountries()
        {
            try
            {
                string procName = "usp_StateMaster";
                var param = new DynamicParameters();
                param.Add("@Action", 2);
                using (var connection = _dContext.CreateConnection())
                {
                    connection.Open();
                    var getdetails = await connection.QueryAsync<CountryMasterVM>(procName, param, commandType: System.Data.CommandType.StoredProcedure);
                    return getdetails.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
