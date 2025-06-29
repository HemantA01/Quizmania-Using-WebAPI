using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmania1.Model.ViewModel
{
    public class StateMasterVM
    {
        public int Id { get; set; }
        public int? CountryId { get; set; }
        public string? StateName { get; set; } 
        public bool IsActive { get; set; }
    }

    public class CountryStateMasterVM
    {
        public int StateId { get; set; }
        public int? CountryId { get; set; }
        public string? CountryName { get; set; }
        public string? StateName { get; set; }
        public bool IsActive { get; set; }
    }

    public class CountryStateVM
    {
        public CountryStateVM()
        {
            countryMasterList= new List<CountryMasterVM>();
            countryStateMasterList= new List<CountryStateMasterVM>();
            stateMaster = new StateMasterVM();
        }
        public List<CountryStateMasterVM> countryStateMasterList { get; set; }
        public List<CountryMasterVM> countryMasterList { get; set; }
        public StateMasterVM stateMaster { get; set; }
    }
}
