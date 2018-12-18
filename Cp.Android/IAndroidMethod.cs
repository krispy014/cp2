using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cp.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidMethods))]
namespace Cp.Droid
{
    public class AndroidMethods : IAndroidMethods
    {
        public void CloseApp()
        {
            //Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}