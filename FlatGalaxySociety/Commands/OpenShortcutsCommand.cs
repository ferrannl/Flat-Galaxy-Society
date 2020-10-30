using FlatGalaxySociety.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlatGalaxySociety.Commands
{
    public class OpenShortcutsCommand : Command
    {
        public override void Execute(object parameter)
        {
            ShortcutWindow shortcutWindow = new ShortcutWindow();
            shortcutWindow.ShowDialog();
        }
    }
}
