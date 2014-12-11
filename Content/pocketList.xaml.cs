using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Windows.ApplicationModel.Resources;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Windows.Web.Http;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Pocketo.Content
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PocketList : Page
    {

        private readonly ResourceLoader keysLoader = ResourceLoader.GetForCurrentView(Constants.KEY_FILE);
        public PocketList()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            TitleText.Text = Constants.APP_NAME;
            bool first_fetch = (bool) localSettings.Values["first_fetch"];
            if (first_fetch == false)
            {
                loadFirstList();
            }
        }

        private async void loadFirstList()
        {
            RetrieveList retrieve = new RetrieveList();
            retrieve.access_token = (String)localSettings.Values[Constants.ACCESS_TOKEN];
            retrieve.consumer_key = keysLoader.GetString(Constants.CONSUMER_KEY);
            retrieve.detail = RetrieveList.detailtype.complete;
            retrieve.sort = RetrieveList.sorttype.newest;
            retrieve.state = RetrieveList.statetype.all;

            JsonSerializerSettings jss = new JsonSerializerSettings();
            jss.NullValueHandling = NullValueHandling.Ignore;
            //jss.DefaultValueHandling = DefaultValueHandling.Ignore;

            String requestMsg = JsonConvert.SerializeObject(retrieve, jss);

            Uri uri = new Uri(Constants.RETRIEVE_URI);
            HttpClient request = new HttpClient(uri);
            
        }
    }
}
