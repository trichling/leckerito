// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace leckerito.identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId()
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[] 
            { 
                new ApiResource("leckerito.lunchero.Ordering", "The ordering API for lunchero."),
                new ApiResource("leckerito.lunchero.Pricing", "The pricing API for lunchero."),
                new ApiResource("leckerito.lunchero.Warehouse", "The warehouse API for lunchero."),
                new ApiResource("leckerito.lunchero.Delivery", "The delivery API for lunchero."),
            };
        
        public static IEnumerable<Client> Clients =>
            new Client[] 
            { 
                new Client
                {
                    ClientId = "lunchero.web",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "leckerito.lunchero.Pricing", "leckerito.lunchero.Warehouse" }
                }

            };
        
    }
}