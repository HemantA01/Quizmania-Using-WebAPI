using Quizmania1.Model.ViewModel;

namespace QuizMania1.UI.Interface
{
    public interface IUserLogin
    {
        Task<List<UserLoginDetailsVM>> VerifyUser(UserLoginVM model);
    }
}
