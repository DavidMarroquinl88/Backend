using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace System.Master.Loyalty.Group.Bussiness.Common
{
    public class HttpContextUtility : IHttpContextUtility
    {
        private readonly IHttpContextAccessor _currentHttpContext;
        private readonly IHostingEnvironment _env;

        /// <summary>
        /// 
        /// </summary>
        public HttpContextUtility(IHttpContextAccessor currentHttpContext, IHostingEnvironment env)
        {
            _currentHttpContext = currentHttpContext;
            _env = env;
        }

        /// <summary>
        /// Get Base Url
        /// </summary>
        /// <returns></returns>
        public string GetBaseUrl()
        {
            var request = _currentHttpContext.HttpContext.Request;

            var host = request.Host.ToUriComponent();

            var pathBase = request.PathBase.ToUriComponent();

            return $"{request.Scheme}://{host}{pathBase}";//prod
        }

        /// <summary>
        /// Get Web Root Path
        /// </summary>
        /// <returns></returns>
        public string GetWebRootPath()
        {
            return _env.WebRootPath;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public System.Security.Claims.ClaimsPrincipal GetCurrentUser()
        {
            return _currentHttpContext.HttpContext.User;
        }

    }
}
