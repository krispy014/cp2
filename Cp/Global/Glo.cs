
using Cp.Model;
using Cp.Services;
using Cp.Views;
using DLToolkit.Forms.Controls;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Quobject.Collections.Immutable;
using Quobject.EngineIoClientDotNet.Client.Transports;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Cp
{
    public class Glo
    {

        // this is the default static instance you'd use like string text = Settings.Default.SomeSetting;
        public readonly static Glo Data = new Glo();

        public List<MainMenuItem> MainMenuItems;
        
        // is showpage called and not finished
        public bool showpage_running = false;

        // tradepage status
        public bool socketio_orderbook_init = false;
        public bool tradepage_ready = false;

        public ApiServices apiServices;
        public SocketIOService socketioService;


        public Quobject.SocketIoClientDotNet.Client.IO.Options socketio_options = new Quobject.SocketIoClientDotNet.Client.IO.Options
        {
            /*The delay was more or less equal to the pingInterval (by default 25s).
            We didn't find any explanation for this.
            But we could solve the problem for us setting the transports option.
            WebSocket is default, Polling is fallback*/
            Transports = ImmutableList.Create(new string[] { Quobject.EngineIoClientDotNet.Client.Transports.WebSocket.NAME, Quobject.EngineIoClientDotNet.Client.Transports.Polling.NAME }), /* avoid 25s delay */
            Timeout = 1000,
            //Port = port,
            //Hostname = ip,
            IgnoreServerCertificateValidation = true,
            Secure = false,
            //Reconnection=false
        };

        public Glo()
        {
            Page_ID = Constants.PAGEID_START;

            apiServices = new ApiServices();
            socketioService = new SocketIOService();

            MainMenuItems = new List<MainMenuItem>()
            {
                new MainMenuItem() {
                    Id ="HOMEPAGE",
                    Page_Id=Constants.PAGEID_HOME,
                    Title = "Homepage",
                    Icon ="homepage.png",
                    TargetType = typeof(HomePageModel)
                },
                new MainMenuItem() {
                    Id ="SENDMONEY",
                    Page_Id=Constants.PAGEID_SENDMONEY,
                    Title = "Homepage",
                    Icon ="homepage.png",
                    TargetType = typeof(SendMoneyPageModel)
                },
                new MainMenuItem() {
                    Id ="RECEIVEMONEY",
                    Page_Id=Constants.PAGEID_RECEIVEMONEY,
                    Title = "Homepage",
                    Icon ="homepage.png",
                    TargetType = typeof(ReceiveMoneyPageModel)
                },
                new MainMenuItem() {
                    Id ="HISTORY",
                    Page_Id=Constants.PAGEID_HISTORY,
                    Title = "Homepage",
                    Icon ="homepage.png",
                    TargetType = typeof(HistoryPageModel)
                },
                new MainMenuItem() {
                    Id ="SEND_MONEY",
                    Page_Id =Constants.PAGEID_SEND,
                    Title = "Send Money",
                    Icon ="sendmoney.png",
                    TargetType = typeof(SendPageModel)
                },
                new MainMenuItem() {
                    Id ="RECEIVE",
                    Page_Id =Constants.PAGEID_RECV,
                    Title = "Receive",
                    Icon ="update.png",
                    TargetType = typeof(ReceivePageModel)
                },
                new MainMenuItem() {
                    Id ="UPDATE",
                    Page_Id =Constants.PAGEID_UPDATE,
                    Title = "Update",
                    Icon ="update.png",
                    TargetType = typeof(UpdatePageModel)
                },
                new MainMenuItem() {
                    Id ="TRADE",
                    Page_Id =Constants.PAGEID_TRADE,
                    Title = "Trade",
                    Icon ="trade.png",
                    TargetType = typeof(TradePageModel)
                },
                new MainMenuItem() {
                    Id ="WALLET",
                    Page_Id =Constants.PAGEID_WALLET,
                    Title = "Wallet",
                    Icon ="trade.png",
                    TargetType = typeof(WalletModel)
                },
                new MainMenuItem() {
                    Id ="BUYNSELL",
                    Page_Id =Constants.PAGEID_BUYNSELL,
                    Title = "BUYNSELL",
                    Icon ="trade.png",
                    TargetType = typeof(WalletModel)
                },
                new MainMenuItem() {
                    Id ="SETTING",
                    Page_Id =Constants.PAGEID_SETTING,
                    Title = "Setting",
                    Icon ="trade.png",
                    TargetType = typeof(SettingsPageModel)
                },
            };

        }

        public TradePageModel tradepagemodel_obj // 
        {
            get;set;
        }

        public List<object> orderbook_data = new List<object>();

        public FlowObservableCollection<object> tradepage_orderbook_obj // 
        {
            get;set;
        }

        public void make_orderbook_obj() //List<object> o) 
        {
            tradepage_orderbook_obj = new FlowObservableCollection<object>(this.orderbook_data);
        }
        
        // update orderbook value
        public void UpdateOrderbookData(int row, int col, string val)
        {
            int idx = (row * Constants.ORDERBOOK_COL_CNT) + col;
            if (orderbook_data.Count > idx && idx >= 0)
            {
                ((OrderbookItem)orderbook_data[idx]).Title = val;
            }
        }

        public void toggle_menu()
        {
            if (MasterDetailMenuObj != null)
            {
                MasterDetailMenuObj.toggle_menu();
            }
        }

        public MasterDetailMenuPageModel MasterDetailMenuObj // MasterDetailPage.Master
        {
            get;set;
        }

        //public MasterDetailPage MasterDetailPageObj // MasterDetailPage
        //{
        //    get;set;
        //}

        //public MasterDetailPageModel MasterDetailModelObj // MasterDetailPageModel
        //{
        //    get;set;
        //}

        //public SampleNavigationViewPageModel ViewPageObj
        //{
        //    get;set;
        //}

        public void openPage(int page_id)
        {
            try
            {
                if (MasterDetailMenuObj != null)
                {
                    bool page_found = false;
                    for (int i = 0; i < MainMenuItems.Count; i++)
                    {
                        if (MainMenuItems[i].Page_Id == page_id)
                        {
                            // normal
                            //MainPageObj.showPage(i);

                            // using NavigationViewPage
                            //if (ViewPageObj == null)
                            //{
                            //    return;
                            //}
                            page_found = true;
                            MasterDetailMenuObj.showPage(i);
                            break;

                        }
                    }

                    if (!page_found)
                    {
                        Glo.Data.showpage_running = false;
                    }
                }
                else
                {
                    Glo.Data.showpage_running = false;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("openPage: Exception="+ e.ToString());   
            }
        }

        //public void openViewPage(int page_id)
        //{
        //    if(page_id== Constants.PAGEID_SETTING)
        //    {
        //        return;
        //    }

        //    if (MainPageObj != null)
        //    {
        //        for (int i = 0; i < MainPageObj.MainMenuItems.Count; i++) {
        //            if (MainPageObj.MainMenuItems[i].Page_Id == page_id)
        //            {
        //                // normal
        //                //MainPageObj.showPage(i);\
        //                this.openPage(Constants.PAGEID_SETTING);

        //                // using NavigationViewPage
        //                if (ViewPageObj == null)
        //                {
        //                    return;
        //                }

        //                ViewPageObj.showViewPageAsync(page_id);

        //            }
        //        }                        
        //    }
        //}

        public int Page_ID
        {
            get;set;

        }

        public int last_back_pressed
        {
            get;set;
        }

        public string id
        {
            get;set;

        }

        public string token
        {
            get;set;

        }

    }

}