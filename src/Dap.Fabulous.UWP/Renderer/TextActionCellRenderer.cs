using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.UI.Xaml;

using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

using WDataTemplate = Windows.UI.Xaml.DataTemplate;
using WButton = Windows.UI.Xaml.Controls.Button;

namespace Dap.Fabulous.UWP {
    public class TextActionCellRenderer : ICellRenderer {
        public virtual WDataTemplate GetTemplate(Cell cell) {
            return (WDataTemplate)Resources.Instance["TextActionCell"];
        }
    }
}
