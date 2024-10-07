using AutoMapper;
using Contracts;
using Contracts.ServiceContracts;
using Microsoft.AspNetCore.Identity;
using Entities.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Shared.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Xml.Linq;
using Entities.BaseModels;

namespace Services
{
    internal sealed class AuthenticationService:IAuthenticationService
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private User? _user;


        public AuthenticationService(ILoggerManager logger,IMapper mapper,UserManager<User> userManager,IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IdentityResult> RegisterUser(UserRegistrationDto userRegistrationDto)
        {
            User user = new();
             user = _mapper.Map<User>(userRegistrationDto);
            var result = await _userManager.CreateAsync(user, userRegistrationDto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, userRegistrationDto.Roles);

            }
            return result;


        }
        public async Task<LoggedInUser> LoginUser(UserLoginDto userForAuth)
        {
            _user = await _userManager.FindByNameAsync(userForAuth.Email);
            
            var result = (_user != null && await _userManager.CheckPasswordAsync(_user,
           userForAuth.Password));
            if (!result)
                _logger.LogWarn($"{nameof(LoginUser)}: Authentication failed. Wrong user                name or password.");
 return new LoggedInUser { IsAuthenticated = result, User = _user };
        }


        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
        private SigningCredentials GetSigningCredentials()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("therfitforworktheroarefitearepeoplewhoareforworkthearepeoplewhoarearepeoplewh"));
         
            return new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        }
        private async Task<List<Claim>> GetClaims()
        {
            var idClaim = new Claim(ClaimTypes.Actor,_user.Id);
            var claims = new List<Claim> {new Claim(ClaimTypes.Email, _user.UserName) };

            var roles = await _userManager.GetRolesAsync(_user);
            var role = roles.FirstOrDefault();
            if (role != null)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            claims.Add( new Claim(ClaimTypes.Actor, _user.Id));
            claims.Add(new Claim(ClaimTypes.Name, $"{_user.FirstName} {_user.LastName}"));
            //foreach (var role in roles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role));
            //}
            return claims;
        }


        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials,
               List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken
            (
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }

    }
}
