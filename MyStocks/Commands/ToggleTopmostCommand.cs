using Prism.Commands;
using System.Windows;

namespace MyStocks.Commands
{
    public class ToggleTopmostCommand : DelegateCommand<Window>
    {
        public ToggleTopmostCommand() : base(ExecuteToggleTopmost)
        {
        }

        private static void ExecuteToggleTopmost(Window window)
        {
            if (window != null)
            {
                window.Topmost = !window.Topmost;
            }
        }
    }
}