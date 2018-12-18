using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Cp.Model;
using Xamarin.Forms;
using Xamvvm;

namespace Cp.Views
{
    public partial class HistoryPage : ContentPage, IBasePage<HistoryPageModel>
    {
        ObservableCollection<HistoryModel> Table_List = new ObservableCollection<HistoryModel>();
        public HistoryPage()
        {
            InitializeComponent();
            this.Table_List.Add(new HistoryModel { Date = "02/13/18", TransactionInfo="Buy Etherium" });
           this.Table_List.Add(new HistoryModel { Date = "02/13/18", TransactionInfo="Buy Etherium" });
           this.Table_List.Add(new HistoryModel { Date = "02/13/18", TransactionInfo="Buy Etherium" });
           this.Table_List.Add(new HistoryModel { Date = "02/13/18", TransactionInfo="Buy Etherium" });
           this.Table_List.Add(new HistoryModel { Date = "02/13/18", TransactionInfo="Buy Etherium" });
           

            listhistory.ItemsSource = this.Table_List;
        }
    }
}