using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms.Platform.UWP;

//Maybe related to namespace
//if just using Controls,
//Dap.Fabulous.TextActionCell become the default TextActionCell
// caused compiler error CS0723
using DTextActionCell = Dap.Fabulous.Controls.TextActionCell;

namespace Dap.Fabulous.UWP {
    public partial class TextActionCellView {
        public TextActionCellView () {
            this.InitializeComponent();
        }

        private void OnActionButtonClicked(object sender, RoutedEventArgs e) {
            var cell = (DTextActionCell)this.DataContext;
            cell.FireOnAction ();
        }
    }
}