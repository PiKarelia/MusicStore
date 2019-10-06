using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Authorization
{
    public class ClaimRequirement : IAuthorizationRequirement
    {
        public IEnumerable<string> ClaimValues { get; }

        public string ClaimType { get; }

        public ClaimRequirement(object claimType, params object[] claimValues)
        {
            ClaimType = claimType.ToString();

            ClaimValues = claimValues?.Select(s => s.ToString()).ToList() ?? new List<string>();
        }
    }
}
