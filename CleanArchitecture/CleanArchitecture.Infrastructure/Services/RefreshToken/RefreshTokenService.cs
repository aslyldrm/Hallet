using CleanArchitecture.Core.DTOs.Account;
using CleanArchitecture.Core.Entities;

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Services
{
    public class RefreshTokenService
    {
   
        public RefreshToken GenerateRefreshToken()
        {

            var resfreshToken = new RefreshToken()
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                CreatedTime = DateTime.Now
            };

            return resfreshToken;
           

        }

        public string SetRefreshToken(RefreshToken newRefreshToken,string userId, DateTime accessTokenTime,
            int refreshTokenLifeTime)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };
            //Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);
            /*
            User user = 
            user.RefreshToken = newRefreshToken.Token;
            user.CreatedDate = newRefreshToken.CreatedTime;
            user.Expires = newRefreshToken.Expires;
            */
            return newRefreshToken.Token;
        }

    }
}
