using System;
using Microsoft.AspNetCore.Authorization;
using T2207A_API.Requirements;
using System.Security.Claims;
using T2207A_API.Entities;

namespace T2207A_API.Handlers
{
    public class ValidYearOldHandler : AuthorizationHandler<YearOldRequirements>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, YearOldRequirements requirement)
        {
            if (IsValidYearOld(context.User, requirement))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }

        private bool IsValidYearOld(ClaimsPrincipal user,
                YearOldRequirements requirement)
        {
            if (user == null)
                return false;
            var userID = user.FindFirstValue(ClaimTypes.NameIdentifier);
            var _context = new T2207aApiContext();
            var userData = _context.Users.Find(Convert.ToInt32(userID));
            if (userData == null || userData.Age == null)
                return false;
            if (userData.Age >= requirement.Min &&
                userData.Age <= requirement.Max)
                return true;
            return false;
        }
    }
}
