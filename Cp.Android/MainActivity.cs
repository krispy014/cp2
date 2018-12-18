using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ZXing.Mobile;
using Plugin.CurrentActivity;
using System.Threading.Tasks;
using Android.Content;
using Java.Lang;

namespace Cp.Droid
{
    [Activity(Label = "CP", Icon = "@mipmap/icon",
        Theme = "@style/MainTheme",
        //Theme = "@style/MyTheme.Splash",
        MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        public static MainActivity instance;
        public static Activity activity;

        public static MainActivity GetInstance()
        {
            return instance;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
                                                                                                                        
            //TabLayoutResource = Resource.Layout.aTab;
            //ToolbarResource = Resource.Layout.Tool;

            base.OnCreate(savedInstanceState);
            //ActionBar.SetIcon(Android.Resource.Drawable.transparent);


            // ERROR HANDLING {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;
            //AndroidEnvironment.UnhandledExceptionRaiser += (s, e) =>
            //{
            //    System.Diagnostics.Debug.WriteLine("AndroidEnvironment.UnhandledExceptionRaiser: {0}. IsTerminating: {1}", e.Exception, e.Handled);
            //    e.Handled = true;
            //};

            instance = this;
            MainActivity.activity = this;

            AndroidEnvironment.UnhandledExceptionRaiser += AndroidEnvironmentOnUnhandledExceptionRaiser;


            //AppDomain.CurrentDomain.UnhandledException += UnhandledException;
            //System.Threading.Tasks.TaskScheduler.UnobservedTaskException += UnobservedTaskException;


            //Xamarin.Forms.Forms.Init(this, savedInstanceState);
            //DisplayCrashReport();
            // }


            //if (Intent.GetBooleanExtra("crash", false))
            //{
                //Toast.MakeText(this, "App restarted after crash", ToastLength.Short).Show();
            //}

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            // camera, storage permission library
            CrossCurrentActivity.Current.Init(Application);

            // dont need to call (if you want to use MobileBarcodeScanner? pls uncomment)
            //MobileBarcodeScanner.Initialize(Application);
            
            LoadApplication(new App());

            //SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            //SupportActionBar.SetHomeButtonEnabled(true);         // Don't activate button behavior
            //SupportActionBar.SetDisplayHomeAsUpEnabled(true);    // Don't show back arrow
            //SupportActionBar.SetDisplayShowHomeEnabled(true);    // Don't show back arrow and icon
            
        }
        
        private void AndroidEnvironmentOnUnhandledExceptionRaiser(object sender, RaiseThrowableEventArgs raiseThrowableEventArgs)
        {
            restartApp();
        }

        private void restartApp()
        {
            var intent = new Intent(activity, typeof(MainActivity));
            intent.PutExtra("crash", true);
            intent.AddFlags(ActivityFlags.ClearTop | ActivityFlags.ClearTask | ActivityFlags.NewTask);

            var pendingIntent = PendingIntent.GetActivity(MainActivity.instance, 0, intent, PendingIntentFlags.OneShot);

            var mgr = (AlarmManager)MainActivity.instance.GetSystemService(Context.AlarmService);
            mgr.Set(AlarmType.Rtc, DateTime.Now.Millisecond + 100, pendingIntent);

            activity.Finish();

            JavaSystem.Exit(2);
        }

        protected override void Dispose(bool disposing)
        {
            AndroidEnvironment.UnhandledExceptionRaiser -= AndroidEnvironmentOnUnhandledExceptionRaiser;
            base.Dispose(disposing);
        }

        private void TaskSchedulerOnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs unobservedTaskExceptionEventArgs)
        {
            restartApp();
            //var newExc = new System.Exception("TaskSchedulerOnUnobservedTaskException", unobservedTaskExceptionEventArgs.Exception);
            //LogUnhandledException(newExc);
        }

        private void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            restartApp();

            //var newExc = new System.Exception("CurrentDomainOnUnhandledException", unhandledExceptionEventArgs.ExceptionObject as System.Exception);
            //LogUnhandledException(newExc);
        }

        internal static void LogUnhandledException(System.Exception exception)
        {
            try
            {

                const string errorFileName = "Fatal.log";
                var errorMessage = System.String.Format("Time: {0}\r\nError: Unhandled Exception\r\n{1}", DateTime.Now, exception.ToString());
                //var libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // iOS: Environment.SpecialFolder.Resources
                //var errorFilePath = Path.Combine(libraryPath, errorFileName);
                //var errorMessage = String.Format("Time: {0}\r\nError: Unhandled Exception\r\n{1}",
                //DateTime.Now, exception.ToString());
                //File.WriteAllText(errorFilePath, errorMessage);

                // Log to Android Device Logging.
                Android.Util.Log.Error("Crash Report", errorMessage);
            }
            catch
            {
                // just suppress any error logging exceptions
            }
        }




        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


    }



    /// <summary>
    // If there is an unhandled exception, the exception information is diplayed 
    // on screen the next time the app is started (only in debug configuration)
    /// </summary>
    //[Conditional("DEBUG")]
    //private void DisplayCrashReport()
    //{
    //    const string errorFilename = "Fatal.log";
    //    var libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
    //    var errorFilePath = Path.Combine(libraryPath, errorFilename);

    //    if (!File.Exists(errorFilePath))
    //    {
    //        return;
    //    }

    //    var errorText = File.ReadAllText(errorFilePath);
    //    new AlertDialog.Builder(this)
    //        .SetPositiveButton("Clear", (sender, args) =>
    //        {
    //            File.Delete(errorFilePath);
    //        })
    //        .SetNegativeButton("Close", (sender, args) =>
    //        {
    //        // User pressed Close.
    //    })
    //        .SetMessage(errorText)
    //        .SetTitle("Crash Report")
    //        .Show();
    //} 

}