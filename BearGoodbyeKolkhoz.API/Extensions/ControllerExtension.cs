using System.Security.Claims;

namespace BearGoodbyeKolkhozProject.API.Extensions
{
    public static class ControllerExtension
    {
        public static int GetUserIdFromToken(this HttpContext context)
        {
            var identity = context.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var clientId = Convert.ToInt32(identity
                    .FindFirst(@"http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata").Value);
                return clientId;
            }
            throw new HttpRequestException();
        }
    }
}
