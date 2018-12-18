using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading;
using Quobject.SocketIoClientDotNet.Client;
using Cp.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamvvm;
using DLToolkit.Forms.Controls;
using Quobject.Collections.Immutable;
using Quobject.EngineIoClientDotNet.Client.Transports;
using Xamarin.Forms.Xaml;

namespace Cp
{
    public partial class TradePage : ContentPage, IBasePage<TradePageModel>
    {
        private bool tradepage_init = false;
        private bool socketio_init_running = false;
        
        // 초기화보다 onappearing 이 먼저 호출되니 주의할것.
        public TradePage()
        {

            //FlowListView.Init();
            InitializeComponent();

            if (!tradepage_init) {
                init_socketio();
            }
            //GetTrade();

            tradepage_init = true;
            Glo.Data.tradepage_ready = true;
        }

        protected override void OnDisappearing()
        {
            //if (socket != null)
            //{
            //socket.Close();
            //}
            //close_socketio();

            Glo.Data.tradepage_ready = false;
            (this.GetPageModel()).Items = null; // disconnect from orderbook_data_obj
            base.OnDisappearing();

        }

        protected override void OnAppearing()
        {
            //if (socket != null)
            //{
            //    socket.Connect();
            //}



            base.OnAppearing();


            if (tradepage_init)
            {
                //init_socketio();

                // 페이지 초기화가 이미 되어있다면 flowlist 재연결
                (this.GetPageModel()).Items = Glo.Data.tradepage_orderbook_obj; // reconnect from orderbook_data_obj
                Glo.Data.socketioService.reconnect_socketio();
                Glo.Data.tradepage_ready = true;
            }


        }

        //private void GetTrade()
        //{
        //throw new NotImplementedException();
        //}

        public void FlowScrollTo(object item)
		{
			flowListView.FlowScrollTo(item, ScrollToPosition.MakeVisible, true);
		}

        //public void close_socketio()
        //{
        //    //if (this.socket != null)
        //    //{
        //    //    this.socket?.Disconnect();
        //    //    this.socket?.Close();
        //    //    this.socket = null;
        //    //    Console.WriteLine("!!!!!!!! SOCKET CLOSED !!!!!!!! ");

        //    //}
        //}

        public void init_socketio()
        {
            //return;

            if (socketio_init_running)
            {
                return;
            }

            socketio_init_running = true;

            //close_socketio();

            ////_socket = IO.Socket(adress, new IO.Options() { Secure = true, IgnoreServerCertificateValidation = ignoreServerCertificateValidation });

            // socketio init
            Glo.Data.socketioService.init_socketio();

            socketio_init_running = false;


            //Console.ReadLine();

            //socket.Disconnect();


            // dont need
            //socket.Connect();


        }
    }
}
