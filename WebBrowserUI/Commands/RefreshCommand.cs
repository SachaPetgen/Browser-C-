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
    public class RefreshCommand : CommandBase
    {

        private readonly MainViewModel _mainViewModel;

        public RefreshCommand(MainViewModel mainViewModel)
        {
            this._mainViewModel = mainViewModel;
        }

        public override void Execute(object parameter)
        {
            _mainViewModel.ActualBrowser.Browser.Reload();

        }
    }
}
