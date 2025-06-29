using Quizmania1.Model.ViewModel;

namespace QuizMania1.UI.Interface
{
    public interface ICountryMaster
    {
        Task<List<CountryMasterVM>> GetAllCountries();
        Task<int> InsertCountry(CountryMasterVM model);
        Task<int> UpdateCountry(int? Id,CountryMasterVM model);
        Task<int> UpdateCountryStatus(int? Id,CountryMasterVM model);
        Task<bool> DeleteCountry(int? Id);
    }
}
