using System;
using System.Threading;
using Windows.ApplicationModel.Resources;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.Activation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Pocket_Client
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private readonly ResourceLoader keysLoader = ResourceLoader.GetForCurrentView(Constants.KEY_FILE);
        private ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        private CancellationTokenSource cts;
        public MainPage()
        {

            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        private ProtocolActivatedEventArgs _protocolEventArgs = null;
        public ProtocolActivatedEventArgs ProtocolEvent
        {
            get { return _protocolEventArgs; }
            set { _protocolEventArgs = value; }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.

            String request_token = localSettings.Values[Constants.REQUEST_TOKEN] as String;
            if (request_token == null)
            {
                auth_button.Content = Constants.CONFIG_MSG;
                cts = new CancellationTokenSource(20000);
                await generateRequestToken();
                request_token = localSettings.Values[Constants.REQUEST_TOKEN] as String;
                if (request_token == null)
                {
                    auth_button.Content = "Authentication Failed";
                    return;
                }
            }

            String access_token = localSettings.Values[Constants.ACCESS_TOKEN] as String;
            if (access_token == null)
            {
                cts = new CancellationTokenSource(20000);
                auth_button.Content = Constants.AUTH_MSG;
                auth_button.IsEnabled = true;
                progressRing.IsActive = false;
            }
            else
            {
                auth_button.Content = "Authenticated";
                auth_button.IsEnabled = false;
                progressRing.IsActive = false;
                //TODO: redirect to List view
            }

        }

    }
}
