using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.ViewManagement;

namespace FileSystemAccessModifier.Classes
{
    public static class AppDesign
    {
        public static void SetStatusBarColor(Color foregroundColor, Color backgroundColor)
        {
            if (ApiInformation.IsTypePresent(PropertyString.VIEWMANAGEMENT_STATUSBAR))
            {
                StatusBar statusBar = StatusBar.GetForCurrentView();
                if (statusBar != null)
                {
                    statusBar.BackgroundOpacity = 1.0;
                    if (foregroundColor != null)
                        statusBar.ForegroundColor = foregroundColor;
                    if (backgroundColor != null)
                        statusBar.BackgroundColor = backgroundColor;
                }
            }
        }
    }
}
