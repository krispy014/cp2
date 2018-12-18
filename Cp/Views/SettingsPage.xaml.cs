using System;
using System.Collections.Generic;
using Cp.Views;
using Xamarin.Forms;
using Xamvvm;

namespace Cp
{
    public partial class SettingsPage : ContentPage, IBasePage<SettingsPageModel>
    {
        public SettingsPage()
        {
            InitializeComponent();
        }
    }
}
