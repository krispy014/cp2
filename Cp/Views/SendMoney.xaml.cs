using System;
using System.Collections.Generic;
using Cp.Model;
using Cp.Views;
using Xamarin.Forms;
using Xamvvm;

namespace Cp
{
    public partial class SendMoney : ContentPage,IBasePage<SendMoneyPageModel>
    {
        public SendMoney()
        {
            InitializeComponent();
        }
    }
}
