using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmania1.Model.ViewModel
{
    public class UserRegistrationControlsVM
    {
        public UserRegistrationControlsVM()
        {
            countryMasterList = new();
            stateMasterList = new();
            empTypeMasterList= new();
            userRegistration = new();
            userRegistrationList= new();
        }
        public List<CountryMasterVM> countryMasterList { get; set; }
        public List<CountryStateMasterVM> stateMasterList { get; set; }
        public List<EmploymentTypeMasterVM> empTypeMasterList { get; set; }
        public List<SubjectMasterVM> subjectMasterList { get; set; }
        public UserRegistrationVM userRegistration { get; set; }
        public List<UserRegistrationVM> userRegistrationList { get; set; }
    }
}
