using System;

using Xamarin.Forms;

namespace Cp.Views
{
    public class QRPage : ContentPage
    {
        public QRPage()
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

