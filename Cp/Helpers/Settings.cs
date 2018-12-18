
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Cp.Helpers
{


    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        

        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
        public static string id
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>("id", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>("id", value);
            }
        }
        public static string pass
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>("pass", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>("pass", value);
            }
        }
        public static string token
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>("token", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>("token", value);
            }
        }

        public static DateTime AccessTokenExpirationDate
        {
            get
            {
                return AppSettings.GetValueOrDefault<DateTime>("AccessTokenExpirationDate", DateTime.UtcNow);
            }
            set
            {
                AppSettings.AddOrUpdateValue<DateTime>("AccessTokenExpirationDate", value);
            }
        }
    }
}