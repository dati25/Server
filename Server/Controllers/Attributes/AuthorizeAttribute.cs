using JWT.Algorithms;
using JWT.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Server.Controllers.Attributes
{
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
//            try
//            {
//                string token = context.HttpContext.Request.Headers["Authorization"].ToString().Split(' ').Last();

//#pragma warning disable CS0618 // Type or member is obsolete
//                var json = JwtBuilder.Create()
//                         .WithAlgorithm(new HMACSHA256Algorithm())
//                         .WithSecret("MarcelJeGay123")
//                         .MustVerifySignature()
//                         .Decode(token);
//#pragma warning restore CS0618 // Type or member is obsolete
//            }
//            catch
//            {
//                context.Result = new JsonResult(new { message = "Invalid token" })
//                {
//                    StatusCode = StatusCodes.Status401Unauthorized
//                };
//            }
        }
    }
}
