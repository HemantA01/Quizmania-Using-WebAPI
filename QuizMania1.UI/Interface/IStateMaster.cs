using Quizmania1.Model.ViewModel;

namespace QuizMania1.UI.Interface
{
    public interface IStateMaster
    {
        Task<CountryStateVM> GetStatesListAsync();
        Task<int> AddStates(StateMasterVM model);
        Task<int> UpdateStates(int? Id, StateMasterVM model);
        Task<int> UpdateStateStatus(int? Id, StateMasterVM model);
    }
}
