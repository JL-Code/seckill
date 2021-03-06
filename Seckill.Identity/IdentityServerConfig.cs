﻿using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace Seckill.Identity
{
    public static class IdentityServerConfig
    {
        /// <summary>
        /// Gets the clients.
        /// </summary>
        public static ICollection<Client> GetClients()
        {
            var clients = new List<Client>();

            var mobileApp = new Client
            {
                // 客户端id 用于标识客户端
                ClientId = "seckill_id",
                ClientName = "seckill_name",
                // 客户端秘密 验证客户端是否为真实的客户端
                ClientSecrets = new List<Secret> {
                  new Secret("secret".Sha256())
                },
                // 设置的Uri将被授权服务器回调 回调同时返回令牌或授权码
                RedirectUris = { "http://localhost:8080/signin-oidc" },
                // 用户注销登录后跳转的Uri
                PostLogoutRedirectUris = { "http://localhost:5000/signout-callback-oidc" },
                // 允许客户端访问的范围
                AllowedScopes =  {
                  IdentityServerConstants.StandardScopes.OpenId,
                  IdentityServerConstants.StandardScopes.Profile
                },
                // 设置客户端授权模式
                AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                // 允许离线访问
                AllowOfflineAccess = true
            };

            clients.Add(mobileApp);
            return clients;
        }

        /// <summary>
        /// Gets the apis.
        /// </summary>
        public static ICollection<ApiResource> GetApis()
        {
            return new List<ApiResource>();
        }

        /// <summary>
        /// 获取身份资源
        /// </summary>
        /// <returns></returns>
        public static ICollection<IdentityResource> GetIdentityResources()
        {
            // 设置身份资源
            return new List<IdentityResource> {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        // 定义用户
        public static List<TestUser> GetUsers()
        {
            // [IdentityServer4实战 - 基于角色的权限控制及Claim详解]  (https://www.cnblogs.com/stulzq/p/8726002.html)
            return new List<TestUser>
              {
                new TestUser{
                   Username = "jiangy",
                   Password = "1",
                   // 区分client调用还是用户调用？
                   SubjectId ="用户ID",
                   IsActive = true,
                   Claims = new List<Claim>{
                      new Claim("sex","男"),
                      new Claim("company","重庆分公司"),
                      new Claim("role","项目总监")
                   }
                }
              };
        }
    }
}
