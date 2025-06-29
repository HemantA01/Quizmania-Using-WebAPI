using Microsoft.EntityFrameworkCore;
using Quizmania1.Data.DBContext;
using Quizmania1.Model.ViewModel;
using Quizmania1.Service.Interface;
using QuizMania1.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmania1.Service.Service
{
    public class UserLogin : IUserLogin
    {
		public readonly ApplicationDBContext _dbContext;
		public UserLogin(ApplicationDBContext dbContext)
		{
			_dbContext= dbContext;
		}
        public async Task<List<UserLoginDetailsVM>> VerifyUser(UserLoginVM model)
        {
			try
			{
				var ifExists = await (from reg in _dbContext.tblUserRegistration
									  join login in _dbContext.tblUserLogin on reg.Id equals login.UserId
									  where login.Username == model.Username && login.Password == RandomNumber.ComputeSHA256(model.Password) && login.IsActive==true
									  select new UserLoginDetailsVM
									  { 
										  UserId = login.UserId,
										  UserEmail = reg.UserEmailId,
										  Username = login.Username
									  }).ToListAsync();
				return ifExists;
			}
			catch (Exception ex)
			{
				throw;
			}
        }
    }
}
