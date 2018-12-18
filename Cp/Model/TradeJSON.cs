using System;

using Newtonsoft.Json;

using Xamarin.Forms;

namespace Cp.Model
{

    public class TradeJSON_init
    {
        [JsonProperty("cp_code")]
        public string cp_code { get; set; }

    }

    public class TradeJSON_ob_new
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("result_code")]
        public long result_code { get; set; }

        [JsonProperty("new_token")]
        public string new_token { get; set; }

    }

}

