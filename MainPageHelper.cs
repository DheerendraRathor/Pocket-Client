using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//My Usings
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;
using Newtonsoft.Json;
using Windows.Storage.Streams;

namespace Pocket_Client
{
    public partial class MainPage : Page
    {

        private async Task generateRequestToken()
        {
            String url = resourceLoader.GetString("requestTokenURI");
            HttpClient request = new HttpClient();
            Uri uri = new Uri(url);
            Dictionary<String, String> postValue = new Dictionary<string, string>();
            postValue.Add("consumer_key", keysLoader.GetString("consumer_key"));
            postValue.Add("redirect_uri", "pocket-dsr://getRequestToken");
            String postData = JsonConvert.SerializeObject(postValue);
            HttpStringContent reqMsg = null;
            prepareRequest(ref request, ref reqMsg, postData);
            HttpResponseMessage response = await request.PostAsync(uri, reqMsg).AsTask(cts.Token);
            String responseData = await response.Content.ReadAsStringAsync().AsTask(cts.Token);
            Dictionary<String, String> responseDictionary = JsonConvert.DeserializeObject<Dictionary<String, String>>(responseData);
            String code = responseDictionary["code"];
            
        }

        private void prepareRequest(ref HttpClient httpClient, ref HttpStringContent reqMsg, String postData)
        {
            httpClient.DefaultRequestHeaders.Add("X-Accept", "application/json");
            reqMsg = new HttpStringContent(postData, UnicodeEncoding.Utf8);
            reqMsg.Headers.ContentType = new Windows.Web.Http.Headers.HttpMediaTypeHeaderValue("content-type")
            {
                MediaType = "application/json"
            };
        }
    }
}
