using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AspNet.Security.OpenIdConnect.Extensions;
using AspNet.Security.OpenIdConnect.Primitives;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Performance.Web
{
    public static class AuthServer
    {
        public const string SecretKey = "my_secretkey_123!";

        // Source: https://github.com/aspnet-contrib/AspNet.Security.OpenIdConnect.Server
        public static void AddAuthenticationServer(this IServiceCollection services)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

            services.AddAuthentication().AddOpenIdConnectServer(options =>
            {
                options.AccessTokenHandler = new JwtSecurityTokenHandler();
                options.SigningCredentials.AddKey(signingKey);

                options.AllowInsecureHttp = true;
                options.TokenEndpointPath = "/token";

                options.Provider = new AuthOpenIdConnectServerProvider();
            });
        }
        
    }
}
