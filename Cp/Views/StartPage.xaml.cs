using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Cp.Viewmodel;

namespace Cp
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
            this.BindingContext = new MainViewModel();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new Login(),false);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
