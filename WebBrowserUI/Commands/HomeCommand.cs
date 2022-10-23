using CefSharp;
using Models;
using RegistryManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBrowserUI.ViewModels;

namespace WebBrowserUI.Commands
{
    public class HomeCommand : CommandBase
    {

        private readonly MainViewModel _mainViewModel;

        public HomeCommand(MainViewModel mainViewModel)
        {
            this._mainViewModel = mainViewModel;
        }

        public override void Execute(object parameter)
        {
            _mainViewModel.ActualBrowser.CurrentUrl = RegistryUtils.getDefaultUrl();
            _mainViewModel.ActualBrowser.Browser.LoadUrl(_mainViewModel.ActualBrowser.CurrentUrl);  
        }
    }
}
