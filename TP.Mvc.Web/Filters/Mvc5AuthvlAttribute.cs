using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace TP.Mvc.Web.Filters
{
    public class Mvc5AuthvlAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            //角色应该由当前context获取
            filterContext.Principal = new GenericPrincipal(filterContext.HttpContext.User.Identity, new[] { "Admin" });
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            //获取客户端用户，并确认是否验证通过，如果没验证通过，则通过HttpUnauthorizedResult重定向到登录页面
            var user = filterContext.HttpContext.User;
            if (user == null && !user.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult(); //表示未授权的http请求结果
            }
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //throw new NotImplementedException();
        }
    }
}