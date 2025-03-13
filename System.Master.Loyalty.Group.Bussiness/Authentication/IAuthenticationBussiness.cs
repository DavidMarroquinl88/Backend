using System.Master.Loyalty.Group.Entities.Authentication;

namespace System.Master.Loyalty.Group.Bussiness.Authentication
{
    public interface IAuthenticationBussiness
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
