using Business.Interfaces.Login;
using Common.Helpers;
using DTO.Response.Login;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DTO.Request.Login;
using DataAccess.Models;
using Business.Interfaces.BaseBLL;
using DTO.Response;

namespace Business.BLL.Login
{
    public class LoginBLL : ILoginBLL
    {
        private readonly IBaseBLL<LoginRequest, LoginSearchResponse, Student> _BaseUsuarios;
        private readonly IConfiguration _configuration;
        public LoginBLL(IBaseBLL<LoginRequest, LoginSearchResponse, Student> BaseUsuarios, IConfiguration configuration)
        {
            _BaseUsuarios = BaseUsuarios;
            _configuration = configuration;
        }
        public async Task<GenericResponse<LoginResponse>> Login(LoginRequest loginRequest)
        {
            try
            {
                //Validations necessary for login, below is an example simulating a query to the correct database
                bool Validacion = true;

                LoginSearchResponse searchUser = new()
                {
                    CampanaId = 1,
                    Username = "Example",
                    Id = 1,
                };

                if (Validacion)
                {
                    string Token = BuildToken(Encrypt.EncriptarSHA512(_configuration.GetSection("NameSite").Value + "TestFinanzauto"), searchUser);
                    LoginResponse loginresponse = new()
                    {
                        Token = Token
                    };
                    return GenericResponse<LoginResponse>.ResponseOK(loginresponse);
                }

                return GenericResponse<LoginResponse>.ResponseValidation("Credenciales incorrectas");

            }
            catch (Exception ex)
            {
                return GenericResponse<LoginResponse>.ResponseError(ex.Message);
            }
        }

        private string BuildToken(string secret, LoginSearchResponse UserData)
        {
            var claims = new[]
            {
             new Claim(ClaimTypes.NameIdentifier,UserData.Id.ToString()),
             new Claim(ClaimTypes.Name, UserData.Username),
         };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(5),
                SigningCredentials = credenciales
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
