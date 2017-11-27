using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNet.Security.OpenIdConnect.Extensions;
using AspNet.Security.OpenIdConnect.Primitives;
using AspNet.Security.OpenIdConnect.Server;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Performance.Models.Security;
using Performance.Utilities.Security;
//using PerformanceWeb.DataAccess.Security;

namespace Performance.Web
{
    public class AuthOpenIdConnectServerProvider : OpenIdConnectServerProvider
    {
        public override Task ValidateTokenRequest(ValidateTokenRequestContext context)
        {
            context.Validate();
            return Task.CompletedTask;
        }

        public override async Task HandleTokenRequest(HandleTokenRequestContext context)
        {
            var username = context.Request.Username;
            var password = context.Request.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                CreateInvalidGrantResponse(context);
                return;
            }

            Users user = null;

            var security = (SecurityContext)context.HttpContext.RequestServices.GetService(typeof(SecurityContext));


            var userQuery = from u in security.Users
                            where u.Username == username && (u.IsActive ?? false)
                            select u;

            user = await userQuery.FirstOrDefaultAsync();


            if (user == null)
            {
                CreateInvalidGrantResponse(context);
                return;
            }


            var salt = user.Salt;
            var userPasswordHash = user.Password;
            var enteredPasswordHash = PasswordHashHelper.EncodePassword(password, salt);

            if (!userPasswordHash.Equals(enteredPasswordHash))
            {
                CreateInvalidGrantResponse(context);
                return;
            }

            var identity = new ClaimsIdentity(context.Scheme.Name,
            OpenIdConnectConstants.Claims.Name,
            OpenIdConnectConstants.Claims.Role);

            identity.AddClaim(ClaimTypes.NameIdentifier, user.Id.ToString("N"),
             OpenIdConnectConstants.Destinations.AccessToken,
            OpenIdConnectConstants.Destinations.IdentityToken);

            identity.AddClaim(OpenIdConnectConstants.Claims.Subject, user.Id.ToString("N"),
             OpenIdConnectConstants.Destinations.AccessToken,
            OpenIdConnectConstants.Destinations.IdentityToken);

            identity.AddClaim(ClaimTypes.Name, user.Username,
            OpenIdConnectConstants.Destinations.AccessToken,
            OpenIdConnectConstants.Destinations.IdentityToken);

            identity.AddClaim(ClaimTypes.Uri, "https://abs.twimg.com/sticky/default_profile_images/default_profile_400x400.png",
            OpenIdConnectConstants.Destinations.AccessToken,
            OpenIdConnectConstants.Destinations.IdentityToken);

            var ticket = new AuthenticationTicket(
            new ClaimsPrincipal(identity),
            new AuthenticationProperties(),
            context.Scheme.Name);

            ticket.SetScopes(
                OpenIdConnectConstants.Scopes.Profile,
                OpenIdConnectConstants.Scopes.OfflineAccess);

            context.Validate(ticket);
        }

        private static void CreateInvalidGrantResponse(HandleTokenRequestContext context)
        {
            context.Reject(
                    error: OpenIdConnectConstants.Errors.InvalidGrant,
                    description: "Invalid user credentials.");
        }
    }
}
