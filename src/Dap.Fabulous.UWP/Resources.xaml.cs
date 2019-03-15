using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms.Platform.UWP;

namespace Dap.Fabulous.UWP {
    public partial class Resources {
        public readonly static Resources Instance = new Resources ();

        public Resources () {
            this.InitializeComponent();
        }
    }
}