using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Quizmania1.Data.DBContext;
using Quizmania1.Data.DBModel;
using Quizmania1.Model.ViewModel;
using Quizmania1.Service.Interface;
using QuizMania1.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Quizmania1.Service.Service
{
    public class UserRegistration : IUserRegistration
    {
        private readonly ApplicationDBContext _dbContext;
        public UserRegistration(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<CountryMasterVM>> GetCountries()
        {
            try
            {
                var getCountries = await _dbContext.tblCountryMaster.Where(x => x.IsActive == true).Select(x => new CountryMasterVM
                {
                    Id = x.Id,
                    CountryName = x.CountryName + " (" + x.CountryAbb + ")",
                    IsActive = x.IsActive
                }).ToListAsync();
                return getCountries;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<EmploymentTypeMasterVM>> GetEmpTypeMaster()
        {
            try
            {
                var getEmpType = await _dbContext.tblEmploymentTypeMaster.Where(x => x.IsActive == true).Select(x => new EmploymentTypeMasterVM
                {
                    Id = x.Id,
                    EmploymentType = x.EmploymentType,
                    IsActive = x.IsActive
                }).ToListAsync();
                return getEmpType;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<CountryStateMasterVM>> GetStates()
        {
            try
            {
                //if (countryId == 0)
                //{
                var getStates = await _dbContext.tblStateMaster.Where(x => x.IsActive == true).Select(x => new CountryStateMasterVM
                {
                    StateId = x.Id,
                    StateName = x.StateName,
                    CountryId = x.CountryId,
                    IsActive = x.IsActive
                }).ToListAsync();
                return getStates;
                //}
                //else
                //{
                /* var getStates = await _dbContext.tblStateMaster.Where(x => x.IsActive == true && x.CountryId == countryId).Select(x => new CountryStateMasterVM
                 {
                     StateId = x.Id,
                     StateName = x.StateName
                 }).ToListAsync();
                 return getStates;*/
                //}
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<SubjectMasterVM>> GetSubjects()
        {
            try
            {
                var getSubjectList = await _dbContext.tblSubjectMaster.Where(d => d.IsActive == true).Select(y => new SubjectMasterVM
                {
                    Id = y.Id,
                    Subject = y.Subject,
                    IsActive = y.IsActive
                }).ToListAsync();
                return getSubjectList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> NewUserRegistration(UserRegistrationVM model)
        {
            try
            {
                int output = -1;
                if (model.Id == 0)
                {
                    var ifUsernameExists = await _dbContext.tblUserLogin.Where(x => x.Username == model.Username).FirstOrDefaultAsync();
                    if (ifUsernameExists == null)
                    {

                        TblUserRegistration register = new();
                        register.UserFName = model.UserFName;
                        register.UserLName = model.UserLName;
                        register.UserContact = model.UserContact;
                        register.UserEmailId = model.UserEmailId;
                        register.DOB = model.DOB;
                        register.Age = model.Age;
                        register.Gender = model.Gender;
                        register.Nationality = model.Nationality;
                        register.TemporaryAddress = model.TemporaryAddress;
                        register.PermanentAddress = model.PermanentAddress;
                        register.CountryId = model.CountryId;
                        register.StateId = model.StateId;
                        register.City = model.City;
                        register.EmploymentTypeId = model.EmploymentTypeId;
                        _dbContext.tblUserRegistration.Add(register);
                        output = await _dbContext.SaveChangesAsync();

                        TblUserLogin login = new();
                        login.UserId = register.Id;
                        login.Username = model.Username;
                        string password = RandomNumber.RandomString(10);
                        login.PasswordAsText = password;
                        login.Password = RandomNumber.ComputeSHA256(password);
                        login.IsActive = true;
                        _dbContext.tblUserLogin.Add(login);
                        output = await _dbContext.SaveChangesAsync();

                        await Email.RegistrationEmail(model.UserFName + " " + model.UserLName, model.UserEmailId, model.Username, password);

                    }
                    else
                    {
                        output = -2;
                    }
                }
                else
                {
                    var objGetUser = await _dbContext.tblUserRegistration.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                    if (objGetUser != null)
                    {
                        objGetUser.UserFName = model.UserFName;
                        objGetUser.UserLName = model.UserLName;
                        objGetUser.UserContact = model.UserContact;
                        objGetUser.UserEmailId = model.UserEmailId;
                        objGetUser.DOB = model.DOB;
                        objGetUser.Age = model.Age;
                        objGetUser.Gender = model.Gender;
                        objGetUser.Nationality = model.Nationality;
                        objGetUser.TemporaryAddress = model.TemporaryAddress;
                        objGetUser.PermanentAddress = model.PermanentAddress;
                        objGetUser.CountryId = model.CountryId;
                        objGetUser.StateId = model.StateId;
                        objGetUser.City = model.City;
                        objGetUser.EmploymentTypeId = model.EmploymentTypeId;
                        output = await _dbContext.SaveChangesAsync();
                    }
                }
                return output;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<UserRegistrationVM>> GetUser()
        {
            try
            {
                var getSubjectList = await _dbContext.tblUserRegistration.Select(model => new UserRegistrationVM
                {
                    Id = model.Id,
                    UserFName = model.UserFName,
                    UserLName = model.UserLName,
                    UserContact = model.UserContact,
                    UserEmailId = model.UserEmailId,
                    DOB = model.DOB,
                    Age = model.Age,
                    Gender = model.Gender,
                    Nationality = model.Nationality,
                    TemporaryAddress = model.TemporaryAddress,
                    PermanentAddress = model.PermanentAddress,
                    CountryId = model.CountryId,
                    StateId = model.StateId,
                    City = model.City,
                    EmploymentTypeId = model.EmploymentTypeId
                }).ToListAsync();
                return getSubjectList;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
