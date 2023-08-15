using CleanArchitecture.Core.DTOs.Account;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Users.Command.LoginUser
{
    public class AuthenticationHandler : IRequestHandler<AuthenticationRequest, AuthenticationResponse>
    {
        readonly IUserReadRepository _userReadRepository;
        readonly IUserWriteRepository _userWriteRepository;

        private readonly IConfiguration _confiquration;
      //  private readonly RefreshTokenService refreshTokenService;

        public AuthenticationHandler(IUserReadRepository userReadRepository, IConfiguration confiquration, 
            IUserWriteRepository userWriteRepository)
        {
            _userReadRepository = userReadRepository;
            _confiquration = confiquration;
            _userWriteRepository = userWriteRepository;
        }

        public async Task<AuthenticationResponse> Handle(AuthenticationRequest request, CancellationToken cancellationToken)
        {

            var user = await _userReadRepository.GetWhere(data => data.Email == request.Email, tracking: false).FirstOrDefaultAsync();
            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            AuthenticationResponse response = new();
            response.Id = (user.Id).ToString();
            string token = CreateToken(response, request.Email);
            response.Token = token;

            var refreshToken = GenerateRefreshToken();
            SetRefreshToken(refreshToken,user);
            user.RefreshToken = refreshToken.Token;
            user.Expires = refreshToken.Expires;
            user.CreatedDate = refreshToken.CreatedTime;
            response.RefreshToken = refreshToken.Token;
            response.RefreshTokenExpires = refreshToken.Expires;
            _userWriteRepository.Update(user);
             await _userWriteRepository.SaveAsync();
          
            return response;

        }

        private string CreateToken(AuthenticationResponse response, string email)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email,email)
            };
            
          
            var key = new SymmetricSecurityKey(System.Text.Encoding.
                UTF8.GetBytes(_confiquration.GetSection("AppSettings:Token").Value));
            

            var creds = new SigningCredentials(key
                ,SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials:creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            
        
           return jwt;
         


        }

        private bool VerifyPasswordHash(string password, byte[] storedPasswordHash, byte[] storedPasswordSalt)
        {


            using (var hmac = new HMACSHA512(storedPasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(storedPasswordHash);
            }
        }


        private RefreshToken GenerateRefreshToken()
        {
            byte[] randomBytes = new byte[64];
            RandomNumberGenerator.Fill(randomBytes);
            string base64Random = Convert.ToBase64String(randomBytes);


            var resfreshToken = new RefreshToken()
            {
                Token =  base64Random,
                Expires = DateTime.Now.AddDays(7),
                CreatedTime = DateTime.Now
            };

            return resfreshToken;


        }

        private void SetRefreshToken(RefreshToken newRefreshToken, User user)
        {
          
          
            user.RefreshToken = newRefreshToken.Token;
            user.CreatedDate = newRefreshToken.CreatedTime;
            user.Expires = newRefreshToken.Expires;
            
           
        }

    }
}


