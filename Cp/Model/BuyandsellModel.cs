using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DLToolkit.Forms.Controls;
using Xamvvm;


namespace Cp.Views
{
    public class BuyandsellModel : CommonPageModel
    {
        public BuyandsellModel()
        {
        }
    

        public int col_limit=0;
        public void set_col_limit(int val)
        {
            col_limit = val;
            ColumnCount = val;
        }

        public ObservableCollection<ItemModel> Items
        {
            get { return GetField<FlowObservableCollection<ItemModel>>(); }
            set { SetField(value); }
        }
            public int? ColumnCount
        {
            get { return GetField<int?>(); }
            set { SetField(value); }
        }
         public ICommand ItemTappedCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        public object LastTappedItem
        {
            get { return GetField<object>(); }
            set { SetField(value); }
        }

        public class ItemModel : BaseModel
        {
            string imageUrl;
            public string ImageUrl
            {
                get { return imageUrl; }
                set { SetField(ref imageUrl, value); }
            }

            string fileName;
            public string FileName
            {
                get { return fileName; }
                set { SetField(ref fileName, value); }
            }
        }
    }
}