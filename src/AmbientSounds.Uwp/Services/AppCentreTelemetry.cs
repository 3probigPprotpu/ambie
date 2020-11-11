﻿using AmbientSounds.Constants;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.Toolkit.Diagnostics;
using System.Collections.Generic;
using Windows.Globalization;

namespace AmbientSounds.Services.Uwp
{
    /// <summary>
    /// Telemetry service for app centre.
    /// </summary>
    public class AppCentreTelemetry : ITelemetry
    {
        private readonly IUserSettings _userSettings;

        public AppCentreTelemetry(IUserSettings userSettings)
        {
            Guard.IsNotNull(userSettings, nameof(userSettings));
            _userSettings = userSettings;
            AppCenter.SetCountryCode(new GeographicRegion().CodeTwoLetter);
            AppCenter.Start("", typeof(Analytics));
        }

        /// <inheritdoc/>
        public void TrackEvent(string eventName, IDictionary<string, string> properties = null)
        {
            if (_userSettings.Get<bool>(UserSettingsConstants.TelemetryOn))
            {
                Analytics.TrackEvent(eventName, properties);
            }
        }
    }
}