using System;

using Xamarin.Forms;
using Dap.Platform.Cli;

namespace Dap.Fabulous.Controls {
    public interface INativeDecorator : ICliHook {
    }

    public interface IEntryDecorator : INativeDecorator {
        void SetTextBorderColor(Entry widget, Color color);
        void SetTextBackgroundColor(Entry widget, Color color);
    }

    public interface ISwitchCellDecorator : INativeDecorator {
        void SetTextColor(SwitchCell cell, Color color);
    }

    public interface IEntryCellDecorator : INativeDecorator {
        void SetTextColor(EntryCell cell, Color color);
        void SetTextBackgroundColor(EntryCell cell, Color color);
        void SetPlaceholderColor(EntryCell cell, Color color);
    }

    public interface INavigationPageDecorator : INativeDecorator {
        //Note : Can NOT just use NavigationPage.BarTextColor, which has different behavior
        //On Android and iOS
        // iOS: Change both title and action
        // Android: Change only title
        void SetBarActionColor(NavigationPage page, Color color);
        void UpdateBarStyle(NavigationPage page);
    }
}
