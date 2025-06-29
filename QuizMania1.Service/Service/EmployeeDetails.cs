using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
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
    public class EmployeeDetails : IEmployeeDetails
    {
        private readonly ApplicationDBContext _dbContext;
        public EmployeeDetails(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddEmployeeDetails(EmployeeDetailsVM model)
        {
            try
            {
                int i = -1;
                if (model.Id == 0)
                {
                    TblEmployeeDetails demoObj = new();
                    demoObj.FirstName = model.FirstName;
                    demoObj.LastName = model.LastName;
                    demoObj.Email = model.Email;
                    demoObj.DOB = model.DOB;
                    demoObj.Gender = model.Gender;
                    demoObj.HighestQualification = model.HighestQualification;
                    demoObj.CompanyServing = model.CompanyServing;
                    demoObj.TotalExperience = model.TotalExperience;
                    demoObj.Package = model.Package;
                    demoObj.IsActive = true;
                    demoObj.CreatedDate = DateTime.Now;
                    _dbContext.tblEmployeeDetails.Add(demoObj);
                    i = await _dbContext.SaveChangesAsync();
                }
                return i;
            }
            catch (Exception ex)
            {
                //return -2;
                throw;
            }
        }

        public async Task<List<EmployeeDetailsVM>> FetchEmployeeDetails()
        {
            try
            {
                var getdetails = await _dbContext.tblEmployeeDetails.Where(x => x.IsActive == true).Select(x => new EmployeeDetailsVM
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    DOB = x.DOB,
                    Gender = x.Gender,
                    HighestQualification = x.HighestQualification,
                    CompanyServing = x.CompanyServing,
                    TotalExperience = x.TotalExperience,
                    Package = x.Package
                }).ToListAsync();
                return getdetails;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteEmployeesAsync(int? id)
        {
            bool isDeleted= false;
            try
            {
                var getEmpDetailsById = await _dbContext.tblEmployeeDetails.Where(x => x.Id == id && x.IsActive == true).FirstOrDefaultAsync();
                if (getEmpDetailsById != null) 
                {
                    getEmpDetailsById.IsActive= false;
                    getEmpDetailsById.ModifiedDate= DateTime.Now;
                    await _dbContext.SaveChangesAsync();
                    isDeleted= true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return isDeleted;
        }

        public async Task<bool> UpdateEmployeeDetailsAsync(int? id, EmployeeDetailsVM model)
        {
            bool isUpdated = false;
            try
            {
                var getEmpDetailsById = await _dbContext.tblEmployeeDetails.Where(x => x.Id == id && x.IsActive == true).FirstOrDefaultAsync();
                if (getEmpDetailsById != null)
                {
                    getEmpDetailsById.FirstName = model.FirstName;
                    getEmpDetailsById.LastName = model.LastName;
                    getEmpDetailsById.Email = model.Email;
                    getEmpDetailsById.DOB = model.DOB;
                    getEmpDetailsById.Gender= model.Gender;
                    getEmpDetailsById.HighestQualification = model.HighestQualification;
                    getEmpDetailsById.TotalExperience = model.TotalExperience;
                    getEmpDetailsById.CompanyServing= model.CompanyServing;
                    getEmpDetailsById.Package = model.Package;
                    getEmpDetailsById.ModifiedDate = DateTime.Now;
                    await _dbContext.SaveChangesAsync();
                    isUpdated = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return isUpdated;
        }
    }
}
