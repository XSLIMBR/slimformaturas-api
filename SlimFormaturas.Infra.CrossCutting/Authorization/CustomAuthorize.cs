using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace SlimFormaturas.Infra.CrossCutting.Identity.Authorization {
    public class CustomAuthorize {
        public class ClaimsAuthorizeAttribute : TypeFilterAttribute {
            public ClaimsAuthorizeAttribute(string claimName, string claimValue) : base (typeof(RequisitoClaimFilter)) {
                Arguments = new object[] { new Claim(claimName,claimValue)};
            }
        }
        public static bool ValidarClaimsUsuario(HttpContext context, string claimName, string claimValue) {
            return context.User.Identity.IsAuthenticated
                && context.User.Claims.Any(c => c.Type == claimName && c.Value.Split(',').Contains(claimValue));
        }
    }
}
