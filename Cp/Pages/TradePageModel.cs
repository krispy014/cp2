using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamvvm;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;
using DLToolkit.Forms.Controls;
using System.Collections.Generic;
using Cp;
using Cp.Model;
using Cp.Views;

namespace Cp
{
    public class TradePageModel : CommonPageModel
    {
        public int col_limit=0;
        public void set_col_limit(int val)
        {
            col_limit = val;
            ColumnCount = val;
        }
             

        public TradePageModel()
        {
            // 컬럼 수 제한
            set_col_limit(Constants.ORDERBOOK_COL_CNT);

            //SendPageCommand = new BaseCommand((arg) =>
            //{
            //    Glo.Data.openPage(Constants.PAGEID_SEND);
            //});

            //ReceivePageCommand = new BaseCommand((arg) =>
            //{
            //    Glo.Data.openPage(Constants.PAGEID_RECV);
            //});



            ItemTappedCommand = new BaseCommand((param) =>
            {

                var item = LastTappedItem as OrderbookItem;
                if (item != null)
                    System.Diagnostics.Debug.WriteLine("Tapped {0}", item.Title);

            });

            //ScrollToCommand = new BaseCommand((arg) =>
            //{
            //    var page = this.GetCurrentPage() as TradePage;
            //    page.FlowScrollTo(Items[Items.Count / 2]);
            //});

            //ChangeColumnCountCommand = new BaseCommand((arg) =>
            //{
            //    ColumnCount++;
            //});

            ClearCommand = new BaseCommand((arg) =>
            {
                //Items.Clear();
                //exampleData.Add(new SimpleItem() { Title = string.Format("{0}", 12) });

                // test ok
                //((SimpleItem)exampleData[0]).Title = "x";
            });

            //UpdateFirstCommand = new BaseCommand((arg) =>
            //{
            //    if (Items.FirstOrDefault() is SimpleItem item)
            //    {
            //        item.Title = Guid.NewGuid().ToString();
            //    }
            //});

            //TestReloadData();


            // make 10 rows orderbook grid
            MakeOrderbookGrid(10);

        }
        //public ICommand SendPageCommand { get; set; }
        //public ICommand ReceivePageCommand { get; set; }
        
        public FlowObservableCollection<object> Items
        {
            get { return GetField<FlowObservableCollection<object>>(); }
            set { SetField(value); }
        }

        public List<object> exampleData;


        public ICommand ScrollToCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        public ICommand UpdateFirstCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }


        public ICommand ChangeColumnCountCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        public ICommand ClearCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }
        

        //public void TestReloadData()
        //{
        //    var exampleData = new List<object>();

        //    var howMany = 120;

        //    for (int i = 0; i < howMany; i++)
        //    {
        //        exampleData.Add(new SimpleItem() { Title = string.Format("Item nr {0}", i) });
        //    }

        //    Items = new FlowObservableCollection<object>(exampleData);
        //}

        public void MakeOrderbookGrid(int row_cnt)
        {            
            var howMany = Constants.ORDERBOOK_COL_CNT*row_cnt;

            Glo.Data.orderbook_data.Clear();

            for (int i = 0; i < howMany; i++)
            {
                Glo.Data.orderbook_data.Add(new OrderbookItem() {
                    Title = ""
                    //Title = string.Format("Item nr {0}", i)
                });
            }

            //FlowObservableCollection  을 쓰는 이유는 동적으로 변경된 데이타를 업데이트 시키기 위해서임.
            Glo.Data.make_orderbook_obj();
            Items = Glo.Data.tradepage_orderbook_obj;
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

        
    }
}