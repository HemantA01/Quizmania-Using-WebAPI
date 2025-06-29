using Newtonsoft.Json;
using Quizmania1.Model.ViewModel;
using QuizMania1.UI.Helpers;
using QuizMania1.UI.Interface;
using System.Net;
using System.Net.Http.Headers;
using System.Text;


namespace QuizMania1.UI.Service
{
    public class StateMaster : IStateMaster
    {
        private readonly HelpersAPI _helpersAPI;
        public StateMaster()
        {
            this._helpersAPI = new HelpersAPI();
        }
        public async Task<CountryStateVM> GetStatesListAsync()
        {
            try
            {
                CountryStateVM stateslist = new   CountryStateVM();
                var client = _helpersAPI.Initial();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "");     use with JWT token authorization
                var response = await client.GetAsync("api/StateMaster/get-state-countrylist");
                var result1 = response.Content.ReadAsStringAsync().Result;
                var content = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    stateslist = JsonConvert.DeserializeObject<CountryStateVM>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
                return stateslist;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AddStates(StateMasterVM model)
        {
            try
            {
                int? getStatus = -1;
                var client = _helpersAPI.Initial();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var company = System.Text.Json.JsonSerializer.Serialize(model);
                var requestContent = new StringContent(company,Encoding.UTF8,"application/json");
                var response = await client.PostAsync("api/StateMaster/insert-state", requestContent);
                var result1 = response.Content.ReadAsStringAsync().Result;
                var content = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    getStatus = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
                }
                else if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
                return (int)getStatus;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> UpdateStates(int? Id, StateMasterVM model)
        {
            int value = -1;
            try
            {
                var client = _helpersAPI.Initial();
                var company = System.Text.Json.JsonSerializer.Serialize(model);
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "");     use with JWT token authorization
                var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
                var response = await client.PutAsync("api/StateMaster/update-state?Id=" + Id, requestContent);
                var result1 = response.Content.ReadAsStringAsync().Result;
                var content = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    value = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
                return value;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> UpdateStateStatus(int? Id, StateMasterVM model)
        {
            int value = -1;
            try
            {
                var client = _helpersAPI.Initial();
                var company = System.Text.Json.JsonSerializer.Serialize(model);
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "");     use with JWT token authorization
                var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
                var response = await client.PatchAsync("api/StateMaster/update-status?Id=" + Id, requestContent);
                var result1 = response.Content.ReadAsStringAsync().Result;
                var content = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    value = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
                return value;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
