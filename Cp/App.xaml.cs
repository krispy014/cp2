using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamvvm;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Cp
{
    public partial class App : Application
    {
        public App()
        {
            // UWP
            //UnhandledException += async (sender, e) =>
            //{
            //    e.Handled = true;  // the magic! required to show popup!
            //    var dialog = new MessageDialog(e.Message, "UnhandledException caught!");
            //    await dialog.ShowAsync();
            //}

            InitializeComponent();

            //MessagingCenter.Subscribe<NavigationParamsModel>("NavigateMessage", async (arg1, arg2) =>
            //{
            //    // Just an example of how this would be done using Prism.Navigation. 
            //    // Pure Xamarin.Forms navigation is obviously different.
            //    _navigationService.NavigateAsync(arg2.TargetPage);
            //});
            
            var factory = new XamvvmFormsFactory(this);
            factory.RegisterNavigationPage<MainNavigationPageModel>(() => this.GetPageFromCache<MasterDetailPageModel>());
            XamvvmCore.SetCurrentFactory(factory);

            // 본페이지
            //MainPage = this.GetPageFromCache<MainNavigationPageModel>() as NavigationPage;
            
            // 로그인페이지
            MainPage = new NavigationPage(new Login());


            //Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            //AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomainOnUnhandledException);
            //AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            //{
            //    System.Diagnostics.Debug.WriteLine("AppDomain.CurrentDomain.UnhandledException: {0}. IsTerminating: {1}", e.ExceptionObject, e.IsTerminating);
            //};




            //MainPage = this.GetPageFromCache<MainNavigationPageModel>() as NavigationPage;


            //MainPage = new NavigationPage(new StartPage())
            //{
            //    BarBackgroundColor = Color.FromHex("CC0066"),
            //    BarTextColor = Color.FromHex("FFFFFF")
            //};

            //MainPage = new MainMenu();
            //MainPage = new NavigationPage(new MainPage());
        }

        //private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        //{
        //    var newExc = new Exception("CurrentDomainOnUnhandledException", unhandledExceptionEventArgs.ExceptionObject as Exception);

        //    //LogUnhandledException(newExc);
        //}
        //internal static void LogUnhandledException(Exception e)
        //{
        //    try
        //    {
        //        // Log to Android Device Logging.
        //        System.Diagnostics.Debug.WriteLine("AppDomain.CurrentDomain.UnhandledException: {0}. IsTerminating: {1}");
        //    }
        //    catch
        //    {
        //        // just suppress any error logging exceptions
        //    }
        //}

        //static void FatalExceptionObject(object exceptionObject)
        //{
        //    var huh = exceptionObject as Exception;
        //    if (huh == null)
        //    {
        //        huh = new NotSupportedException(
        //          "Unhandled exception doesn't derive from System.Exception: "
        //           + exceptionObject.ToString()
        //        );
        //    }
        //    FatalExceptionHandler.Handle(huh);
        //}

        public void GoToHomePage()
        {
            
            Page p=this.GetPageFromCache<MainNavigationPageModel>() as NavigationPage;
            //NavigationPage.SetHasNavigationBar(p, false);
            MainPage = p;
            //NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
