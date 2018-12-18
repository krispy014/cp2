using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Cp.Helpers;
using Cp.Model;
using Cp.Viewmodel;
using DLToolkit.Forms.Controls;
using Newtonsoft.Json;

using Newtonsoft.Json.Linq;
using Quobject.SocketIoClientDotNet.Client;

namespace Cp.Services
{
    public class SocketIOService
    {
        public bool orderbook_connected = false;
        public Socket socket;
        public Manager manager;


        public void reconnect_socketio()
        {
            if (!orderbook_connected)
            {
                orderbook_connected = true;
                socket.Disconnect(); // ?
                socket.Connect();
            }
        }

        public void destory_socketio()
        {
            socket.Disconnect();
            manager.Close();
        }

        public void init_socketio()
        {

            if (Glo.Data.socketio_orderbook_init)
            {
                return;
            }

            Glo.Data.socketio_orderbook_init = true;

            string ip = "192.168.2.169";
            int port = 8080;

            //Helpers.Utils.Msgbox("start");
            //Console.WriteLine("start");

            /*
            var ops = new IO.Options { Transports = ImmutableList.Create<string>().Add("websocket") };
            var socket = IO.Socket("http://localhost:3001", ops);`

            socket.On(Socket.EVENT_CONNECT_ERROR, data => {
                Console.WriteLine("SOCKET CONNECTION ERROR", data.ToString());
            });
            */
            
            //var manager = new Quobject.SocketIoClientDotNet.Client.Manager(new Uri(uri), options);

            //socket = IO.Socket("http://" + ip + ":" + port);
            //socket = IO.Socket("http://" + ip + ":" + port,options);
            var uri = "http://" + ip + ":" + port;

            manager = new Manager(new Uri(uri), Glo.Data.socketio_options);
            socket = manager.Socket("/");

            manager.On(Manager.EVENT_CONNECT_ERROR, data => {
                orderbook_connected = false;
                Console.WriteLine("SOCKET CONNECTION ERROR=" + data.ToString());
            });

            socket.On(Socket.EVENT_DISCONNECT, data => {
                orderbook_connected = false;
                Console.WriteLine("SOCKET DISCONNECTED");
            });


            //Helpers.Utils.Msgbox("1");

            //TradeJSON_init t=new TradeJSON_init();
            //t.cp_code = "btcusd";

            //string txt = JsonConvert.SerializeObject(t);


            socket.On(Socket.EVENT_CONNECT, () =>
            {
                orderbook_connected = true;

                if (Glo.Data.tradepage_ready)
                {
                    try
                    {
                        var jobj = new JObject();
                        jobj.Add("cp_code", "btcusd");
                        socket.Emit("ob.init", jobj);
                    }
                    catch
                    {

                    }
                }
            });


            socket.On("ob.new_ob", (data) =>
            {

                if (Glo.Data.tradepage_ready)
                {
                    Console.WriteLine("socket.On(ob.new_ob)");
                    //Console.WriteLine(data.ToString());

                    //JsonRecevedMessage ob_data = JsonConvert.DeserializeObject<JsonRecevedMessage>(data.ToString());
                    //((JObject)data)["message"].ToString()

                    // bs,price,amount,total

                    int bc = 0;
                    int sc = 0;
                    int total_rows = 10;
                    int s_pos = (total_rows / 2) - 1;
                    int b_pos = (total_rows / 2);


                    JArray arr = (JArray)(((JObject)data)["ob"]);
                    for (int i = 0; i < arr.Count; i++)
                    {
                        JObject obj = (JObject)arr[i];
                        string bs = obj["bs"].ToString();
                        string price = obj["price"].ToString();
                        string amount = obj["amount"].ToString();
                        string total = obj["total"].ToString();

                        if (bs == "b")
                        {
                            bc++;
                            Glo.Data.UpdateOrderbookData(b_pos, 0, price);
                            Glo.Data.UpdateOrderbookData(b_pos, 1, amount);
                            Glo.Data.UpdateOrderbookData(b_pos, 2, total);
                            b_pos++;
                        }
                        else
                        {
                            sc++;
                            Glo.Data.UpdateOrderbookData(s_pos, 0, price);
                            Glo.Data.UpdateOrderbookData(s_pos, 1, amount);
                            Glo.Data.UpdateOrderbookData(s_pos, 2, total);
                            s_pos--;
                        }
                    }

                    for (; s_pos >= 0; s_pos--)
                    {
                        Glo.Data.UpdateOrderbookData(s_pos, 0, "");
                        Glo.Data.UpdateOrderbookData(s_pos, 1, "");
                        Glo.Data.UpdateOrderbookData(s_pos, 2, "");
                    }

                    for (; b_pos < 10; b_pos++)
                    {
                        Glo.Data.UpdateOrderbookData(b_pos, 0, "");
                        Glo.Data.UpdateOrderbookData(b_pos, 1, "");
                        Glo.Data.UpdateOrderbookData(b_pos, 2, "");
                    }
                }
            });


            //this.socket?.Disconnect();
            //manager?.Close();
            //this.socket = null;
            //manager = null;

        }

    }
}