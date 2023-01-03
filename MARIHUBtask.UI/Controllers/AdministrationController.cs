using MARIHUBtask.Domin.Models;
using MARIHUBtask.DTO.DTOs;
using MARIHUBtask.DTO.DTOs.Response;
using MARIHUBtask.Services.Abstraction;
using MARIHUBtask.Services.Services;
using MARIHUBtask.UI.Authorization;
using MARIHUBtask.UI.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Authorization;

namespace MARIHUBtask.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class administrationController : ControllerBase
    {
        private readonly IUserMangementService _userMangement;
        public administrationController(IUserMangementService userMangement)
        {
            _userMangement = userMangement;
        }
        [Authorize("First")]
        [HttpPost("Create")]       
        public async Task<bool> CreateUser(ApplicationUserDTO userDTO)
        {
            return await _userMangement.CreateUser(userDTO);
        }
        // first for admin
        [Authorize("First")]
        [HttpPost("GetAll")]       
        public async Task<IEnumerable<ApplicationUserDTO>> GetAllUser()
        {
            return await _userMangement.ListUser();
        }
        [HttpPost("Login")]
        public async Task<RegistrationResponseDTO> Login(ApplicationUserDTO userDTO)
        {
            var logind = await _userMangement.Login(userDTO);
            return logind;
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(string id)
        {
            // only admins can access other user records
            var currentUser = (ApplicationUser)HttpContext.Items["User"];
            //if (id != currentUser.Id && currentUser.Role != Role.Admin)
            //    return Unauthorized(new { message = "Unauthorized" });

            var user = _userMangement.GetById(id);
            return Ok(user);
        }
    }
}
