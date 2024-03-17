using CrudApplication.CommonLayer.Model;
using CrudApplication.ServiceLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CrudApplication.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CrudApplicationController : ControllerBase
    {
        public readonly ICrudApplicationSL _crudApplicationSL;

        private IConfiguration _config;

        public CrudApplicationController(ICrudApplicationSL crudApplicationSL, IConfiguration configuration)
        {
            _crudApplicationSL = crudApplicationSL;
            _config = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginInformationRequest request)
        {
            LoginInformationResponse response = new LoginInformationResponse();
            
            try
            {
                response = await _crudApplicationSL.GetUserInformation(request);

                if (!response.IsSuccess)
                {
                    return BadRequest(response);
                }
                else
                {
                    response.Token = this.GenerateToken(request);
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        private string GenerateToken(LoginInformationRequest request)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
                            _config["Jwt:Issuer"],
                            null,
                            expires: DateTime.Now.AddMinutes(120),
                            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(Sectoken);
        }

        [HttpPost]
        public async Task<IActionResult> AddInformation(AddInformationRequest request)
        {
            AddInformationResponse response = new AddInformationResponse();

            try
            {
                response = await _crudApplicationSL.AddInformation(request);
                
                if(!response.IsSuccess)
                {
                    return BadRequest(response);
                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }
 
        [HttpPut]
        public async Task<IActionResult> UpdateAllInformationById(UpdateAllInformationByIdRequest request)
        {
            UpdateAllInformationByIdResponse response = new UpdateAllInformationByIdResponse();

            try
            {
                response = await _crudApplicationSL.UpdateAllInformationById(request);
                
                if(!response.IsSuccess)
                {
                    return BadRequest(response);
                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteInformationById(DeleteInformationByIdRequest request)
        {
            DeleteInformationByIdResponse response = new DeleteInformationByIdResponse();

            try
            {
                response = await _crudApplicationSL.DeleteInformationById(request);
                
                if(!response.IsSuccess)
                {
                    return BadRequest(response);
                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ReadAllInformation()
        {
            ReadAllInformationResponse response = new ReadAllInformationResponse();

            try
            {
                response = await _crudApplicationSL.ReadAllInformation();

                if (!response.IsSuccess)
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }
    }
}
