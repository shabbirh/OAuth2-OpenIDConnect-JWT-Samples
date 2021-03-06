﻿using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServerAuthority.Configurations
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("Api1", "Warehouse Api")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client1",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("123654".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = {"Api1"}
                },
                new Client
                {
                    ClientId = "ro.client1",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("123654".Sha256())
                    },
                    AllowedScopes = {"Api1"}
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "mosalla",
                    Password = "password",
                    Claims = new[]
                    {
                        new Claim("Employee", "Mosalla"),
                        new Claim("website", "http://hamidmosalla.com")
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password",
                    Claims = new[]
                    {
                        new Claim("Employee", "Bob"),
                        new Claim("website", "https://bob.com")
                    }
                }
            };
        }
    }
}