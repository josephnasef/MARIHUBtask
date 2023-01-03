using MARIHUBtask.DTO.Dto;

namespace MARIHUBtask.Services.configuration
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, ApplicationUserDTO user);
        //string GenerateJSONWebToken(string key, string issuer, ApplicationUserDTO user);
        bool IsTokenValid(string key, string issuer, string token);
    }
}
