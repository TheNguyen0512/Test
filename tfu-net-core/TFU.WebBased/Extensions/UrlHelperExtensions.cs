using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Mvc
{
    public static class UrlHelperExtensions
    {
        public static string EmailConfirmationLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
         var url = urlHelper.Action(
                action: "ConfirmEmail",
                controller: "Accounts",
                values: new { userId, code },
                protocol: scheme);
         return url;
        }

        public static string ResetPasswordCallbackLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: "ResetPassword",
                controller: "Accounts",
                values: new { userId, code },
                protocol: scheme);
        }
    }
}
