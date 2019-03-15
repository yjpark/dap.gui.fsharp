using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

using Dap.Fabulous.Controls;

using XPlatform = Xamarin.Forms.Platform.UWP.Platform;
using XColor = Xamarin.Forms.Color;

namespace Dap.Fabulous.UWP {
    public class SwitchCellDecorator : ISwitchCellDecorator {
        public async void SetTextColor(SwitchCell cell, XColor color) {
            await Task.Yield(); //Needed, since CellControl calling Appearing before create content
            var text = cell.GetCellControl()?.GetFirstDescendant<TextBlock>();
            if (text != null) {
                text.Foreground = color.ToBrush();
            }
        }
    }
}
