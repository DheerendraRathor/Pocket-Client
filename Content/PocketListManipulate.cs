using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.Foundation;
using Windows.UI.Xaml;

namespace Pocket_Client.Content
{
    public partial class PocketList: Page
    {

        private double origin;
        private double lastPost;
        private double marginLeft;
        private bool isMarginSet = false;

        private void ItemList_ManipulationStart(Object sender, ManipulationStartedRoutedEventArgs e)
        {
           origin = e.Position.X;
           if (!isMarginSet)
           {
               marginLeft = ((FrameworkElement)sender).Margin.Left;
               isMarginSet = true;
           }
        }

        private void ItemList_ManipulationDelta(Object sender, ManipulationDeltaRoutedEventArgs e)
        {
            double currPos = e.Position.X;
            Thickness margin = ((FrameworkElement)sender).Margin;
            margin.Left += (currPos  - origin);
            if (margin.Left < marginLeft) margin.Left = marginLeft;
            ((FrameworkElement)sender).Margin = margin;
            if (e.IsInertial)
            {
                System.Diagnostics.Debug.WriteLine("Yes Inertial");
                System.Diagnostics.Debug.WriteLine(e.Position.X);
            }
            
        }

        private void ItemList_ManipulationCompleted(Object sender, ManipulationCompletedRoutedEventArgs e)
        {
            var velocities = e.Velocities;
            System.Diagnostics.Debug.WriteLine(velocities.Linear.X);
        }

    }
}
