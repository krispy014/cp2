using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Cp.Helpers;
using Cp.Model;
using Cp.Views;
using Xamarin.Forms;
using Xamvvm;
using ZXing.Net.Mobile.Forms;

namespace Cp
{
    public partial class HomePage : ContentPage, IBasePage<HomePageModel>
    {
        ObservableCollection<TableModel> Table_List = new ObservableCollection<TableModel>();
        public HomePage()
        {
            InitializeComponent();
            this.Table_List.Add(new TableModel { name = "Hibee", currentprice = 125452, daybefore = "+1.89%",transactionprice = 113.949251 });
            this.Table_List.Add(new TableModel { name = "Bitcoin", currentprice = 125452, daybefore = "+1.89%",transactionprice = 113.949251 });
            this.Table_List.Add(new TableModel { name = "Etherium", currentprice = 125452, daybefore = "+1.89%",transactionprice = 113.949251 });
            this.Table_List.Add(new TableModel { name = "Bitcoin cash", currentprice = 125452, daybefore = "+1.89%",transactionprice = 113.949251 });

            listx.ItemsSource = this.Table_List;
        }
        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //}

        //private async void Receive(object sender, EventArgs e)
        //{
        //    //await Navigation.PushModalAsync(new ReceivePage(), false);
        //    Glo.Data.openPage(Constants.PAGEID_RECV);

        //}
        //private async void Trade(object sender, EventArgs e)
        //{
        //    PushPageFromCacheAsync<TradePageModel>();
        //}

        //private void PushPageFromCacheAsync<T>()
        //{
        //    throw new NotImplementedException();
        //}

        ////Glo.Data.openPage(Constants.PAGEID_TRADE);


        //private async void Buyandsell(object sender, EventArgs e)
        //{
        //    //await Navigation.PushModalAsync(new BuyandsellPage(), false);
        //    Glo.Data.openPage(Constants.PAGEID_BUYNSELL);

        //}
        //private async void Wallet(object sender, EventArgs e)
        //{
        //    //await Navigation.PushModalAsync(new WalletPage(), false);
        //    Glo.Data.openPage(Constants.PAGEID_WALLET);

        //}
        //private async void Settings(object sender, EventArgs e)
        //{
        //    //await Navigation.PushModalAsync(new SettingsPage(), false);
        //    Glo.Data.openPage(Constants.PAGEID_SETTING);

        //}

        private async void scanbtn(object sender, System.EventArgs e)
        {
            var scan = new ZXingScannerPage();
            await Navigation.PushModalAsync(scan);
            scan.OnScanResult += (result) =>
            {
                scan.IsScanning = false;
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    await DisplayAlert("Scanned Barcode", result.Text, "OK");
                });
            };
        }

        


    }
}
