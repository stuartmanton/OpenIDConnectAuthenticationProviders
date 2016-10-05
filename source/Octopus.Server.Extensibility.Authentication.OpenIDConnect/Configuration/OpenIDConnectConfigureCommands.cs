﻿using System;
using System.Collections.Generic;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration;
using Octopus.Server.Extensibility.HostServices.Diagnostics;

namespace Octopus.Server.Extensibility.Authentication.OpenIDConnect.Configuration
{
    public abstract class OpenIdConnectConfigureCommands<TStore> : IContributeToConfigureCommand
        where TStore : IOpenIDConnectConfigurationStore
    {
        protected readonly ILog Log;
        protected readonly Lazy<TStore> ConfigurationStore;

        protected OpenIdConnectConfigureCommands(ILog log, Lazy<TStore> configurationStore)
        {
            Log = log;
            ConfigurationStore = configurationStore;
        }

        protected abstract string ConfigurationSettingsName { get; }

        public virtual IEnumerable<ConfigureCommandOption> GetOptions()
        {
            yield return new ConfigureCommandOption($"{ConfigurationSettingsName}IsEnabled=", $"Set the {ConfigurationSettingsName} IsEnabled, used for authentication.", v =>
            {
                var isEnabled = bool.Parse(v);
                ConfigurationStore.Value.SetIsEnabled(isEnabled);
                Log.Info($"{ConfigurationSettingsName} IsEnabled set to: {isEnabled}");
            });
            yield return new ConfigureCommandOption($"{ConfigurationSettingsName}Issuer=", $"Set the {ConfigurationSettingsName} Issuer, used for authentication.", v =>
            {
                ConfigurationStore.Value.SetIssuer(v);
                Log.Info($"{ConfigurationSettingsName} Issuer set to: {v}");
            });
            yield return new ConfigureCommandOption($"{ConfigurationSettingsName}ResponseType=", $"Set the {ConfigurationSettingsName} ResponseType.", v =>
            {
                ConfigurationStore.Value.SetResponseType(v);
                Log.Info($"{ConfigurationSettingsName} ResponseType set to: {v}");
            });
            yield return new ConfigureCommandOption($"{ConfigurationSettingsName}ResponseMode=", $"Set the {ConfigurationSettingsName} ResponseMode.", v =>
            {
                ConfigurationStore.Value.SetResponseMode(v);
                Log.Info($"{ConfigurationSettingsName} ResponseMode set to: {v}");
            });
            yield return new ConfigureCommandOption($"{ConfigurationSettingsName}ClientId=", $"Set the {ConfigurationSettingsName} ClientId.", v =>
            {
                ConfigurationStore.Value.SetClientId(v);
                Log.Info($"{ConfigurationSettingsName} ClientId set to: {v}");
            });
            yield return new ConfigureCommandOption($"{ConfigurationSettingsName}Scope=", $"Set the {ConfigurationSettingsName} Scope.", v =>
            {
                ConfigurationStore.Value.SetScope(v);
                Log.Info($"{ConfigurationSettingsName} Scope set to: {v}");
            });
            yield return new ConfigureCommandOption($"{ConfigurationSettingsName}NameClaimType=", $"Set the {ConfigurationSettingsName} NameClaimType.", v =>
            {
                ConfigurationStore.Value.SetNameClaimType(v);
                Log.Info($"{ConfigurationSettingsName} NameClaimType set to: {v}");
            });
            yield return new ConfigureCommandOption($"{ConfigurationSettingsName}LoginLinkLabel=", $"Set the {ConfigurationSettingsName} LoginLinkLabel.", v =>
            {
                ConfigurationStore.Value.SetLoginLinkLabel(v);
                Log.Info($"{ConfigurationSettingsName} LoginLinkLabel set to: {v}");
            });
        }
    }
}