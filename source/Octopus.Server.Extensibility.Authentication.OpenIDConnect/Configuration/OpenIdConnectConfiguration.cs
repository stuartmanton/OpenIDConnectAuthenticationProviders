﻿using Newtonsoft.Json;
using Octopus.Server.Extensibility.HostServices.Model;

namespace Octopus.Server.Extensibility.Authentication.OpenIDConnect.Configuration
{
    public abstract class OpenIDConnectConfiguration : IOverridableId
    {
        public const string DefaultResponseType = "code+id_token";
        public const string DefaultResponseMode = "form_post";
        public const string DefaultScope = "openid%20profile%20email";
        public const string DefaultNameClaimType = "name";

        protected OpenIDConnectConfiguration()
        {
            ResponseType = DefaultResponseType;
            ResponseMode = DefaultResponseMode;
            Scope = DefaultScope;

            NameClaimType = DefaultNameClaimType;
        }

        [JsonIgnore]
        public string Id { get; protected set; }

        public bool IsEnabled { get; set; }

        public string Issuer { get; set; }

        public string ResponseType { get; set; }
        public string ResponseMode { get; set; }

        public string ClientId { get; set; }

        public string Scope { get; set; }

        public string NameClaimType { get; set; }

        public string LoginLinkLabel { get; set; }

        public void SetId(string id)
        {
            Id = id;
        }
    }
}