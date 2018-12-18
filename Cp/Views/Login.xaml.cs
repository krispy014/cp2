using Cp.Services;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cp
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushModalAsync(new Signup(),false);
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        async void Loginbtn(object sender, System.EventArgs e)
        {
            if (Constants.IS_TESTMODE && Constants.TESTMODE_LOGIN_SKIP)
            {
                ((App)App.Current).GoToHomePage();
            }
            else
            {
                bool isEmailEmpty = string.IsNullOrEmpty(username.Text);
                bool isPasswordEmpty = string.IsNullOrEmpty(password.Text);

                if (isEmailEmpty || isPasswordEmpty)
                {
                    if (Constants.IS_LIVEPLAYER)
                    {
                        username.Text = "dev@dev.com";
                        password.Text = "121212";

                        isEmailEmpty = false;
                        isPasswordEmpty = false;
                    }
                    else
                    {
                        await DisplayAlert("Login", "Please enter ID and Password", "OK");
                    }
                }

                if (!(isEmailEmpty || isPasswordEmpty))
                {
                    // submit login form
                    ApiServices _apiServices = new ApiServices();
                    bool login_result = await _apiServices.LoginAsync(username.Text, password.Text);
                    if (login_result)
                    {
                        ((App)App.Current).GoToHomePage();

                        //if (Glo.Data.MainPageObj==null)
                        //{
                        //Glo.Data.MainPageObj = new MainMenu() { BackgroundColor = Color.White };
                        //}
                        //await Navigation.PushModalAsync(Glo.Data.MainPageObj,false);
                        //await Navigation.PushModalAsync(Glo.Data.MainPageObj,false);
                    }
                    else
                    {
                        await DisplayAlert("Result", "Sorry. Incorrect ID or Password.", "OK");
                    }

                    //await Navigation.PushModalAsync(new MasterDetail());
                }
            }


        }

    }
}
