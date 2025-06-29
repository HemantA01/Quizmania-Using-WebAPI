using Newtonsoft.Json;
using Quizmania1.Model.ViewModel;
using QuizMania1.UI.Helpers;
using QuizMania1.UI.Interface;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace QuizMania1.UI.Service
{
    public class UserLogin : IUserLogin
    {
        private readonly HelpersAPI _helpersAPI;
        public UserLogin()
        {
            this._helpersAPI = new HelpersAPI();
        }

        public async Task<List<UserLoginDetailsVM>> VerifyUser(UserLoginVM model)
        {
            try
            {
                List<UserLoginDetailsVM> logindetails = new List<UserLoginDetailsVM>();
                var client = _helpersAPI.Initial();
                var company = System.Text.Json.JsonSerializer.Serialize(model);
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "");     use with JWT token authorization
                var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("api/UserLogin/user-login", requestContent);
                var result1 = response.Content.ReadAsStringAsync().Result;
                var content = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    logindetails = JsonConvert.DeserializeObject<List<UserLoginDetailsVM>>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
                return logindetails;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
