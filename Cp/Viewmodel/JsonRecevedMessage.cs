using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Cp.ViewModel
{
    public class JsonRecevedMessage : TradingOrderbookObject
    {
        public string BS { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public double Total { get; set; }
    }
    public class TradingOrderbookObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}

