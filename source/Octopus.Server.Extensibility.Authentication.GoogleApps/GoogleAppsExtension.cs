﻿using Autofac;
using Octopus.Server.Extensibility.Authentication.Extensions;
using Octopus.Server.Extensibility.Authentication.GoogleApps.Configuration;
using Octopus.Server.Extensibility.Authentication.GoogleApps.Issuer;
using Octopus.Server.Extensibility.Authentication.GoogleApps.Tokens;
using Octopus.Server.Extensibility.Authentication.GoogleApps.Web;
using Octopus.Server.Extensibility.Authentication.OpenIDConnect;
using Octopus.Server.Extensibility.Extensions;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Content;
using Octopus.Server.Extensibility.HostServices.Web;

namespace Octopus.Server.Extensibility.Authentication.GoogleApps
{
    [OctopusPlugin("GoogleApps", "Octopus Deploy")]
    public class GoogleAppsExtension : OpenIDConnectExtension, IOctopusExtension
    {
        public override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<GoogleAppsConfigurationMapping>().As<IConfigurationDocumentMapper>().InstancePerDependency();

            builder.RegisterType<GoogleAppsConfigurationStore>()
                .As<IGoogleAppsConfigurationStore>()
                .As<IHasConfigurationSettings>()
                .InstancePerDependency();
            builder.RegisterType<GoogleAppsConfigureCommands>()
                .As<IContributeToConfigureCommand>()
                .As<IHandleLegacyWebAuthenticationModeConfigurationCommand>()
                .InstancePerDependency();

            builder.RegisterType<GoogleAppsAuthorizationEndpointUrlBuilder>().As<IGoogleAppsAuthorizationEndpointUrlBuilder>().InstancePerDependency();
            builder.RegisterType<GoogleAuthTokenHandler>().As<IGoogleAuthTokenHandler>().InstancePerDependency();

            builder.RegisterType<GoogleAppsHomeLinksContributor>().As<IHomeLinksContributor>().InstancePerDependency();
             
            builder.RegisterType<GoogleAppsStaticContentFolders>().As<IContributesStaticContentFolders>().InstancePerDependency();

            builder.RegisterType<GoogleCertificateJsonParser>().As<IGoogleCertificateJsonParser>().SingleInstance();
            builder.RegisterType<GoogleCertificateRetriever>().As<IGoogleCertificateRetriever>().SingleInstance();
            builder.RegisterType<GoogleAppsAuthorizationEndpointUrlBuilder>().As<IGoogleAppsAuthorizationEndpointUrlBuilder>().SingleInstance();

            builder.RegisterType<GoogleAppsUserAuthenticationAction>().AsSelf().InstancePerDependency();
            builder.RegisterType<GoogleAppsUserAuthenticatedAction>().AsSelf().InstancePerDependency();

            builder.RegisterType<GoogleAppsCSSContributor>().As<IContributesCSS>().InstancePerDependency();

            builder.RegisterType<GoogleAppsAuthenticationProvider>()
                .As<IAuthenticationProvider>()
                .As<IAuthenticationProviderWithGroupSupport>()
                .AsSelf()
                .InstancePerDependency();
        }
    }
}