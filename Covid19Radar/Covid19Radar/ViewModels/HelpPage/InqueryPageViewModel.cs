﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Covid19Radar.Resources;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Covid19Radar.ViewModels
{
    public class InqueryPageViewModel : ViewModelBase
    {

        public InqueryPageViewModel() : base()
        {
        }

        public Command OnClickSite1 => new Command(async () =>
        {
            var uri = "https://github.com/Covid-19Radar/Covid19Radar";
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        });

        public Command OnClickSite2 => new Command(async () =>
        {
            var uri = "https://github.com/Covid-19Radar/Covid19Radar";
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        });

        public Command OnClickSite3 => new Command(async () =>
        {
            var uri = "https://github.com/Covid-19Radar/Covid19Radar";
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        });

        public Command OnClickEmail => new Command(async () =>
        {
            // Device Model (SMG-950U, iPhone10,6)
            var device = DeviceInfo.Model;

            // Manufacturer (Samsung)
            var manufacturer = DeviceInfo.Manufacturer;

            // Operating System Version Number (7.0)
            var version = DeviceInfo.VersionString;

            // Platform (Android)
            var platform = DeviceInfo.Platform;

            var device_info = "DEVICE_INFO : " + AppSettings.Instance.AppVersion + "," + device + "("+ manufacturer + ")," + platform + "," + version;
            Debug.WriteLine("DEVICE_INFO : " + device_info);

            try
            {
                List<string> recipients = new List<string>();
                recipients.Add(AppSettings.Instance.SupportEmail);
                var message = new EmailMessage
                {
                    Subject = AppResources.InqueryMailSubject,
                    Body = device_info + "\r\n" + AppResources.InqueryMailBody.Replace("\\r\\n", "\r\n"),
                    To = recipients
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException)
            {
                // Email is not supported on this device
                // TODO: Add a code to handle the exception
            }
            catch (Exception) {
                // Some other exception occurred
                // TODO: Add a code to handle the exception
            }
        });
    }
}
