using Quizmania1.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmania1.Service.Interface
{
    public interface ICountryMaster
    {
        Task<List<CountryMasterVM>> GetCountries();
        Task<int> AddCountry(CountryMasterVM country);
        Task<int> UpdateCountry(int? Id, CountryMasterVM country);
        Task<int> UpdateCountryStatus(int? Id, CountryMasterVM country);
        Task<bool> DeleteCountry(int? Id);
    }
}
