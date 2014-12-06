using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.Foundation;
using Windows.UI.Xaml;

namespace Pocketo.Content
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
            var fwElement = (FrameworkElement)sender;
            Thickness margin = fwElement.Margin;
            margin.Left += (currPos - origin);
            if (margin.Left < marginLeft) margin.Left = marginLeft;
            fwElement.Margin = margin; 
            
        }

        private void ItemList_ManipulationCompleted(Object sender, ManipulationCompletedRoutedEventArgs e)
        {
            

            
        }

    }
}
