using System;

using Newtonsoft.Json;

using Xamarin.Forms;
using Xamvvm;

namespace Cp.Model
{

    public class OrderbookItem : BaseModel
    {
        string title;
        public string Title
        {
            get { return title; }
            set { SetField(ref title, value); }
        }

        public Color Color { get; private set; } = Helpers.Colors.RandomColor;
    }

}

