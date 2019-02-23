using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace SecKill.Infrastructure
{
    public static class IdentityExtension
    {
        public static UserInfo ToUserInfo(this IIdentity identity)
        {
            UserInfo userInfo = null;
            try
            {
                if (!(identity is ClaimsIdentity cidentity))
                    throw new ArgumentNullException(nameof(identity));

                var dict = cidentity.Claims.ToDictionary(p => p.Type.ToLower(), c => c.Value);

                userInfo = new UserInfo
                {
                    UserId = dict.ContainsKey("id") ? new Guid(dict["id"]) : Guid.Empty,
                    UserName = dict.ContainsKey("name") ? dict["name"] : "",
                };

            }
            catch (Exception) { }

            return userInfo;
        }
    }

    /// <summary>
    /// 用户基本信息
    /// </summary>
    public class UserInfo
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }
    }
}
