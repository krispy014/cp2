using System;

using Xamarin.Forms;

namespace Cp
{
    public class Constants 
    {
        //public static string API_URL => "http://cp22.pato.net/api";
        public static string API_URL => "http://cptest.goweb.kr/api";
        //public static string API_URL => "http://cp169.pato.net/api";

        public static Boolean IS_LIVEPLAYER => false;

        // TEST MODE {
        public static Boolean IS_TESTMODE => true;
        public static Boolean TESTMODE_LOGIN_SKIP => true;
        // }

        public static int DOUBLEBACK_EXIT_SEC => 3;

        public static int ORDERBOOK_COL_CNT => 3;

         public static int PAGEID_START => 0;
        public static int PAGEID_MYPAGE => 1;

        public static int PAGEID_HOME => 2;
        public static int PAGEID_SEND => 3;
        public static int PAGEID_RECV => 4;
        public static int PAGEID_TRADE => 5;
        public static int PAGEID_BUYNSELL => 6;
        public static int PAGEID_WALLET => 7;
        public static int PAGEID_UPDATE => 8;
        public static int PAGEID_SETTING => 9;
        public static int PAGEID_HISTORY => 10;
        public static int PAGEID_BALANCE => 11;
        public static int PAGEID_COININFO => 12;
        public static int PAGEID_SENDMONEY => 13;
        public static int PAGEID_RECEIVEMONEY => 14;


    }
}

