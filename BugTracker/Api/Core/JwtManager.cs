using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core
{
    public class JwtManager
    {
        private readonly BugTrackerContext _context;

        public JwtManager(BugTrackerContext context)
        {
            _context = context;
        }

        public string MakeToken(string email) 
        {
            var user = _context.ApplicaitonUsers.Include(au => au.ApplicationUserCases)
                .FirstOrDefault(x => x.Email == email); //Hash password

            var actor = new JwtActor
            {
                Id = user.Id,
                AllowedUseCases = user.ApplicationUserCases.Select(x => x.UseCaseId),
                Identity = user.Email
            };

            var issuer = "asp_api";
            var secretKey = "ThisIsMyVerySecretKey";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim> 
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString(), ClaimValueTypes.String, issuer),
                new Claim(JwtRegisteredClaimNames.Iss, "asp_api", ClaimValueTypes.String, issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, issuer),
                new Claim("UserId", actor.Id.ToString(), ClaimValueTypes.String, issuer),
                new Claim("ActorData", JsonConvert.SerializeObject(actor), ClaimValueTypes.String, issuer)
            };

            var now = DateTime.UtcNow;

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(20),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
