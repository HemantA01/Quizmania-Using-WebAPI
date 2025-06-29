using Quizmania1.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmania1.Service.Interface
{
    public interface IEmploymentTypeMaster
    {
        Task<List<EmploymentTypeMasterVM>> GetEmploymentType();
        Task<int> AddEmploymentType(EmploymentTypeMasterVM country);
        Task<int> UpdateEmploymentType(int? Id, EmploymentTypeMasterVM model);
        Task<int> UpdateEmploymentTypeStatus(int? Id, EmploymentTypeMasterVM model);
        Task<int> DeleteEmploymentType(int? Id);
    }
}
