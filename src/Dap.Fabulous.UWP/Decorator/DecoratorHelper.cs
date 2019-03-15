using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

using XPlatform = Xamarin.Forms.Platform.UWP.Platform;
using XColor = Xamarin.Forms.Color;

namespace Dap.Fabulous.UWP {
    public static class DecoratorHelper {
        //Copied form Xamarin.Forms.Platform.UAP/ListViewRenderer.cs
        static IEnumerable<T> FindDescendants<T>(this DependencyObject dobj) where T : DependencyObject {
            int count = VisualTreeHelper.GetChildrenCount(dobj);
            for (var i = 0; i < count; i++) {
                DependencyObject element = VisualTreeHelper.GetChild(dobj, i);
                if (element is T)
                    yield return (T)element;

                foreach (T descendant in FindDescendants<T>(element))
                    yield return descendant;
            }
        }

        //There is no way to find the CellControl from cell directly in UWP
        public static CellControl GetCellControl (this Cell cell) {
            var cellParent = cell.Parent as VisualElement;
            if (cellParent == null) return null;
            var container = XPlatform.GetRenderer(cellParent)?.GetNativeElement();
            foreach (CellControl selector in FindDescendants<CellControl>(container)) {
                if (ReferenceEquals(cell, selector.DataContext))
                    return selector;
            }
            return null;
        }
        public static FrameworkElement GetCellContent (this Cell cell) {
            var control = GetCellControl (cell);
            return control?.Content as FrameworkElement;
        }
    }
}
