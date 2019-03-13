using System;

using Dap.Platform.Cli;

using IGuiApp = Dap.Gui.Types.IGuiApp;

namespace Dap.UWP.Cli {
    public interface IGuiAppHook : ICliHook {
        void OnInit (IGuiApp app);
    }
}
