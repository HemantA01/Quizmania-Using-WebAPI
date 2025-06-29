using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Newtonsoft.Json;
using Quizmania1.Model.ViewModel;
using QuizMania1.UI.Helpers;
using QuizMania1.UI.Interface;
using RestSharp;
using Microsoft.AspNetCore.Session;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace QuizMania1.UI.Service
{
    public class CountryMaster : ICountryMaster
    {
        private readonly HelpersAPI _helpersAPI;
             private readonly IHttpContextAccessor _httpContextAccessor;
        
        public CountryMaster(IHttpContextAccessor httpContextAccessor)
        {
            this._helpersAPI = new HelpersAPI();
            
             _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<CountryMasterVM>> GetAllCountries()
        {
			try
			{
                string authorize = _httpContextAccessor.HttpContext.Session.GetString("JwtValue");
                List<CountryMasterVM> countrylist = new List<CountryMasterVM>();
                var client = _helpersAPI.Initial();
                
                 client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorize); //use with JWT token authorization
                var response = await client.GetAsync("api/CountryMaster/GetAllCountries");
                var result1 = response.Content.ReadAsStringAsync().Result;
                var content = await response.Content.ReadAsStringAsync();
                
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    countrylist = JsonConvert.DeserializeObject<List<CountryMasterVM>>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
                return countrylist;
            }
			catch (Exception ex)
			{
				throw;
			}
        }
        public async Task<int> InsertCountry(CountryMasterVM model)
        {
            try
            {
                int value = 0;
                var client = _helpersAPI.Initial();
                string authorize = _httpContextAccessor.HttpContext.Session.GetString("JwtValue");
                var company = System.Text.Json.JsonSerializer.Serialize(model);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorize);     //use with JWT token authorization
                var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("api/CountryMaster/add-country", requestContent);
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
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> UpdateCountry(int? Id, CountryMasterVM model)
        {
            int value = -1;
            try
            {
                var client = _helpersAPI.Initial();
                var company = System.Text.Json.JsonSerializer.Serialize(model);
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "");     use with JWT token authorization
                var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
                var response = await client.PutAsync("api/CountryMaster/update-country?Id="+Id, requestContent);
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
        public async Task<int> UpdateCountryStatus(int? Id, CountryMasterVM model)
        {
            int value = -1;
            try
            {
                var client = _helpersAPI.Initial();
                var company = System.Text.Json.JsonSerializer.Serialize(model);
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "");     use with JWT token authorization
                var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
                var response = await client.PatchAsync("api/CountryMaster/update-status?Id=" + Id, requestContent);
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
        public async Task<bool> DeleteCountry(int? Id)
        {
            bool result = false;
            try
            {
                var client = _helpersAPI.Initial();
                //var company = System.Text.Json.JsonSerializer.Serialize(model);
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "");     use with JWT token authorization
                //var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
                var response = await client.DeleteAsync("api/CountryMaster/remove-country?Id=" + Id);
                var result1 = response.Content.ReadAsStringAsync().Result;
                var content = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    result = JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
