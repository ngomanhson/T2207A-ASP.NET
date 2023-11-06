using System;
using Microsoft.AspNetCore.Authorization;
namespace T2207A_API.Requirements
{
    public class YearOldRequirements : IAuthorizationRequirement
    {
        public YearOldRequirements(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public int Min { get; set; }
        public int Max { get; set; }
    }
}
