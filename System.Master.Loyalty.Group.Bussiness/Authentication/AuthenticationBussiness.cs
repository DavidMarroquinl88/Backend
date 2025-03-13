using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Master.Loyalty.Group.Data;
using System.Master.Loyalty.Group.Data.Model.Config;
using System.Master.Loyalty.Group.Entities.Authentication;
using System.Master.Loyalty.Group.Entities.Authentication.Claims;
using System.Security.Claims;
using System.Text;

namespace System.Master.Loyalty.Group.Bussiness.Authentication
{
    public class AuthenticationBussiness : IAuthenticationBussiness
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JWTSettings _jwtSettings;

        public AuthenticationBussiness(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JWTSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var authResponse = new AuthResponse();

            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email) ?? throw new ApplicationException($"El usuario con email {request.Email} no existe");

                var resultado = await _signInManager.PasswordSignInAsync(user.UserName!, request.Password, false, false);

                if (!resultado.Succeeded)
                    throw new ApplicationException($"Las credenciales son incorrecta");

                var roles = await _userManager.GetRolesAsync(user) ?? [];

                if (roles.Count <= 0)
                    throw new ApplicationException("El usuario no tiene asignado un rol");

                var token = await GenerateToken(user);

                if (token == null)
                    throw new ApplicationException("El token de seguridad no se generó correctamente");

                authResponse = new AuthResponse()
                {
                    Id = user.Id,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Email = user.Email!,
                    User = user.UserName!,
                    FullName = user.Nombre,
                    RoleName = roles.First(),
                    IsSuccess = true
                };
            }
            catch (ApplicationException ex)
            {
                authResponse.MessageError = ex.Message;
                authResponse.IsSuccess = false;
            }
            catch (Exception ex)
            {
                authResponse.MessageError = "Oucrrió un error al ingresar credenciales, por favor, comunicate con el administrador";
                authResponse.IsSuccess = false;
            }

            return authResponse;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var resultResponse = new RegistrationResponse();

            try
            {
                var existingUser = await _userManager.FindByEmailAsync(request.Email);

                if (existingUser != null)
                    throw new ApplicationException($"El correo ya se encuentra registrado");

                var user = new ApplicationUser
                {
                    Email = request.Email,
                    UserName = request.Email,
                    Nombre = request.FullName,
                    Direccion = request.Direccion,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "cliente");
                    var token = await GenerateToken(user);

                    resultResponse = new RegistrationResponse()
                    {
                        Id = user.Id,
                        FullName = user.Nombre,
                        Email = user.Email,
                        User = user.UserName,
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        IsSuccess = true
                    };

                    return resultResponse;
                }

                throw new ApplicationException($"Error al crear usuario, por favor, comunícate con el administrador");
            }
            catch (ApplicationException ex)
            {
                resultResponse.MessageError = ex.Message;
                resultResponse.IsSuccess = false;
            }
            catch (Exception ex)
            {
                resultResponse.MessageError = "Ocurrió un error al registrar usuario, comunícate con el administrador";
                resultResponse.IsSuccess = false;
            }

            return resultResponse;
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            foreach (var role in roles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(CustomClaimTypes.Uid,user.Id.ToString())
            }.Union(userClaims).Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                    issuer: _jwtSettings.Issuer,
                    audience: _jwtSettings.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                    signingCredentials: signingCredentials);


            return jwtSecurityToken;
        }
    }
}

