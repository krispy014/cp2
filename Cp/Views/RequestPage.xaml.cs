using System;
using System.Collections.Generic;
using Cp.Model;
using Xamarin.Forms;
using Xamvvm;

namespace Cp.Views
{
    public partial class RequestPage : ContentPage,IBasePage<ReceiveMoneyPageModel>
    {
        public RequestPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new ReceiveMoney());
        }
    }
}
