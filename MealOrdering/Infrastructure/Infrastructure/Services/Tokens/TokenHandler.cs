﻿using Application.Commons.Abstractions.ExtarnalServices.Tokens;
using Application.Features.Auths.DTOs;
using Domain.Entities.Identity;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;

namespace Infrastructure.Services.Tokens
{
    public class TokenHandler(IConfiguration _configuration) : ITokenHandler
    {
        public TokenDTO CreateAccessToken(User user)
        {
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["JwtToken:SecurityKey"]));
            SigningCredentials? credentials = new(securityKey, SecurityAlgorithms.HmacSha256);
            DateTime expiry = DateTime.Now.AddDays(int.Parse(_configuration["JwtToken:ExpiryInDays"]));

            StringBuilder stringBuilder = new();
            stringBuilder.Append(user.FirstName);
            stringBuilder.Append(" ");
            stringBuilder.Append(user.LastName);

            Claim[]? claims = new[]
            {
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.Name,stringBuilder.ToString())
            };

            JwtSecurityToken? token = new(issuer: _configuration["JwtToken:Issuer"], audience: _configuration["JwtToken:Audience"], claims: claims, expires: expiry, signingCredentials: credentials);

            string tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
            return new(tokenStr, expiry, CreateRefreshToken());
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            return number.ToString();
        }
    }
}



