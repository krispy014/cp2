using System;
using System.Collections.Generic;
using Cp.Views;
using Xamarin.Forms;
using Xamvvm;

namespace Cp
{
    public partial class ReceivePage : ContentPage,IBasePage<ReceivePageModel>
    {
           public ReceivePage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new QRPage());
        }

        void Handle_Clicked_1(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new RequestPage());
        }
    }
}
