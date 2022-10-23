using CefSharp;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBrowserUI.ViewModels;

namespace WebBrowserUI.Commands
{
    public class PreviousCommand : CommandBase
    {

        private readonly MainViewModel _mainViewModel;

        public PreviousCommand(MainViewModel mainViewModel)
        {
            this._mainViewModel = mainViewModel;
        }

        public override void Execute(object parameter)
        {
            if (_mainViewModel.ActualBrowser.Browser.CanGoBack)
            {
                _mainViewModel.ActualBrowser.Browser.Back();
            }
        }
    }
}
