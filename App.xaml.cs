﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Pocketo.Common;
using Windows.Storage;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=391641 

namespace Pocketo
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App : Application
    {
        private TransitionCollection transitions;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += this.OnSuspending;
        }

        private async void RestoreStatus(ApplicationExecutionState previousExecutionState)
        {
            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (previousExecutionState == ApplicationExecutionState.Terminated)
            {
                // Restore the saved session state only when appropriate
                try
                {
                    await SuspensionManager.RestoreAsync();
                }
                catch (SuspensionManagerException)
                {
                    //Something went wrong restoring state.
                    //Assume there is no state and continue
                }
            }
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

       
        protected override void OnActivated(IActivatedEventArgs e)
        {
            if (e.Kind == ActivationKind.Protocol)
            {
                ProtocolActivatedEventArgs eArgs = e as ProtocolActivatedEventArgs;
                Frame rootFrame = Window.Current.Content as Frame;
                if (rootFrame == null)
                {
                    rootFrame = new Frame();
                    rootFrame.NavigationFailed += OnNavigationFailed;
                    SuspensionManager.RegisterFrame(rootFrame, "AppFrame");
                    Window.Current.Content = rootFrame;
                }

                RestoreStatus(e.PreviousExecutionState);

                if (rootFrame.Content == null)
                {
                    // Removes the turnstile navigation for startup.
                    if (rootFrame.ContentTransitions != null)
                    {
                        this.transitions = new TransitionCollection();
                        foreach (var c in rootFrame.ContentTransitions)
                        {
                            this.transitions.Add(c);
                        }
                    }

                    rootFrame.ContentTransitions = null;
                    rootFrame.Navigated += this.RootFrame_FirstNavigated;

                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    if (!rootFrame.Navigate(typeof(MainPage)))
                    {
                        throw new Exception("Failed to create initial page");
                    }

                }

                var p = rootFrame.Content as MainPage;
                String url = eArgs.Uri.ToString();
                if (url == Constants.REDIRECT_TO.ToLower())
                {
                    p.returnFromAuth();
                    Window.Current.Activate();
                }
                else
                {
                    throw new Exception("Cannot process this activation");
                }
            }

        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                // TODO: change this value to a cache size that is appropriate for your application
                rootFrame.CacheSize = 1;
                rootFrame.NavigationFailed += OnNavigationFailed;
                SuspensionManager.RegisterFrame(rootFrame, "AppFrame");
                RestoreStatus(e.PreviousExecutionState);

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // Removes the turnstile navigation for startup.
                if (rootFrame.ContentTransitions != null)
                {
                    this.transitions = new TransitionCollection();
                    foreach (var c in rootFrame.ContentTransitions)
                    {
                        this.transitions.Add(c);
                    }
                }

                rootFrame.ContentTransitions = null;
                rootFrame.Navigated += this.RootFrame_FirstNavigated;

                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof(MainPage), e.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }

            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Restores the content transitions after the app has launched.
        /// </summary>
        /// <param name="sender">The object where the handler is attached.</param>
        /// <param name="e">Details about the navigation event.</param>
        private void RootFrame_FirstNavigated(object sender, NavigationEventArgs e)
        {
            var rootFrame = sender as Frame;
            rootFrame.ContentTransitions = this.transitions ?? new TransitionCollection() { new NavigationThemeTransition() };
            rootFrame.Navigated -= this.RootFrame_FirstNavigated;
            var first_fetch = ApplicationData.Current.LocalSettings.Values["first_fetch"];
            if (first_fetch == null)
            {
                ApplicationData.Current.LocalSettings.Values["first_fetch"] = false;
            }
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            // TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}