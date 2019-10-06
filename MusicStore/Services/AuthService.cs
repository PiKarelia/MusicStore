using Microsoft.EntityFrameworkCore;
using MSt.Context;
using MSt.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MusicStore.Services
{
    public class AuthService
    {
        private readonly MusicStoreDbContext _dbContext;
        private readonly JwtHelper _jwtHelper;
        private readonly Encryptor _encryptor;

        public AuthService(MusicStoreDbContext dbContext, JwtHelper jwtHelper, Encryptor encryptor)
        {
            _dbContext = dbContext;
            _jwtHelper = jwtHelper;
            _encryptor = encryptor;
        }

        public async Task<string> LoginAsync(LoginModel obj)
        {
            obj.Password = _encryptor.MD5Hash(obj.Password);

            var user = await _dbContext
                .Users
                .Include(i => i.UserClaims)
                .Include(i => i.UserRoles)
                .ThenInclude(i => i.Role)
                .ThenInclude(i => i.RoleClaims)
                .AsNoTracking()
                .FirstAsync(a => (a.Email == obj.Login || a.Login == obj.Login)
                                      && a.Password == obj.Password);

            var userRoleClaims = user.UserRoles
                .SelectMany(x => x.Role.RoleClaims)
                .GroupBy(g => g.ClaimType)
                .Select(claim => new Claim(
                    claim.Key.ToLower(),
                    string.Join(',', claim.Select(x => x.ClaimValue.ToLower()).Distinct())
                    ))
                .ToList();

            var userClaims = user
                .UserClaims
                .GroupBy(g => g.ClaimType)
                .Select(claim => new Claim(
                    claim.Key.ToLower(),
                    string.Join(',', claim
                        .Select(s => s.ClaimValue.ToLower())
                        .Distinct()
                    )))
                .ToList();

            userRoleClaims.RemoveAll(w => userClaims.Any(c => c.Type == w.Type));

            return _jwtHelper.CreateAccessToken(user, userRoleClaims.Concat(userClaims));
        }
    }
}
