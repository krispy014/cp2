
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
    public static class Utils
    {
        public static void Msgbox(string msg)
        {
            DependencyService.Get<Toast>().Show(msg);
        }
        public static string GetTimeString()
        {
            return DateTime.Now.ToString("HH:mm:ss tt");
        }

        public static Int32 time()
        {
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return unixTimestamp;
        }
    }
}