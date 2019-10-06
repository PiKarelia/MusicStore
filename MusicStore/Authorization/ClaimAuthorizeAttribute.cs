using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Authorization
{
    public class ClaimAuthorizeAttribute : AuthorizeAttribute
    {
        public IEnumerable<string> ClaimValues { get; }

        public string ClaimType { get; }

        public ClaimAuthorizeAttribute(object claimType, params object[] claimValues)
        {
            ClaimType = claimType.ToString();

            ClaimValues = claimValues?.Select(s => s.ToString()).ToList() ?? new List<string>();
        }
    }
}
