using System;

using Newtonsoft.Json;

using Xamarin.Forms;

namespace Cp.Viewmodel
{

    public class Token
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("result_code")]
        public long ResultCode { get; set; }

        [JsonProperty("new_token")]
        public string NewToken { get; set; }



    }



}

