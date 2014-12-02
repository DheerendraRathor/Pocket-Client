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

//My imports
using System.Diagnostics;
using Windows.ApplicationModel.Resources;
using Windows.Web.Http;
using Windows.Web.Http.Filters;
using Windows.Storage;
using System.Threading;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Pocket_Client
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

      private readonly ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView("Resources");
      private readonly ResourceLoader keysLoader = ResourceLoader.GetForCurrentView("Keys");
      private ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
      private CancellationTokenSource cts;
        public MainPage()
        {
          
            this.InitializeComponent();
          

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
          String request_token = localSettings.Values["request_token"] as String;
          System.Diagnostics.Debug.WriteLine(request_token);
          if (request_token == null)
          {
           
          }
           
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }
    }
}
