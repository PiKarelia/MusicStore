using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Authorization
{
    public class ClaimRequirementHandler : AuthorizationHandler<ClaimRequirement>
    {
        public ClaimRequirementHandler() { }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            ClaimRequirement requirement)
        {
            var claims = context
                .User
                .Claims
                .ToDictionary(
                    k => k.Type,
                    v => v.Value);

            if (Authorize(claims, requirement))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }

        private static bool Authorize(
            IReadOnlyDictionary<string, string> claims,
            ClaimRequirement requirement)
        {
            if (!claims.ContainsKey(requirement.ClaimType.ToLower()))
                return false;

            return requirement.ClaimValues == null
                || requirement.ClaimValues
                .All(claimValue => claims[requirement.ClaimType.ToLower()]
                .Contains(claimValue.ToLower()));
        }
    }

}
