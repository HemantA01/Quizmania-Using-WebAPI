using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Quizmania1.Model.ViewModel;
using Quizmania1.Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Quizmania1.API.Controllers
{
    [Route("api/{version:ApiVersion}/[controller]")]
    [ApiController]
    [ApiVersion(1)]
    //[ApiVersion(2)]   //Login is not required in all the versions as the JWT token generated after login work in authorization of APIs in all the version(s) mentioned 
    //[ApiVersion(3)]
    //[ApiVersion(4)]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserLogin _login;
        private readonly IConfiguration _config;
       // private readonly IHttpContextAccessor httpContextAccessor;
        public UserLoginController(IUserLogin login, IConfiguration config)
        {
            _login = login;
            _config = config;
           // this.httpContextAccessor = httpContextAccessor;
        }
        #region Get User Login Details
        [HttpPost, Route("user-login")]
        [MapToApiVersion(1)]
        //[MapToApiVersion(2)]
        //[MapToApiVersion(3)]
        //[MapToApiVersion(4)]
        public async Task<IActionResult> GetUserLoginDetails(UserLoginVM model)
        {
            try
            {
                var getDetails = await _login.VerifyUser(model);
                if (getDetails != null)
                {
                    var jwt = GenerateToken(getDetails);
                    getDetails[0].Token = jwt;
                   HttpContext.Session.SetString("JwtValue", jwt);
                    return Ok(getDetails);
                }
                return NotFound("user details not found");
            }
            catch (Exception ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion

        #region Generate JWT Token
        private string GenerateToken(List<UserLoginDetailsVM> model)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier,model[0].Username),
                    new Claim(ClaimTypes.SerialNumber,model[0].UserId.ToString()),
                    new Claim(ClaimTypes.Email,model[0].UserEmail),
                };
                var token = new JwtSecurityToken(_config["JWT:Issuer"],
                    _config["JWT:Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
