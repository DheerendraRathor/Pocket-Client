using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//My Usings
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;
using Newtonsoft.Json;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml;

namespace Pocket_Client
{
    public partial class MainPage : Page
    {

        private async Task generateRequestToken()
        {
            String url = Constants.REQUEST_TOKEN_URI;
            HttpClient request = new HttpClient();
            Uri uri = new Uri(url);

            Dictionary<String, String> postValue = new Dictionary<string, string>();
            postValue.Add(Constants.CONSUMER_KEY, keysLoader.GetString(Constants.CONSUMER_KEY));
            postValue.Add(Constants.REDIRECT_URI, Constants.REDIRECT_TO);
            String postData = JsonConvert.SerializeObject(postValue);

            HttpStringContent reqMsg = null;
            prepareRequest(ref request, ref reqMsg, postData);

            HttpResponseMessage response = await request.PostAsync(uri, reqMsg).AsTask(cts.Token);
            String responseData = await response.Content.ReadAsStringAsync().AsTask(cts.Token);

            HttpStatusCode responseStatus =  response.StatusCode;

            if (responseStatus == HttpStatusCode.Ok)
            {
                Dictionary<String, String> responseDictionary = JsonConvert.DeserializeObject<Dictionary<String, String>>(responseData);
                String code = responseDictionary[Constants.CODE];
                localSettings.Values[Constants.REQUEST_TOKEN] = code;
                auth_button.Content = "Verifying User, Please wait";
            }
            else if (responseStatus == HttpStatusCode.Forbidden)
            {
                auth_button.Content = "Oops! Something went wrong";
            }
            else if ((int)responseStatus >= 500 && (int)responseStatus <= 600)
            {
                auth_button.Content = "Oops! Something went wrong";
            }
            else
            {
                auth_button.Content = "Unable to Proceed. Please try again later";
            }

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

        private async Task authorizeUser()
        {
            String authURI = String.Format(Constants.AUTH_URI, localSettings.Values[Constants.REQUEST_TOKEN], Constants.REDIRECT_TO);
            bool redirected = await Windows.System.Launcher.LaunchUriAsync(new Uri(authURI));
        }
    }
}
