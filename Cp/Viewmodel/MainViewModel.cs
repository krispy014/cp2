using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Cp.Model;
using Xamarin.Forms;

namespace Cp.Viewmodel
{

        public class MainViewModel : INotifyPropertyChanged
        {
            #region Property

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
            {
                if (EqualityComparer<T>.Default.Equals(storage, value))
                {
                    return false;
                }

                storage = value;
                OnPropertyChanged(propertyName);
                return true;
            }

            #endregion

            public ObservableCollection<CarouselItem> Items { get; }

            private int _position;
            public int Position
            {
                get { return _position; }
                set { SetProperty(ref _position, value); }
            }

            public MainViewModel()
            {
                Items = new ObservableCollection<CarouselItem>();

                CarouselItem item = new CarouselItem
                {
                Title = "Pato",
                Detail = "Ako ung unang pato",
                Image = "bg01.jpg"
                };

                Items.Add(item);

                item = new CarouselItem
                {
                Title = "Pato 2",
                Detail = "Ako ung pangalawang pato",
                Image = "bg02.jpeg"
                };

                Items.Add(item);

                item = new CarouselItem
                {
                Title = "Pato 3",
                Detail = "Ako ung pangatlong pato",
                Image = "bg03.jpeg"
                };

                Items.Add(item);

                item = new CarouselItem
                {
                Title = "Pato 4",
                Detail = "Ako ung pangapat na pato",
                Image = "bg04.png"
                };

                Items.Add(item);



        }
    }
}

