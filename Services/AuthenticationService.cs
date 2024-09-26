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
        //public async Task<string>LoginUser(UserLoginDto model)
        //{

          
        //        var user = await _userManager.FindByNameAsync(model.Email);
        //        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        //        {
        //        //var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("therearepeoplewhoarefitforworktherearepeoplewhoarefitforworktherearepeoplewhoarefitforworktherearepeoplewhoarefitforworktherearepeoplewhoarefitforwork"));
        //        var secretKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET")));
        //        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        //        var claimer = new[] { new Claim(ClaimTypes.NameIdentifier, user.UserName), new Claim(ClaimTypes.Role,"member") };
        //        var tokeOptions = new JwtSecurityToken(
        //            issuer: "https://localhost:5000",
        //            audience: "https://localhost:5000",
        //            claims: claimer,
        //            expires: DateTime.Now.AddMinutes(9),
        //            signingCredentials: signinCredentials
        //        );

        //        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        //        return tokenString;
        //    }

        //        return null;
        //    }

            //private JwtSecurityToken GenerateJwtToken(IEnumerable<Claim> claims)
            //{
            //    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            //    var token = new JwtSecurityToken(
            //        issuer: _configuration["Jwt:Issuer"],
            //        audience: _configuration["Jwt:Audience"],
            //        expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireMinutes"])),
            //        claims: claims,
            //        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            //    );

            //    return token;
            //}



        public async Task<bool> LoginUser(UserLoginDto userForAuth)
        {
            _user = await _userManager.FindByNameAsync(userForAuth.Email);
            var result = (_user != null && await _userManager.CheckPasswordAsync(_user,
           userForAuth.Password));
            if (!result)
                _logger.LogWarn($"{nameof(LoginUser)}: Authentication failed. Wrong user                name or password.");
 return result;
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
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("therearepeoplewhoarefitforworktherearepeoplewhoarefitforworktherearepeoplewhoarefitforworktherearepeoplewhoarefitforworktherearepeoplewhoarefitforwork"));
            //var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            //var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        }
        private async Task<List<Claim>> GetClaims()
        { 
            var claims = new List<Claim> {new Claim(ClaimTypes.Name, _user.UserName)
 };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
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
