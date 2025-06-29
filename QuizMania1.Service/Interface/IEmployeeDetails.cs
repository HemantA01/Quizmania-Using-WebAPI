using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quizmania1.Model.ViewModel;

namespace Quizmania1.Service.Interface
{
    public interface IEmployeeDetails
    {
        Task<int> AddEmployeeDetails(EmployeeDetailsVM model);
        Task<List<EmployeeDetailsVM>> FetchEmployeeDetails();
        Task<bool> DeleteEmployeesAsync(int? id);
        Task<bool> UpdateEmployeeDetailsAsync(int? id, EmployeeDetailsVM model);
    }
}
