using System;

using Xamarin.Forms;

namespace Example.Model
{
    public class LoginViewModel : ContentPage
    {
        public LoginViewModel()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

