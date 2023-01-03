using MARIHUBtask.Domin.Models;
using MARIHUBtask.DTO.DTOs;
using MARIHUBtask.DTO.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIHUBtask.Services.Abstraction
{
    public interface IUserMangementService
    {
        Task<List<ApplicationUserDTO>> ListUser ();      
        Task<bool>CreateUser (ApplicationUserDTO entity);
        Task<RegistrationResponseDTO> Login (ApplicationUserDTO entity);
        Task<ApplicationUserDTO> UpdateUser (int Id, ApplicationUserDTO entity);
        Task<ApplicationUserDTO> DeleteUser (int Id);
        Task<ApplicationUser> GetById(string id);

    }
}
