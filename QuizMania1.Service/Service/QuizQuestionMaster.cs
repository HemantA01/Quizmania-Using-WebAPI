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
    public class QuizQuestionMaster : IQuizQuestionMaster
    {
        private readonly DapperContext _dContext;
        public QuizQuestionMaster(DapperContext dContext) 
        { 
            _dContext = dContext;
        }
        public async Task<int> AddQuestion(QuizQuestionMasterVM model)
        {
            try
            {
                string procName = "usp_InsertQuizQuestionMaster";
                var param = new DynamicParameters();
                param.Add("@CategoryId", model.CategoryId, DbType.Int32);
                param.Add("@Question", model.Question, DbType.String);
                param.Add("@Option1", model.Option1, DbType.String);
                param.Add("@Option2", model.Option2, DbType.String);
                param.Add("@Option3", model.Option3, DbType.String);
                param.Add("@Option4", model.Option4, DbType.String);
                param.Add("@Answer", model.Answer, DbType.Int32);
                param.Add("@IsActive", true, DbType.Boolean);
                param.Add("@Action", 1);
                using (var connection = _dContext.CreateConnection())
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(procName, param, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
