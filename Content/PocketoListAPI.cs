using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Pocketo.Common;
using Windows.Storage;

namespace Pocketo.Content
{
    public partial class PocketList: Page
    {
        public ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        public partial class RetrieveList
        {
            [JsonConverter(typeof(StringEnumConverter))]
            public enum statetype { unread, archive, all };

            [JsonConverter(typeof(StringEnumConverter))]
            public enum contenttype { article, video, image };

            [JsonConverter(typeof(StringEnumConverter))]
            public enum detailtype { simple, complete };

            [JsonConverter(typeof(StringEnumConverter))]
            public enum sorttype { newest, oldest, title, site };

            public statetype? state;
            public contenttype? content;
            public detailtype? detail;
            public sorttype? sort;

            [JsonConverter(typeof(StringIntConverter))]
            public int? favourite;
            public String tag;

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(UnixDateTimeConverter))]
            public DateTime? since;

            [JsonConverter(typeof(StringIntConverter))]
            public int? count;

            [JsonConverter(typeof(StringIntConverter))]
            public int? offset;

            public String consumer_key = Constants.CONSUMER_KEY;
            public String access_token = (String) ApplicationData.Current.LocalSettings.Values[Constants.ACCESS_TOKEN];

        }

    }
}
