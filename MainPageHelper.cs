using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//My Usings
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;

namespace Pocket_Client
{
  public partial class MainPage : Page
  {

    private async void generateRequestToken()
    {
        String url = resourceLoader.GetString("requestTokenURI");
        HttpClient request = new HttpClient();
        Uri uri = new Uri(url);
        Dictionary<String, String> postValue = new Dictionary<string, string>();
        postValue.Add("consumer_key", localSettings.Values["consumer_key"] as String);
        HttpResponseMessage response = await request.PostAsync(uri, new HttpStringContent("")).AsTask(cts.Token);
    }
  }
}
