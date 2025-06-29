using Quizmania1.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmania1.Service.Interface
{
    public interface IUserRegistration
    {
        Task<List<CountryMasterVM>> GetCountries();
        Task<List<EmploymentTypeMasterVM>> GetEmpTypeMaster();
        Task<List<CountryStateMasterVM>> GetStates();
        Task<List<SubjectMasterVM>> GetSubjects();
        Task<int> NewUserRegistration(UserRegistrationVM model);
        Task<List<UserRegistrationVM>> GetUser();
    }
}
