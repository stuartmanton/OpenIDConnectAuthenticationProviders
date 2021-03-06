﻿using Octopus.Diagnostics;
using Octopus.Server.Extensibility.Authentication.GoogleApps.Configuration;
using Octopus.Server.Extensibility.Authentication.GoogleApps.Issuer;
using Octopus.Server.Extensibility.Authentication.OpenIDConnect.Issuer;
using Octopus.Server.Extensibility.Authentication.OpenIDConnect.Web;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api;

namespace Octopus.Server.Extensibility.Authentication.GoogleApps.Web
{
    public class GoogleAppsUserAuthenticationAction : UserAuthenticationAction<IGoogleAppsConfigurationStore>
    {
        public GoogleAppsUserAuthenticationAction(
            ILog log,
            IGoogleAppsConfigurationStore configurationStore, 
            IIdentityProviderConfigDiscoverer identityProviderConfigDiscoverer, 
            IGoogleAppsAuthorizationEndpointUrlBuilder urlBuilder,
            IApiActionResponseCreator responseCreator) : base(log, configurationStore, identityProviderConfigDiscoverer, urlBuilder, responseCreator)
        {
        }
    }
}