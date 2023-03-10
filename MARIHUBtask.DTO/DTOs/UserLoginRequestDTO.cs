using System.ComponentModel.DataAnnotations;

namespace MARIHUBtask.DTO.Dto
{
    public class UserLoginRequestDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
