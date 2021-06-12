using Application.Settings;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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
        private readonly JwtSettings _jwtSettings;

        public JwtManager(BugTrackerContext context, IOptions<JwtSettings> jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings.Value;
        }

        public string MakeToken(string email) 
        {
            var user = _context.ApplicaitonUsers.Include(au => au.RoleCases)
                .FirstOrDefault(x => x.Email == email);

            var actor = new JwtActor
            {
                Id = user.Id,
                AllowedUseCases = user.RoleCases.Select(x => x.UseCaseId),
                Identity = user.Email
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim> 
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString(), ClaimValueTypes.String, _jwtSettings.Issuer),
                new Claim(JwtRegisteredClaimNames.Iss, "asp_api", ClaimValueTypes.String, _jwtSettings.Issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _jwtSettings.Issuer),
                new Claim("UserId", actor.Id.ToString(), ClaimValueTypes.String, _jwtSettings.Issuer),
                new Claim("ActorData", JsonConvert.SerializeObject(actor), ClaimValueTypes.String, _jwtSettings.Issuer)
            };

            var now = DateTime.UtcNow;

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                notBefore: now,
                expires: now.AddHours(20),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
