using ContactsAPI.Data;
using ContactsAPI.DTOs;
using ContactsAPI.Helpers;
using ContactsAPI.Models;
using ContactsAPI.Services.Enums;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ContactsAPI.Services
{
    public class AuthService
    {
        private UnitOfWork unitOfWork;
        private IConfiguration configuration;

        public AuthService(IConfiguration configuration, UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
        }

        public ServiceResponse<string> Login(UserDTO dto)
        {
            var response = new ServiceResponse<string>()
            {
                Response = string.Empty
            };

            var user = unitOfWork.UsersRepository.GetWhere(user => user.Email == dto.Email).First();

            if (user == null)
            {
                response.ResponseType = ResponseTypes.ERROR;
                response.ResponseMessage = "User not found!";
                return response;
            }

            var hash = Helper.PasswordHash(dto.Password);

            if (user.Password != hash)
            {
                response.ResponseType = ResponseTypes.ERROR;
                response.ResponseMessage = "Wrong password!";
                return response;
            }

            response.Response = CreateToken(user);
            response.ResponseType = ResponseTypes.SUCCESS;
            return response;
        }

        public ServiceResponse<User> Register(UserDTO dto)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Email = dto.Email,
                Password = Helper.PasswordHash(dto.Password)
            };

            unitOfWork.UsersRepository.Create(user);
            unitOfWork.Save();

            return new ServiceResponse<User>()
            {
                Response = user,
                ResponseType = ResponseTypes.SUCCESS,
            };
        }

        /**
         * Can be checked in https://jwt.io
         * TODO: Create a class which can use this method as a helper instead
         */
        private string CreateToken(User user)
        {
            // Payload
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email)
            };

            // Signature to check
            var signature = configuration.GetSection("AppSettings:Token").Value;

            // Key to generate 
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signature));

            // Algorithm: HMAC-SHA256
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Expires: 1 day
            var expires = DateTime.Now.AddDays(1);

            var token = new JwtSecurityToken(claims: claims, expires: expires, signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
