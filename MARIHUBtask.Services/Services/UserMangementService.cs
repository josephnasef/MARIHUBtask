using AutoMapper;
using MARIHUBtask.Domin.AllEnum;
using MARIHUBtask.Domin.Models;
using MARIHUBtask.DTO.configuration;
using MARIHUBtask.DTO.DTOs;
using MARIHUBtask.DTO.DTOs.Response;
using MARIHUBtask.Repository.Abstraction;
using MARIHUBtask.Services.Abstraction;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MARIHUBtask.Services.Services
{

    public class UserMangementService : IUserMangementService
    {
        private readonly IApplicationUserRepo _ApplicationUserRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _RoleManager;
        private readonly JwtConfig _jwtConfig;

        private IPasswordHasher<ApplicationUser> _passwordHasher;
        public UserMangementService(IApplicationUserRepo applicationUserRepo,
            UserManager<ApplicationUser> userManager,
            IPasswordHasher<ApplicationUser> passwordHasher,
            RoleManager<IdentityRole> roleManager,
            Microsoft.Extensions.Options.IOptionsMonitor<JwtConfig> optionsMonitor,
            IMapper mapper)
        {
            _ApplicationUserRepo = applicationUserRepo;
            _mapper = mapper;
            _userManager = userManager;
            _passwordHasher = passwordHasher;
            _RoleManager = roleManager;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        public async Task<bool> CreateUser(ApplicationUserDTO entity)
        {
            IdentityRole role = new IdentityRole()
            {
                Name = "First"
            };



            await _RoleManager.CreateAsync(role);
            var mappedUser = _mapper.Map<ApplicationUser>(entity);
            IdentityResult result = await _userManager.CreateAsync(mappedUser, entity.Password);
            var userreterned = await _userManager.FindByEmailAsync(mappedUser.Email);
            var Currantrole = _RoleManager.Roles.Where(s => s.Name == role.Name).FirstOrDefault();
            if (!(await _userManager.IsInRoleAsync(userreterned, Currantrole.Name)))
            {

                var result2 = await _userManager.AddToRoleAsync(userreterned, Currantrole.Name);
            }

            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task<ApplicationUserDTO> DeleteUser(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ApplicationUserDTO>> ListUser()
        {
            var user = _userManager.Users;
            var mappedUser = _mapper.Map<IQueryable<ApplicationUserDTO>>(user);
            return await mappedUser.ToListAsync();
        }

        public async Task<RegistrationResponseDTO> Login(ApplicationUserDTO user)
        {
            // check if the user with the same email exist
            var existingUser = await _userManager.FindByEmailAsync(user.Email);

            if (existingUser == null)
            {
                // We dont want to give to much information on why the request has failed for security reasons
                return new RegistrationResponseDTO()
                {
                    Result = false,
                    Errors = new List<string>(){
                            "Invalid authentication request"
                        }
                };
            }

            // Now we need to check if the user has inputed the right password
            var isCorrect = await _userManager.CheckPasswordAsync(existingUser, user.Password);

            if (isCorrect)
            {
                var jwtToken = GenerateJwtToken(existingUser);

                return new RegistrationResponseDTO()
                {
                    Result = true,
                    Token = jwtToken,
                    Id = existingUser.Id
                };
            }
            else
            {
                // We dont want to give to much information on why the request has failed for security reasons
                return new RegistrationResponseDTO()
                {
                    Result = false,
                    Errors = new List<string>(){
                            "Invalid authentication request"
                        }
                };
            }
        }

        public Task<ApplicationUserDTO> UpdateUser(int Id, ApplicationUserDTO entity)
        {
            throw new NotImplementedException();
        }
        private string GenerateJwtToken(IdentityUser user)
        {
            // Now its ime to define the jwt token which will be responsible of creating our tokens
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            // We get our secret from the appsettings
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            // we define our token descriptor
            // We need to utilise claims which are properties in our token which gives information about the token
            // which belong to the specific user who it belongs to
            // so it could contain their id, name, email the good part is that these information
            // are generated by our server and identity framework which is valid and trusted
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim("Id", user.Id),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
               
                // the JTI is used for our refresh token which we will be convering in the next video
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }),
                // the life span of the token needs to be shorter and utilise refresh token to keep the user signedin
                // but since this is a demo app we can extend it to fit our current need
                Expires = DateTime.UtcNow.AddHours(6),
                // here we are adding the encryption alogorithim information which will be used to decrypt our token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);

            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
        public async Task<ApplicationUser> GetById (string id)
        {
            var user =await _userManager.FindByIdAsync(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
    }
}
