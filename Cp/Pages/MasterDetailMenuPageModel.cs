using System;
using Xamvvm;
using System.Windows.Input;
using Xamarin.Forms;
using Cp.Views;
using System.Collections.Generic;
using Cp.Model;

namespace Cp
{
    public class MasterDetailMenuPageModel : BasePageModel
    {

        public MasterDetailMenuPageModel()
        {

            Glo.Data.MasterDetailMenuObj = this;
            //Glo.Data.ViewPageObj = this.GetPageFromCache<SampleNavigationViewPageModel>() as SampleNavigationViewPageModel;

            HomePageCommand = new BaseCommand((arg) =>
            {
                Glo.Data.openPage(Constants.PAGEID_HOME);
            });

            SendPageCommand = new BaseCommand((arg) =>
            {
                Glo.Data.openPage(Constants.PAGEID_SEND);
            });

            RecvPageCommand = new BaseCommand((arg) =>
            {
                Glo.Data.openPage(Constants.PAGEID_RECV);
            });

            TradePageCommand = new BaseCommand((arg) =>
            {
                Glo.Data.openPage(Constants.PAGEID_TRADE);
            });

            WalletPageCommand = new BaseCommand((arg) =>
            {
                Glo.Data.openPage(Constants.PAGEID_WALLET);
            });

            UpdatePageCommand = new BaseCommand((arg) =>
            {
                Glo.Data.openPage(Constants.PAGEID_UPDATE);
            });

            SettingsPageCommand = new BaseCommand((arg) =>
            {

                Glo.Data.openPage(Constants.PAGEID_SETTING);
            });
        }

        // --------- tip --------
        // syncronized method by using _locker object
        // private object _locker = new object();
        // lock (_locker)
        // {
        //     code
        // }

        public void toggle_menu()
        {
            var masterDetailPage = this.GetPageFromCache<MasterDetailPageModel>();
            ((MasterDetailPage)masterDetailPage).drawer_toggle();
        }


        private void showPage_cancelled()
        {
            Console.WriteLine("MasterDetailMenuPageModel->showPage_cancelled()");

            var masterDetailPage = this.GetPageFromCache<MasterDetailPageModel>();
            ((MasterDetailPage)masterDetailPage).drawer_close();
            Glo.Data.showpage_running = false;
        }

        public void showPage(int idx)
        {
            Console.WriteLine("MasterDetailMenuPageModel->showPage()");

            if (Glo.Data.showpage_running)
            {
                Console.WriteLine("MasterDetailMenuPageModel->showPage: break;showpage_running..");
                return;
            }
            else
            {
                Console.WriteLine("MasterDetailMenuPageModel->showPage: idx="+idx);
            }

            try
            {
                Glo.Data.showpage_running = true;

                MainMenuItem item = Glo.Data.MainMenuItems[idx];
                //Page obj = (Page)Activator.CreateInstance(item.TargetType);
                //if (item.Id.Equals("HOMEPAGE"))

                // 현재 페이지와 이동 페이지가 같으면 이동하지말고 메뉴만 닫는다
                if (Glo.Data.Page_ID == item.Page_Id)
                {
                    showPage_cancelled();
                    return;
                }
                else
                {
                    Glo.Data.Page_ID = item.Page_Id;
                    //Detail = new NavigationPage(obj);
                    Type t = item.TargetType;

                    //var masterDetailPage = this.GetPageFromCache<MasterDetailPageModel>();

                    Page p = null;
                    //p = this.GetPageFromCache<HomePageModel>() as Page;

                    //var page;
                    if (item.Page_Id == Constants.PAGEID_HOME)
                    {
                        p = this.GetPageFromCache<HomePageModel>() as Page;
                    }
                    else if (item.Page_Id == Constants.PAGEID_SEND)
                    {
                        p = this.GetPageFromCache<SendPageModel>() as Page;
                    }
                    else if (item.Page_Id == Constants.PAGEID_RECV)
                    {
                        p = this.GetPageFromCache<ReceivePageModel>() as Page;
                    }
                    else if (item.Page_Id == Constants.PAGEID_TRADE)
                    {
                        p = this.GetPageFromCache<TradePageModel>() as Page;
                    }
                    else if (item.Page_Id == Constants.PAGEID_UPDATE)
                    {
                        p = this.GetPageFromCache<UpdatePageModel>() as Page;
                    }
                    else if (item.Page_Id == Constants.PAGEID_WALLET)
                    {
                        p = this.GetPageFromCache<WalletModel>() as Page;
                    }
                    else if (item.Page_Id == Constants.PAGEID_SETTING)
                    {
                        p = this.GetPageFromCache<SettingsPageModel>() as Page;
                    }
                    else if (item.Page_Id == Constants.PAGEID_BUYNSELL)
                    {
                        p = this.GetPageFromCache<BuyandsellModel>() as Page;
                    }
                     else if (item.Page_Id == Constants.PAGEID_HISTORY)
                    {
                        p = this.GetPageFromCache<HistoryPageModel>() as Page;
                    }
                     else if (item.Page_Id == Constants.PAGEID_SENDMONEY)
                    {
                        p = this.GetPageFromCache<SendMoneyPageModel>() as Page;
                    }
                     else if (item.Page_Id == Constants.PAGEID_RECEIVEMONEY)
                    {
                        p = this.GetPageFromCache<ReceiveMoneyPageModel>() as Page;
                    }

                    if (p == null)
                    {
                        showPage_cancelled();
                        return;
                    }

                    //masterDetailPage.GetPageModel().SetDetail(p);
                    //var masterDetailPage = this.GetPageFromCache<MasterDetailPageModel>();

                    //var masterDetailPage = (this).GetCurrentPage() as Xamarin.Forms.MasterDetailPage;
                    //((MasterDetailPage)masterDetailPage).SetDetail(p);
                    var masterDetailPage = this.GetPageFromCache<MasterDetailPageModel>();
                    ((MasterDetailPage)masterDetailPage).SetDetail(p);
                    //Glo.Data.MasterDetailPageObj.SetDetail(p);
                    //Glo.Data.MasterDetailPageObj.SetDetail(p);

                }

                // moved to SetDetail()
                //Glo.Data.showpage_running = false;

            }
            catch (Exception e)
            {
                Console.WriteLine("MasterDetailMenuPageModel->showPage: Exception=" + e.ToString());
                showPage_cancelled();
                return;
            }
        }

        public ICommand HomePageCommand { get; set; }
        public ICommand SendPageCommand { get; set; }
        public ICommand RecvPageCommand { get; set; }
        public ICommand TradePageCommand { get; set; }
        public ICommand UpdatePageCommand { get; set; }
        public ICommand WalletPageCommand { get; set; }
        public ICommand SettingsPageCommand { get; set; }
    }
}
