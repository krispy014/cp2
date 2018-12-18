using System;
using System.Collections.Generic;
using System.Net.Http;
using Cp.Viewmodel;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Cp
{
    public partial class History : ContentPage
    {
        public History()
        {
            InitializeComponent();
        }
        private async void GetTitle()//Get method in Rest Api in laravel
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(Constants.API_URL + "/");
            var titles = JsonConvert.DeserializeObject<List<HistoryModel>>(response);
            HistoryListView.ItemsSource = titles;

        }
    }
}
