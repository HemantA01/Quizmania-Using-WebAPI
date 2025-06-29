using Quizmania1.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmania1.Service.Interface
{
    public interface IDapperCountryMaster
    {
        Task<List<CountryMasterVM>> GetCountryMasterAsync();
        Task<int> AddCountryAsync(CountryMasterVM model);
        Task<int> UpdateCountryDetailsAsync(CountryMasterVM model);
        Task<int> UpdateCountryStatusAsync(int? countryId, bool status);
        Task<int> DeleteCountryAsync(int? countryId);
        Task<CountryMasterVM> GetCountryMasterByIdAsync(int? countryId);
        Task<CountryMasterVM> FetchCountryMasterByIdAsync(CountryMasterVM model);
    }
}
