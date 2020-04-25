using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace MyShop.Backend.IdentityServer
{
    public class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource("api.myshop", "MyShop API")
            };

        public static IEnumerable<Client> Clients(Dictionary<string, string> clientUrls) =>
            new []
            {
                new Client
                {
                    ClientId = "ro.client",
                    ClientName = "Resource Owner Client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "api.myshop" }
                },
                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,
                    RequireConsent = false,
                    RequirePkce = true,
                    AllowOfflineAccess = true,

                    RedirectUris = { $"{clientUrls["Mvc"]}/signin-oidc" },
                    PostLogoutRedirectUris = { $"{clientUrls["Mvc"]}/signout-callback-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "api.myshop"
                    }
                 },
                new Client
                {
                    ClientId = "blazor",
                    //ClientSecrets = { new Secret("secret".Sha256()) },
                    RequireClientSecret = false,

                    AllowedGrantTypes = GrantTypes.Code,
                    RequireConsent = false,
                    RequirePkce = true,
                    AllowOfflineAccess = true,

                    RedirectUris = { $"{clientUrls["Blazor"]}/authentication/login-callback" },
                    PostLogoutRedirectUris = { $"{clientUrls["Blazor"]}/" },

                    AllowedCorsOrigins = new List<string>
                    {
                        $"{clientUrls["Blazor"]}"
                    },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "api.myshop"
                    }
                 },
                new Client
                {
                    ClientId = "swagger",
                    ClientName = "Swagger Client",

                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,

                    RedirectUris =           { $"{clientUrls["Swagger"]}/swagger/oauth2-redirect.html" },
                    PostLogoutRedirectUris = { $"{clientUrls["Swagger"]}/swagger/oauth2-redirect.html" },
                    AllowedCorsOrigins =     { $"{clientUrls["Swagger"]}" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api.myshop"
                    }
                },
                new Client
                {
                    ClientName = "angular_code_client",
                    ClientId = "angular_code_client",
                    AccessTokenType = AccessTokenType.Reference,
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowAccessTokensViaBrowser = true,

                    RequireClientSecret = false,
                    RequireConsent = false,
                    RequirePkce = true,

                    RedirectUris = new List<string>
                    {
                        $"{clientUrls["Angular"]}/authentication/login-callback",
                        $"{clientUrls["Angular"]}/silent-renew.html",
                        $"{clientUrls["Angular"]}"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        $"{clientUrls["Angular"]}/unauthorized",
                        $"{clientUrls["Angular"]}/authentication/logout-callback",
                        $"{clientUrls["Angular"]}"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        $"{clientUrls["Angular"]}"
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api.myshop"
                    }
                },

                new Client
                {
                    ClientName = "react_code_client",
                    ClientId = "react_code_client",
                    AccessTokenType = AccessTokenType.Reference,
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowAccessTokensViaBrowser = true,

                    RequireClientSecret = false,
                    RequireConsent = false,
                    RequirePkce = true,

                    RedirectUris = new List<string>
                    {
                        $"{clientUrls["React"]}/authentication/login-callback",
                        $"{clientUrls["React"]}/silent-renew.html",
                        $"{clientUrls["React"]}"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        $"{clientUrls["React"]}/unauthorized",
                        $"{clientUrls["React"]}/authentication/logout-callback",
                        $"{clientUrls["React"]}"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        $"{clientUrls["React"]}"
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api.myshop"
                    }
                }
            };
    }
}

