﻿using Octopus.Diagnostics;
using Octopus.Server.Extensibility.Authentication.AzureAD.Configuration;
using Octopus.Server.Extensibility.Authentication.AzureAD.Issuer;
using Octopus.Server.Extensibility.Authentication.OpenIDConnect.Issuer;
using Octopus.Server.Extensibility.Authentication.OpenIDConnect.Web;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api;

namespace Octopus.Server.Extensibility.Authentication.AzureAD.Web
{
    public class AzureADUserAuthenticationAction : UserAuthenticationAction<IAzureADConfigurationStore>
    {
        public AzureADUserAuthenticationAction(
            ILog log,
            IAzureADConfigurationStore configurationStore, 
            IIdentityProviderConfigDiscoverer identityProviderConfigDiscoverer, 
            IAzureADAuthorizationEndpointUrlBuilder urlBuilder,
            IApiActionResponseCreator responseCreator) : base(log, configurationStore, identityProviderConfigDiscoverer, urlBuilder, responseCreator)
        {
        }
    }
}