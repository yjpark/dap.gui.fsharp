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
        private TextBlock _Text = null;

        public void SetTextColor(SwitchCell cell, XColor color) {
            if (_Text == null) {
                _Text = cell.GetCellControl()?.GetFirstDescendant<TextBlock>();
            }
            if (_Text != null) {
                _Text.Foreground = color.ToBrush();
            }
        }
    }
}
