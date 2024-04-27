using DTO.Request.Login;
using DTO.Response;
using DTO.Response.Login;

namespace Business.Interfaces.Login
{
    public interface ILoginBLL
    {
        Task<GenericResponse<LoginResponse>> Login(LoginRequest loginRequest);
    }
}
