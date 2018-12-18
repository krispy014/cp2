using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Cp.Model;
using Xamarin.Forms;
using Xamvvm;

namespace Cp.Views
{
    public class CommonPageModel : BasePageModel
    {
        public CommonPageModel()
        {

            MenuToggleCommand = new BaseCommand((arg) =>
            {
                //Glo.Data.openPage(Constants.PAGEID_BUYNSELL);

                Glo.Data.toggle_menu();
            });

            // PAGE LINK
            {
                SendPageCommand = new BaseCommand((arg) =>
                {
                    Glo.Data.openPage(Constants.PAGEID_SEND);
                });

                ReceivePageCommand = new BaseCommand((arg) =>
                {
                    Glo.Data.openPage(Constants.PAGEID_RECV);
                });

                TradePageCommand = new BaseCommand((arg) =>
                {
                    Glo.Data.openPage(Constants.PAGEID_TRADE);
                });

                BuynsellPageCommand = new BaseCommand((arg) =>
                {
                    Glo.Data.openPage(Constants.PAGEID_BUYNSELL);
                });

                WalletPageCommand = new BaseCommand((arg) =>
                {
                    Glo.Data.openPage(Constants.PAGEID_WALLET);
                });

                SettingsPageCommand = new BaseCommand((arg) =>
                {
                    Glo.Data.openPage(Constants.PAGEID_SETTING);
                });
                HistoryPageCommand = new BaseCommand((arg) =>
                {
                    Glo.Data.openPage(Constants.PAGEID_HISTORY);
                });
                BalancePageCommand = new BaseCommand((arg) =>
                {
                    Glo.Data.openPage(Constants.PAGEID_BALANCE);
                });
                CoingInfoCommand = new BaseCommand((arg) =>
                {
                    Glo.Data.openPage(Constants.PAGEID_COININFO);
                });
                MyPageCommand = new BaseCommand((arg) =>
                {
                    Glo.Data.openPage(Constants.PAGEID_MYPAGE);
                });
                SendMoneyCommand = new BaseCommand((arg) =>
                {
                    Glo.Data.openPage(Constants.PAGEID_SENDMONEY);
                });
                ReceiveMoneyCommand = new BaseCommand((arg) =>
                {
                    Glo.Data.openPage(Constants.PAGEID_RECEIVEMONEY);
                });
            }

        }

        public ICommand MenuToggleCommand { get; set; }


        public ICommand SendPageCommand { get; set; }
        public ICommand SendMoneyCommand { get; set; }
        public ICommand ReceiveMoneyCommand { get; set; }
        public ICommand ReceivePageCommand { get; set; }
        public ICommand TradePageCommand { get; set; }
        public ICommand BuynsellPageCommand { get; set; }
        public ICommand WalletPageCommand { get; set; }
        public ICommand SettingsPageCommand { get; set; }
        public ICommand HistoryPageCommand { get; set; }
        public ICommand CoingInfoCommand { get; set; }
        public ICommand MyPageCommand { get; set; }
        public ICommand BalancePageCommand { get; set; }
    }
}