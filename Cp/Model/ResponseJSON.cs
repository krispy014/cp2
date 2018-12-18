using System;

using Newtonsoft.Json;

using Xamarin.Forms;

namespace Cp.Model
{

    public class ResponseJSON
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("result_code")]
        public long result_code { get; set; }

        [JsonProperty("new_token")]
        public string new_token { get; set; }

    }

}

