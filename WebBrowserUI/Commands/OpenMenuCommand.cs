using CefSharp;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WebBrowserUI.ViewModels;

namespace WebBrowserUI.Commands
{
    public class OpenMenuCommand : CommandBase
    {


        public override void Execute(object parameter)
        {
            //ContextMenu cm = parameter as ContextMenu;
            //cm.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            //cm.IsOpen = true;
        }
    }
}
