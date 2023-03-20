using CleanArquitecture.Application.Constans;
using CleanArquitecture.Application.Contracts.Identity;
using CleanArquitecture.Application.Models.Identity;
using CleanArquitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArquitecture.Identity.Services
{
    public class AuthServices : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthServices(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value ;
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            ApplicationUser user  = await _userManager.FindByEmailAsync(request.Email);
            if (user == null) throw new Exception($"El usuario con email {request.Email} no existe");
            SignInResult result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false,lockoutOnFailure: false);
            if (!result.Succeeded) throw new Exception($"Las credenciales son incorrectas");

            JwtSecurityToken token = await GenerateToken(user);
            AuthResponse auhtResponse = new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Email = user.Email,
                Username = user.UserName
            };
            return auhtResponse;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            ApplicationUser existingUser = await _userManager.FindByNameAsync(request.Username);
            if (existingUser != null) throw new Exception($"El usuario {request.Username} ya existe");
            ApplicationUser existingEmail = await _userManager.FindByEmailAsync(request.Email);
            if (existingEmail != null) throw new Exception($"El email {request.Email} ya existe");
            ApplicationUser user = new ApplicationUser
            {
                Email = request.Email,
                Name = request.Name,
                Lastname = request.LastName,
                UserName = request.Username,
                EmailConfirmed = true
            };
            IdentityResult result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Operator");
                JwtSecurityToken token = await GenerateToken(user);
                return new RegistrationResponse 
                {
                    Email = user.Email,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    UserId= user.Id,
                    Username= user.UserName
                };
            }
            throw new Exception($"{result.Errors}");
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            IList<Claim> userClaims = await _userManager.GetClaimsAsync(user);
            IList<string> roles = await _userManager.GetRolesAsync(user);

            List<Claim> roleClaims = new List<Claim>();

            foreach(var role in roles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            IEnumerable<Claim> claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(CustomClainTypes.Uid, user.Id)
            }.Union(userClaims).Union(roleClaims);

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            SigningCredentials signingCrredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                    issuer: _jwtSettings.Issuer,
                    audience: _jwtSettings.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                    signingCredentials: signingCrredentials
                );
            return jwtSecurityToken;
        }
    }
}
